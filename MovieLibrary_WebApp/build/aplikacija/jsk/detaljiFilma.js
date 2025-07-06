let url ="http://" + window.location.hostname + ":" + citajRestPortIzKolacica();
let prijavljen = false;
let administrator = false;
let poruka = document.getElementById("poruka");
let dodajBazaDiv = document.getElementById("dodajBaza");
let obrisiDiv = document.getElementById("obrisiFilm");
let dodajZanrDiv = document.getElementById("dodajZanr");
window.addEventListener("load", async () => {
    provjeriSesiju();

    poruka = document.getElementById("poruka");
    dodajBazaDiv = document.getElementById("dodajBaza");
    obrisiDiv = document.getElementById("obrisiFilm");
    dodajZanrDiv = document.getElementById("dodajZanr");

    const params = new URLSearchParams(window.location.search);
    const filmId = decodeURIComponent(params.get("id"));
    const filmovi = JSON.parse(sessionStorage.dohvaceniFilmovi || '[]');
    const odabraniFilm = filmovi.find(film => film.id === parseInt(filmId, 10));
    const filmBaza = await filmoviBaza(filmId);
    console.log(filmId);
    sessionStorage.filmDodavanjeZanra = JSON.stringify(filmBaza);
    if (filmBaza){
        document.getElementById("naslov").innerText = filmBaza.title;
        document.getElementById("poruka").innerText = "Detalji o odabranom filmu:";
        document.getElementById("sadrzaj").innerHTML = `
            <img src="https://image.tmdb.org/t/p/w600_and_h900_bestv2/${filmBaza.poster_path}" 
                 alt="Poster filma" width="300"/>
            <p><strong>Opis:</strong> ${filmBaza.overview || 'Nema opisa dostupnog.'}</p>
            <p><strong>Datum izlaska:</strong> ${filmBaza.release_date || 'Nepoznato'}</p>
            <p><strong>Ocjena:</strong> ${filmBaza.vote_average || 'N/A'}</p>
            <p><strong>Žanrovi:</strong> ${filmBaza.zanrovi.length > 0 ? filmBaza.zanrovi.join(", ") : 'NEMA ŽANROVA'}</p>`;
            document.getElementById("dodajZanr").innerHTML =`<button id="zanrovi">Dodaj žanrove</button>`;
            if(administrator){
                obrisiDiv.innerHTML=`<button id="obrisi">Obriši film</button>`;
            }
            if(administrator){
                document.getElementById("obrisi").addEventListener("click", async(event) =>{
                    await obrisiFilm(filmBaza.id);
                });
            }
            document.getElementById("zanrovi").addEventListener("click", async(event) =>{
                window.location.href= `/dodajZanrFilm/${filmBaza.id}`;
            });

    } else if (odabraniFilm) {
        document.getElementById("naslov").innerText = odabraniFilm.title;
        document.getElementById("poruka").innerText = "Detalji o odabranom filmu:";
        document.getElementById("sadrzaj").innerHTML = `
            <img src="https://image.tmdb.org/t/p/w600_and_h900_bestv2/${odabraniFilm.poster_path}" 
                 alt="Poster filma" width="200" />
            <p><strong>Opis:</strong> ${odabraniFilm.overview || 'Nema opisa dostupnog.'}</p>
            <p><strong>Datum izlaska:</strong> ${odabraniFilm.release_date || 'Nepoznato'}</p>
            <p><strong>Ocjena:</strong> ${odabraniFilm.vote_average || 'N/A'}</p>`;
        document.getElementById("dodajBaza").innerHTML = `<button id="dodajUBazu">Dodaj u bazu</button>`;
        console.log(administrator);
    } else {
        document.getElementById("poruka").innerText = "Film nije pronađen.";
        document.getElementById("sadrzaj").innerHTML = `
            <p>Nažalost, nismo mogli pronaći detalje o filmu. Vratite se na početnu stranicu i pokušajte ponovno.</p>`;
    }
    document.getElementById("dodajBaza").addEventListener("click", async (event) => {
        console.log(odabraniFilm);
        dodajUBazu(odabraniFilm)
    .then((uspesnoDodano) => {
        if (uspesnoDodano) {
            console.log("Film je uspešno dodat u bazu.");
            window.location.reload();
        } else {
            console.error("Dodavanje filma u bazu nije uspelo.");
        }
    })
    .catch((error) => {
        console.error("Greška prilikom dodavanja filma:", error);
    });

    });
});

    async function provjeriSesiju() {
        let parametri = { method: "GET" };
        try {
            let odgovor = await fetch(url + "/api/sesija", parametri);
            if (odgovor.ok) { 
                let podaci = await odgovor.json();     
                prijavljen = podaci.prijavljen || false;
                administrator = podaci.admin || false;
    
                console.log("Sesija:", podaci); 
            } else {
                prijavljen = false;
                administrator = false;
                console.warn("Korisnik nije prijavljen.");
            }
        } catch (error) {
            console.error("Greška prilikom provjere sesije:", error);
            prijavljen = false;
            administrator = false;
        }
    }

async function filmoviBaza(filmId){
    let parametri = {method: "GET"}
    let odgovor = await fetch (url + "/api/filmovi", parametri);
    if (odgovor.status == 200){
        let filmoviBaza = await odgovor.text();
        filmoviBaza = JSON.parse(filmoviBaza);
        let filmIzBazePostoji = filmoviBaza.filmBaza.find(film => Number(film.id) === Number(filmId));

        if (filmIzBazePostoji){
            console.log(filmIzBazePostoji);
            filmIzBazePostoji.zanrovi = (await dohvatiZanrove(filmIzBazePostoji.id)).map(zanr => zanr.name);
            return filmIzBazePostoji;
        }
    }else{
        return false;
    }
}

async function dodajUBazu(odabraniFilm) {
    let parametri = { method: "POST", body: JSON.stringify(odabraniFilm),headers: {'Content-Type': 'application/json',}};
    if (odabraniFilm.original_title){
        let odgovor = await fetch (url + "/api/film", parametri);
        if(odgovor.status){
            let podaci = await odgovor.text();
            console.log(podaci);
            poruka.innerHTML="Film dodan u bazu";
            return true;
        }else if (odgovor.status == 400){
            poruka.innerHTML="Film koji pokušavate dodati već postoji u bazi";
            return false;
        }else{
            poruka.innerHTML="Greška u dodavanju filma";
            return false;
        }
    }
}

async function dohvatiZanrove(idFilm){
    let parametri = {method: "GET",
                    headers: {
                    'Content-Type': 'application/json',
                        }
                    }
    let odgovor = await fetch (url + `/api/zanrovi/film/${idFilm}`, parametri);
    let podaci = await odgovor.json();
    if (odgovor.status == 200){
        return podaci;
    } else{
        return null;
    }
}

async function obrisiFilm(idFilm){
    let parametri = {method: "DELETE",
                    headers: {
                    'Content-Type': 'application/json',
                        }
                    }
    let odgovor = await fetch (url + `/api/film/${idFilm}`, parametri);
    if (odgovor.status == 201){
        window.location.href = "/";
    } else {
        return false;
    }
}


