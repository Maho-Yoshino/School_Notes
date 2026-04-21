document.addEventListener("DOMContentLoaded", () => {
	const bodyTag = document.body
	const darkMode = localStorage.getItem("darkmode")
	if (darkMode == "true") {
		bodyTag.classList.add("sotet")
	}
	const temaGomb = document.getElementById("temaGomb")
	temaGomb.onclick = () => {
		bodyTag.classList.toggle("sotet")
		localStorage.setItem("darkmode", bodyTag.classList.contains("sotet"))
	}
})