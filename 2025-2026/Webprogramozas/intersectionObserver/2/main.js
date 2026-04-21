// alert("betöltött a js fájl :D")
const dobozok = document.querySelectorAll(".doboz")

// console.log(dobozok); 
const megfigyelo = new IntersectionObserver( (elemek) => {
    elemek.forEach( elem => {

        if (elem.isIntersecting) { // ha látszik a képernyőn

            elem.target.classList.add("animacio") // kék színű lesz
            elem.target.innerText = "Nice man"

        } else {

            elem.target.classList.remove("animacio") // ha nem látszik, legyen megint lila
            elem.target.innerText = "Nig-"

        }

    })
}, { threshold: 0.5 } )

dobozok.forEach( doboz => {
    megfigyelo.observe( doboz )
})
