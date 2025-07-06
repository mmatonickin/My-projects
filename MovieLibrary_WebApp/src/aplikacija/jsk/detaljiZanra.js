let url ="http://" + window.location.hostname + ":" + citajRestPortIzKolacica();
let poruka = document.getElementById("poruka");
let sadrzajDiv = document.getElementById("sadrzaj");

window.addEventListener("load", async () => {
     poruka = document.getElementById("poruka");
     sadrzajDiv = document.getElementById("sadrzaj");
     await prikaziFilmovePoZanru();
     
});

async function dohvatiSveZanrove(){
    let parametri = {method: "GET"};
    let odgovor = await fetch (url + "/api/zanr", parametri);
    if (odgovor.status == 200){
        let podaci = await odgovor.text();
        let zanrovi = JSON.parse(podaci);
        return zanrovi;
    }
    return false;
}
async function dohvatiSveFilmove(zanr) {
	let odgovor = await fetch(url + "/api/tmdb/nasumceFilm?zanr=" + zanr);
	let podaci = await odgovor.text();
	let filmovi = JSON.parse(podaci);
	return filmovi;
}
async function dohvatiFilmovePoZanru(idZanr){
    let parametri = {method:"GET"};
    let odgovor = await fetch (url + `/api/zanr/${idZanr}`, parametri);
    if (odgovor.status == 200){
        let podaci = await odgovor.text();
        let filmovi = JSON.parse(podaci);
        return filmovi;
    }
    return [];
}
async function prikaziFilmovePoZanru(){
    let zanrovi = await dohvatiSveZanrove();
    if(!zanrovi || zanrovi.length == 0){
        poruka.innerHTML = "Nema dostupnih žanrova";
        return;
    }
    sadrzajDiv.innerHTML="";
    let currentPage=1;

    for(let zanr of zanrovi){
        let zanrId = zanr.id;
        let zanrNaziv = zanr.name;
        let filmZanra = await dohvatiFilmovePoZanru(zanrId);

        let zanrContainer = document.createElement("div");
        zanrContainer.className="zanrContainer";
        
        let naslov = document.createElement("h3");
        naslov.textContent=zanrNaziv;
        zanrContainer.appendChild(naslov);

        let lista = document.createElement("ul");
        if(filmZanra && filmZanra[zanrNaziv]){
            for(let film of filmZanra[zanrNaziv]){
                let listItem = document.createElement("li");
                let poveznica = document.createElement("a");
                poveznica.textContent = film.naziv_filma;
                poveznica.href =`/detaljiFilma?id=${film.id_filma}&stranica=${currentPage}`;
                console.log(filmZanra);
                listItem.appendChild(poveznica);
                lista.appendChild(listItem);
            }
        }else {
            let obavijest = document.createElement("p");
            obavijest.textContent="Nema filmova u ovom žanru";
            zanrContainer.appendChild(obavijest);
        }
        zanrContainer.appendChild(lista);
        sadrzajDiv.append(zanrContainer);
    }
}