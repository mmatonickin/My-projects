
function citajRestPortIzKolacica() {
	console.log(document.cookie);
	const cookies = document.cookie.split(";");
	for (let i = 0; i < cookies.length; i++) {
		const cookie = cookies[i].trim();
		if (cookie.startsWith("port=")) {
			return cookie.substring("port=".length);
		}
	}
	return null;
}



function prikaziStranicenje(str, ukupno, funkcijaZaDohvat) {
	let prikaz = document.getElementById("pagination");
	html = "";
	str = parseInt(str);
	if (str > 1) {
		html = '<button onClick="' + funkcijaZaDohvat + '(1)"><<</button>';
		html +=
			'<button onClick="' +
			funkcijaZaDohvat +
			"(" +
			(str - 1) +
			')"><</button>';
	}
	html +=
		'<button onClick="' +
		funkcijaZaDohvat +
		"(" +
		str +
		')">' +
		str +
		"/" +
		ukupno +
		"</button>";
	if (str < ukupno) {
		html +=
			'<button onClick="' +
			funkcijaZaDohvat +
			"(" +
			(str + 1) +
			')">></button>';
		html +=
			'<button onClick="' + funkcijaZaDohvat + "(" + ukupno + ')">>></button>';
	}
	prikaz.innerHTML = html;
}

