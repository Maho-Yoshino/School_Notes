const dobozok = document.getElementsByClassName("doboz")

const observer = new IntersectionObserver(
	(entries) => {
		entries.forEach((entry) => {
			if (entry.isIntersecting) {
				console.log(entry)
				entry.target.style.backgroundColor = "#F00"
			}
		})
	}
)

for (const doboz of dobozok) {
	observer.observe(doboz)
}
