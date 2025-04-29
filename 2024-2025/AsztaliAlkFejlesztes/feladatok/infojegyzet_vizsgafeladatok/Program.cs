using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace infojegyzet_vizsgafeladatok
{
    class Program
    {
        private static readonly Type[] types = new Type[] { typeof(Vizibicikli), typeof(Jackie), typeof(Versenyzok), typeof(Operatorok), typeof(Kosar2004), typeof(Balkezesek), typeof(Fuvar) };
        public static string PadNum<T>(T num, char pad_char)
        {
            return num.ToString().PadLeft(2, pad_char);
        }
        private static bool NoFilter<G>(G item) => true;
        public static T TryInput<T>(string txt, Func<T, bool> predicate = null, string error_msg = "Hibás értéket adott meg.")
        {
            predicate ??= NoFilter;
            while(true)
            {
                try
                {
                    T[] tmp = new T[] { (T)Convert.ChangeType(Input(txt), typeof(T))};
                    if (tmp.All(predicate)) {return tmp[0];}
                    throw new FormatException();
                }
                catch
                {
                    Console.WriteLine(error_msg);
                }
            }
        }
        public static string Input(string txt)
        {
            Console.Write(txt);
            return Console.ReadLine();
        }
        static void Main()
        {
            int tmp = TryInput<int>($"Adja meg mely feladatot akarja\n\t{string.Join("\n\t", types.ToList().ConvertAll(x => $"{types.ToList().IndexOf(x)+1} - {x.Name}"))}\n> ", x => x > 0 && x <= types.Length);
            Type type = types[tmp - 1];
            if (type != null)
                type.GetMethod("Main").Invoke(null, null);
            Console.ReadKey();
        }
    }
    /// <summary> https://infojegyzet.hu/vizsgafeladatok/okj-programozas/szoftverfejleszto-220208/ </summary>
    class Vizibicikli : Program
    {
        public static void Main()
        {
            // 1-4. Feladat
            List<string> file_content = File.ReadAllLines("kolcsonzesek.txt").ToList();
            file_content.RemoveAt(0);
            List<Kolcsonzes> kolcsonok = new List<Kolcsonzes>();
            foreach (string line in file_content)
            {
                kolcsonok.Add(new Kolcsonzes(line));
            }
            // 5. Feladat
            Console.WriteLine($"5. Feladat: Napi Kölcsönzések száma: {kolcsonok.Count}");
            // 6. Feladat
            Console.Write("6. Feladat: ");
            string fel6_nev = Input("Kérek egy nevet: ");
            Console.Write($"\t{fel6_nev} kölcsönzései:\n");
            if (kolcsonok.Any(x => x.nev == fel6_nev))
            {
                kolcsonok.Where(x => x.nev == fel6_nev).ToList().ForEach(x => Console.WriteLine($"\t{PadNum(x.EOra, '0')}:{PadNum(x.EPerc, '0')}-{PadNum(x.VOra, '0')}:{PadNum(x.VPerc, '0')}"));
            }
            else
            {
                Console.WriteLine("\tNem volt ilyen nevű kölcsönző!");
            }
            // 7. Feladat
            string[] fel7_idopont = TryInput<string>("7.Feladat: Adjon meg egy időpontot \"óra:perc\" alakban: ", x => x.Split(':').Length == 2).Split(':');
            Console.WriteLine("\tA vízen lévő járművek:");
            byte ora = byte.Parse(fel7_idopont[0]), perc = byte.Parse(fel7_idopont[1]);
            kolcsonok.Where(x => x.Berelt_Idokor(ora, perc)).ToList().ForEach(kolcson => Console.WriteLine($"\t{PadNum(kolcson.EOra, '0')}:{PadNum(kolcson.EPerc, '0')}-{PadNum(kolcson.VOra, '0')}:{PadNum(kolcson.VPerc, '0')} : {kolcson.nev}"));
            // 8. Feladat
            int osszeg = 0;
            foreach (Kolcsonzes kolcson in kolcsonok)
            {
                osszeg += kolcson.NapiBevetel();
            }
            Console.WriteLine($"8. Feladat: A napi bevétel: {osszeg} Ft");
            // 9. Feladat
            int i = 0;
            string[] bunos_jeloltek = new string[kolcsonok.Count(x => x.JAzon == 'F')];
            kolcsonok.Where(x => x.JAzon == 'F').ToList().ForEach(x => { bunos_jeloltek[i] = $"{PadNum(x.EOra, '0')}:{PadNum(x.EPerc, '0')}-{PadNum(x.VOra, '0')}:{PadNum(x.VPerc, '0')} : {x.nev}"; i++; });
            File.WriteAllLines("F.txt", bunos_jeloltek);
            // 10. Feladat
            Console.WriteLine("10. Feladat: Statisztika");
            foreach (char _char in new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G' })
            {
                Console.WriteLine($"\t{_char} - {kolcsonok.Count(x => x.JAzon == _char)}");
            }
        }
        public static void Main2()
        {
            // 1-4. Feladat
            List<string> file_content = File.ReadAllLines("kolcsonzesek.txt").ToList();
            file_content.RemoveAt(0);
            List<Kolcsonzes_2> kolcsonok = new List<Kolcsonzes_2>();
            foreach (string line in file_content)
            {
                string[] tmp = line.Split(";");
                kolcsonok.Add(new Kolcsonzes_2()
                {
                    nev = tmp[0],
                    JAzon = tmp[1][0],
                    EOra = byte.Parse(tmp[2]),
                    EPerc = byte.Parse(tmp[3]),
                    VOra = byte.Parse(tmp[4]),
                    VPerc = byte.Parse(tmp[5]),
                });
            }
            // 5. Feladat
            Console.WriteLine($"5. Feladat: Napi Kölcsönzések száma: {kolcsonok.Count}");
            // 6. Feladat
            Console.Write("6. Feladat: ");
            string fel6_nev = Input("Kérek egy nevet: ");
            Console.Write($"\t{fel6_nev} kölcsönzései:\n");
            if (kolcsonok.Any(x => x.nev == fel6_nev))
            {
                kolcsonok.Where(x => x.nev == fel6_nev).ToList().ForEach(x => Console.WriteLine($"\t{PadNum(x.EOra, '0')}:{PadNum(x.EPerc, '0')}-{PadNum(x.VOra, '0')}:{PadNum(x.VPerc, '0')}"));
            }
            else
            {
                Console.WriteLine("\tNem volt ilyen nevű kölcsönző!");
            }
            // 7. Feladat
            string[] fel7_idopont = TryInput<string>("7.Feladat: Adjon meg egy időpontot \"óra:perc\" alakban: ", x => x.Split(':').Length == 2).Split(':');
            Console.WriteLine("\tA vízen lévő járművek:");
            byte ora = byte.Parse(fel7_idopont[0]), perc = byte.Parse(fel7_idopont[1]);
            kolcsonok.Where(kolcson => ((kolcson.EPerc <= perc && kolcson.EOra == ora) || (kolcson.EOra < ora)) && ((kolcson.VPerc >= perc && kolcson.VOra == ora) || (kolcson.VOra > ora))).ToList().ForEach(kolcson => Console.WriteLine($"\t{PadNum(kolcson.EOra, '0')}:{PadNum(kolcson.EPerc, '0')}-{PadNum(kolcson.VOra, '0')}:{PadNum(kolcson.VPerc, '0')} : {kolcson.nev}"));
            /* foreach (Kolcsonzes_2 kolcson in kolcsonok)
            {
                if (
                   ((kolcson.EPerc <= perc && kolcson.EOra == ora) || (kolcson.EOra < ora)) &&
                   ((kolcson.VPerc >= perc && kolcson.VOra == ora) || (kolcson.VOra > ora))
                )
                {
                    Console.WriteLine($"\t{kolcson.nev}: {(Convert.ToString(kolcson.VOra).Length == 1 ? "0" : "")}{kolcson.VOra}:{(Convert.ToString(kolcson.VPerc).Length == 1 ? "0" : "")}{kolcson.VPerc}");
                }
            } */
            // 8. Feladat
            int osszeg = 0;
            foreach (Kolcsonzes_2 kolcson in kolcsonok)
            {
                int ido_perc = (kolcson.VOra-kolcson.EOra)*60+(kolcson.VPerc-kolcson.EPerc);
                while (ido_perc > 0)
                {
                    osszeg += 2400;
                    ido_perc -= 30;
                }
            }
            Console.WriteLine($"8. Feladat: A napi bevétel: {osszeg} Ft");
            // 9. Feladat
            int i = 0;
            string[] bunos_jeloltek = new string[kolcsonok.Count(x => x.JAzon == 'F')];
            kolcsonok.Where(x => x.JAzon == 'F').ToList().ForEach(x => { bunos_jeloltek[i] = $"{PadNum(x.EOra, '0')}:{PadNum(x.EPerc, '0')}-{PadNum(x.VOra, '0')}:{PadNum(x.VPerc, '0')} : {x.nev}"; i++; });
            File.WriteAllLines("F.txt", bunos_jeloltek);
            // 10. Feladat
            Console.WriteLine("10. Feladat: Statisztika");
            foreach (char _char in new char[] {'A','B','C','D','E','F','G'})
            {
                Console.WriteLine($"\t{_char} - {kolcsonok.Count(x => x.JAzon == _char)}");
            }
        }
        struct Kolcsonzes_2
        {
            public string nev;
            public char JAzon;
            public byte EOra;
            public byte EPerc;
            public byte VOra;
            public byte VPerc;
        }
        class Kolcsonzes
        {
            public string nev;
            public char JAzon;
            public byte EOra;
            public byte EPerc;
            public byte VOra;
            public byte VPerc;
            public Kolcsonzes(string line)
            {
                string[] raw = line.Split(';');
                nev = raw[0];
                JAzon = raw[1][0];
                EOra = byte.Parse(raw[2]);
                EPerc = byte.Parse(raw[3]);
                VOra = byte.Parse(raw[4]);
                VPerc = byte.Parse(raw[5]);
            }
            public int NapiBevetel()
            {
                int osszeg = 0;
                int ido_perc = (VOra - EOra) * 60 + (VPerc - EPerc);
                while (ido_perc > 0)
                {
                    osszeg += 2400;
                    ido_perc -= 30;
                }
                return osszeg;
            }
            public bool Berelt_Idokor(byte ora, byte perc)
            {
                if (ora >= 24 || ora < 0 || perc >= 60 || perc < 0)
                {
                    throw new Exception("Az idő változók nem megfelelően lettek megadva");
                }
                return (EPerc <= perc && EOra == ora) || (EOra < ora) && ((VPerc >= perc && VOra == ora) || (VOra > ora));
            }
        }
    }
    /// <summary> https://infojegyzet.hu/vizsgafeladatok/okj-programozas/szoftverfejleszto-210511/ </summary>
    class Jackie : Program
    {
        public static void Main()
        {
            // 2. Feladat
            List<Races> content = File.ReadAllLines("jackie.txt", encoding: Encoding.UTF8).ToList().ConvertAll(x => new Races(x));
            content.RemoveAll(x => x.year == 0);
            // 3. Feladat
            Console.WriteLine($"3. Feladat: {content.Count}");
            // 4. Feladat
            Console.WriteLine($"4. Feladat: {content.Max(x => x.races)}");
            // 5. Feladat
            Console.WriteLine($"5. Feladat: \n" +
                                $"\t70-es évek: {content.Count(x => x.year >= 1970 && x.year < 1980)} megnyert verseny\n" +
                                $"\t60-as évek: {content.Count(x => x.year >= 1960 && x.year < 1970)} megnyert verseny");
            // 6. Feladat
            Console.WriteLine($"6. Feladat: jackie.html");
            string[] jackie_html = new string[] {
                "<!DOCTYPE html>",
                "<html>",
                    "<head></head>",
                    "<style> td { border: 1px solid black;}</style>",
                    "<body>",
                        "<h1>Jackie Stewart</h1>",
                        "<table>",
                        "</table>",
                    "</body>",
                "</html>"
            };
            FileStream file = new FileStream("jackie.html", FileMode.Create);
            StreamWriter sw = new StreamWriter(file);
            foreach (string element in jackie_html)
            {
                sw.WriteLine(element);
                if (element == "<table>") {
                    for (int i = 0; i < content.Count; i++)
                    {
                        sw.WriteLine($"<tr><td>{content[i].year}</td><td>{content[i].races}</td><td>{content[i].wins}</td></tr>");
                    }
                }
            }
            sw.Close();
            file.Close();
        }
        private class Races
        {
            public short year;
            public byte races;
            public byte wins;
            public byte podiums;
            public byte poles;
            public byte fastests;
            public Races(string sor)
            {
                if (sor == "year\traces\twins\tpodiums\tpoles\tfastests")
                {
                    return;
                }
                string[] temp = sor.Split('\t');
                year = short.Parse(temp[0]);
                races = byte.Parse(temp[1]);
                wins = byte.Parse(temp[2]);
                podiums = byte.Parse(temp[3]);
                poles = byte.Parse(temp[4]);
                fastests = byte.Parse(temp[5]);
            }
        }
    }
    /// <summary> https://infojegyzet.hu/vizsgafeladatok/okj-programozas/szoftverfejleszto-210209/ </summary>
    class Versenyzok : Program
    {
        public static void Main()
        {
            // 2. Feladat
            List<Pilota> versenyzok = File.ReadAllLines("pilotak.csv").ToList().ConvertAll(x => new Pilota(x));
            versenyzok.RemoveAt(0); // Fejléc
            // 3. Feladat
            Console.WriteLine($"3. feladat: {versenyzok.Count}");
            // 4. Feladat
            Console.WriteLine($"4. feladat: {versenyzok[versenyzok.Count-1].nev}");
            // 5. Feladat
            Console.WriteLine("5. feladat:");
            if (versenyzok.Any(x => x.szul_ev <= 1900))
            {
                foreach (Pilota pilota in versenyzok.Where(x => x.szul_ev <= 1900))
                {
                    Console.WriteLine($"\t{pilota.nev} ({pilota.szul_ev}. {PadNum(pilota.szul_ho, '0')}. {PadNum(pilota.szul_nap, '0')}.)");
                }
            }
            else
            {
                Console.WriteLine("Nincs olyan versenyző, aki a XIX. században született volna.");
            }
            // 6. Feladat
            List<Pilota> temp = versenyzok.Where(x => x.rajtszam != -1).ToList();
            temp.OrderBy(x => x.rajtszam);
            Console.WriteLine($"6. feladat: {temp[0].nemzet}");
            // 7. Feladat
            Console.WriteLine($"7. feladat: {string.Join(", ", versenyzok.Where(x => x.rajtszam != -1 && versenyzok.Count(y => y.rajtszam == x.rajtszam) != 1).Select(x => x.rajtszam).Distinct())}");
        }
        class Pilota
        {
            public string nev;
            public short szul_ev;
            public byte szul_ho;
            public byte szul_nap;
            public string nemzet;
            public sbyte rajtszam = -1;
            public Pilota(string line)
            {
                if (line == "név;születési_dátum;nemzetiség;rajtszám")
                    return;
                string[] temp = line.Split(';');
                nev = temp[0];
                string[] szul_datum = temp[1].Split('.');
                szul_ev = short.Parse(szul_datum[0]);
                szul_ho = byte.Parse(szul_datum[1]);
                szul_nap = byte.Parse(szul_datum[2]);
                nemzet = temp[2];
                if (temp[3] != "")
                    rajtszam = sbyte.Parse(temp[3]);
            }
        }
    }
    /// <summary> https://infojegyzet.hu/vizsgafeladatok/okj-programozas/szoftverfejleszto-201006/ </summary>
    class Operatorok : Program
    {
        public static void Main()
        {
            List<Operacio> operaciok = File.ReadAllLines("kifejezesek.txt").ToList().ConvertAll(x => new Operacio(x));
            // 2. Feladat
            Console.WriteLine($"2. feladat: Kifejezések száma: {operaciok.Count}");
            // 3. Feladat
            Console.WriteLine($"3. feladat: Kifejezések maradékos osztással: {operaciok.Count(x => x.operation.ToLower() == "mod")}");
            // 4. Feladat
            Console.WriteLine($"4. feladat: {(operaciok.Any(x => x.a % 10 == 0 && x.b % 10 == 0) ? "Van":"Nincs")} ilyen kifejezés!");
            // 5. Feladat
            Console.WriteLine($"5. feladat: Statisztika\n" +
                                $"\tmod -> {operaciok.Count(x => x.operation == "mod")} db\n" +
                                $"\t/ -> {operaciok.Count(x => x.operation == "/")} db\n" +
                                $"\tdiv -> {operaciok.Count(x => x.operation == "div")} db\n" +
                                $"\t- -> {operaciok.Count(x => x.operation == "-")} db\n" +
                                $"\t* -> {operaciok.Count(x => x.operation == "*")} db\n" +
                                $"\t+ -> {operaciok.Count(x => x.operation == "+")} db");
            // 7. Feladat
            bool vege;
            do
            {
                string input = Input("7. feladat: Kérek egy kifejezést (pl. 1 + 1): ");
                vege = input.ToLower().Trim() == "vége";
                if (vege) {continue;}
                Operacio temp = new Operacio(input);
                try
                {
                    double tmp = temp.DoOperation();
                    Console.WriteLine($"\t{input} = {tmp}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\t{input} = {ex.Message}");
                }
            }
            while (!vege);
            // 8. Feladat
            FileStream fs = new FileStream("eredmenyek.txt", FileMode.Create);
            StreamWriter sw = new StreamWriter(fs);
            foreach (Operacio operacio in operaciok)
            {
                try
                {
                    sw.WriteLine($"{operacio.a} {operacio.operation} {operacio.b} = {operacio.DoOperation()}");
                }
                catch (Exception ex)
                {
                    sw.WriteLine($"{operacio.a} {operacio.operation} {operacio.b} = {ex.Message}");
                }
            }
            sw.Close();
            fs.Close();
            Console.WriteLine("8. feladat: eredmenyek.txt");
        }
        class Operacio
        {
            public int a;
            public string operation;
            public int b;
            public Operacio(string line)
            {
                string[] temp = line.Split(' ');
                a = int.Parse(temp[0]);
                operation = temp[1];
                b = int.Parse(temp[2]);
            }
            // 6. Feladat
            public double DoOperation()
            {
                try
                {
                    return operation switch
                    {
                        "+" => a + b,
                        "-" => a - b,
                        "*" => a * b,
                        "/" => (a != 0 && b != 0 ? Convert.ToDouble(a) / b : throw new DivideByZeroException()),
                        "div" => (a != 0 && b != 0 ? Math.Floor(Convert.ToDouble(a) / b) : throw new DivideByZeroException()),
                        "mod" => a % b,
                        _ => throw new Exception("Hibás operátor!"),
                    };
                }
                catch (Exception ex)
                {
                    if (ex.Message != "Hibás operátor!")
                        throw new Exception("Egyéb hiba!");
                    throw new Exception(ex.Message);
                }
            }
        }
    }
    /// <summary> https://infojegyzet.hu/vizsgafeladatok/okj-programozas/szoftverfejleszto-200526/ </summary>
    class Kosar2004 : Program
    {
        public static void Main()
        {
            // 2. Feladat
            List<Kosar> kosarak = File.ReadAllLines("eredmenyek.csv", Encoding.UTF8).ToList().ConvertAll(x => new Kosar(x));
            kosarak.RemoveAt(0); // Fejléc
            // 3. Feladat
            Console.WriteLine($"3. feladat: Real Madrid: Hazai: {kosarak.Count(x => x.hazai == "Real Madrid")}, Idegen: {kosarak.Count(x => x.idegen == "Real Madrid")}");
            // 4. Feladat
            Console.WriteLine($"4. feladat: Volt döntetlen? {(kosarak.Any(x => x.Dontetlen())? "igen":"nem")}");
            // 5. Feladat
            Console.WriteLine($"5. feladat: barcelonai csapat neve: {kosarak.Where(x => x.hazai.ToLower().Contains("barcelona")).First().hazai}");
            // 6. Feladat
            Console.WriteLine($"6. feladat: \n\t{string.Join("\n\t", kosarak.Where(x => x.Jatszott(2004, 11, 21)).ToList().ConvertAll(x => $"{x.hazai} - {x.idegen} ({x.hazai_pont}:{x.idegen_pont})"))}");
            // 7. Feladat
            Console.WriteLine($"7. feladat: \n\t{string.Join("\n\t", kosarak.Where(x => kosarak.Count(y => y.helyszin == x.helyszin) > 20).ToList().ConvertAll(x => $"{x.helyszin}: {kosarak.Count(y => y.helyszin == x.helyszin)}").Distinct())}");
        }
        class Kosar
        {
            public string hazai;
            public string idegen;
            public byte hazai_pont;
            public byte idegen_pont;
            public string helyszin;
            public short ev;
            public byte ho;
            public byte nap;
            public Kosar(string line)
            {
                if (line == "hazai;idegen;hazai_pont;idegen_pont;helyszín;időpont")
                    return;
                string[] tmp = line.Split(';');
                hazai = tmp[0];
                idegen = tmp[1];
                hazai_pont = byte.Parse(tmp[2]);
                idegen_pont = byte.Parse(tmp[3]);
                helyszin = tmp[4];
                string[] datum = tmp[5].Split('-');
                ev = short.Parse(datum[0]);
                ho = byte.Parse(datum[1]);
                nap = byte.Parse(datum[2]);
            }
            public bool Dontetlen()
            {
                return hazai_pont == idegen_pont;
            }
            public bool Jatszott(short _ev, byte _ho, byte _nap)
            {
                return (ev == _ev) && (ho == _ho) && (nap == _nap);
            }
        }
    }
    /// <summary> https://infojegyzet.hu/vizsgafeladatok/okj-programozas/szoftverfejleszto-200204/ </summary>
    class Balkezesek : Program
    {
        public static void Main()
        {
            // 2. Feladat
            List<Sportolo> sportolok = File.ReadAllLines("balkezesek.csv", Encoding.UTF8).ToList().ConvertAll(x => new Sportolo(x));
            sportolok.RemoveAt(0); // Fejléc
            // 3. Feladat
            Console.WriteLine($"3. feladat: {sportolok.Count}");
            // 4. Feladat
            Console.WriteLine($"4. feladat: \n\t{string.Join("\n\t", sportolok.Where(x => x.utolso.Year == 1999 && x.utolso.Month == 10).ToList().ConvertAll(x => $"{x.nev}, {Math.Round(x.magassag*2.54, 1)}{(Math.Round(x.magassag * 2.54, 1)%1==0 ? ",0":"")} cm"))}");
            // 5. Feladat
            Console.WriteLine($"5. feladat: ");
            TryInput<short>("Kérek egy 1990 és 1999 közötti évszámot!: ", predicate: x => x > 1990 && x < 1999, error_msg: "Hibás adat!");
            // 6. Feladat
            Console.WriteLine($"6. feladat: {Math.Round(sportolok.Average(x => x.suly), 2)} font");
        }
        class Sportolo
        {
            public string nev;
            public DateTime elso;
            public DateTime utolso;
            public byte suly;
            public byte magassag;
            public Sportolo(string line)
            {
                if (line == "név;első;utolsó;súly;magasság")
                    return;
                string[] tmp = line.Split(';');
                nev = tmp[0];
                string[] elso_s = tmp[1].Split('-');
                elso = new DateTime(year: short.Parse(elso_s[0]), month: byte.Parse(elso_s[1]), day: byte.Parse(elso_s[2]));
                string[] utolso_s = tmp[2].Split('-');
                utolso = new DateTime(year: short.Parse(utolso_s[0]), month: byte.Parse(utolso_s[1]), day: byte.Parse(utolso_s[2]));
                suly = byte.Parse(tmp[3]);
                magassag = byte.Parse(tmp[4]);
            }
        }
    }
    /// <summary> https://infojegyzet.hu/vizsgafeladatok/okj-programozas/szoftverfejleszto-190514/ </summary>
    class Fuvar : Program
    {
        public static void Main()
        {
            // 2. Feladat
            List<FuvAdat> adatok = File.ReadAllLines("fuvar.csv", Encoding.UTF8).ToList().ConvertAll(x => new FuvAdat(x));
            adatok.RemoveAt(0); // fejléc
            // 3. Feladat
            Console.WriteLine($"3. feladat: {adatok.Count} fuvar");
            // 4. Feladat
            Console.WriteLine($"4. feladat: {string.Join("\n\t", adatok.Where(x => x.azon == 6185).ToList().ConvertAll(x => $"{adatok.Where(x => x.azon == 6185).Count()} fuvar alatt: {x.borravalo+x.viteldij}").Distinct())}$");
            // 5. Feladat
            Console.WriteLine($"5. feladat: \n\t{string.Join("\n\t", adatok.ToList().ConvertAll(x => $"{x.fiz_mod}: {adatok.Count(y => y.fiz_mod == x.fiz_mod)} fuvar").Distinct())}");
            // 6. Feladat
            Console.WriteLine($"6. feladat: ");
            // 7. Feladat
            Console.WriteLine($"7. feladat: ");
        }
        class FuvAdat
        {
            public int azon;
            public DateTime indulas; //yyyy-mm-dd
            public int idotartam; //mp
            public double tavolsag; // mérföld
            public double viteldij; // dollár
            public double borravalo; // dollár
            public string fiz_mod;
            public FuvAdat(string line)
            {
                if (line == "taxi_id;indulas;idotartam;tavolsag;viteldij;borravalo;fizetes_modja")
                    return;
                string[] tmp = line.Split(';');
                azon = int.Parse(tmp[0]);
                string[] idopont = tmp[1].Split(' ');
                string[] datum = idopont[0].Split('-');
                string[] ido = idopont[1].Split(':');
                indulas = new DateTime(
                    year: short.Parse(datum[0]),
                    month: byte.Parse(datum[1]),
                    day: byte.Parse(datum[2]),
                    hour: byte.Parse(ido[0]),
                    minute: byte.Parse(ido[1]),
                    second: byte.Parse(ido[2])
                );
                idotartam = int.Parse(tmp[2]);
                tavolsag = double.Parse(tmp[3]);
                viteldij = double.Parse(tmp[4]);
                borravalo = double.Parse(tmp[5]);
                fiz_mod = tmp[6];
            }

        }
    }
}
