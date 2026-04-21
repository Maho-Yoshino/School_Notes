var gomb = document.getElementById("gomg");
var kep = document.getElementById("kep");

gomb.onclick = function() {
	fetch("https://dog.ceo/api/breeds/image/random")
		.then(response => response.json()) 
		.then(data => {
			kep.src = data.message;
		})
		.catch(error => {
			alert(error);
			console.error('Hiba történt:', error)
		});
}