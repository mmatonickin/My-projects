let url ="http://" + window.location.hostname + ":" + citajRestPortIzKolacica();
let poruka = document.getElementById("poruka");

window.addEventListener("load", async () => {
    poruka = document.getElementById("poruka");

    document.getElementById("dodajZanrove").addEventListener("click", async () => {
        const pohranjeniFilm = JSON.parse(sessionStorage.filmDodavanjeZanra || null);
        const idFilm = pohranjeniFilm.id;
        const checkboxes = document.querySelectorAll("#zanrovi input[type='checkbox']:checked:not(:disabled)");

        if (!idFilm) {
            poruka.innerHTML = "Greška: ID filma nije naveden u URL-u.";
            return;
        }

        if (checkboxes.length === 0) {
            poruka.innerHTML = "Nema novih žanrova za dodavanje.";
            return;
        }
        let uspjesnoDodani = 0;
        let greske = 0;

        for (let checkbox of checkboxes) {
            const idZanr = checkbox.value;
            const rezultat = await dodajZanruFilm(idZanr, idFilm);
            if (rezultat) {
                uspjesnoDodani++;
                checkbox.disabled=true;
            } else {
                greske++;
            }
        }

        if (uspjesnoDodani > 0) {
            poruka.innerHTML = `Broj dodanih žanrova: ${uspjesnoDodani}.`;
        }

        if (greske > 0) {
            poruka.innerHTML += ` Greška prilikom dodavanja ${greske} žanrova.`;
        }
    });

    const pohranjeniFilm = JSON.parse(sessionStorage.filmDodavanjeZanra || null);
    const idFilm = pohranjeniFilm.id;
    const film = await dohvatiFilmId(idFilm);
    if (film) {
        document.getElementById("naslov").innerHTML = `<h2>${film.title}</h2>`;
    } else {
        poruka.innerHTML = "Greška: Film nije pronađen.";
    }

    const zanrovi = await dohvatiSveZanrove();
    prikaziZanrove(zanrovi, idFilm);
});


async function dohvatiFilmId(idFilm){
    let parametri={ method: "GET", 
                    headers: {
                    'Content-Type': 'application/json',
                         }
                    };
    let odgovor = await fetch (url + `/api/film/${idFilm}`, parametri);
    if (odgovor.status == 200){
        let podaci = await odgovor.text();
        let film = JSON.parse(podaci);
        return film;
    } else {
        return false;
    }
}
async function dohvatiSveZanrove(){
    let parametri = {method:"GET"};
    let odgovor = await fetch (url + "/api/zanr", parametri);
    if (odgovor.status == 200){
        let podaci = await odgovor.text();
        let zanrovi = JSON.parse(podaci);
        return zanrovi;
    } else {
        return [];
    }
}

async function prikaziZanrove(zanrovi, idFilm) {
    const zanroviDiv = document.getElementById("zanrovi");
    zanroviDiv.innerHTML = "";
    const zanroviFilma = await dohvatiZanroveFilma(idFilm);

    for (let zanr of zanrovi) {
        let checkbox = document.createElement("input");
        checkbox.type = "checkbox";
        checkbox.id = `zanr-${zanr.id}`;
        checkbox.value = zanr.id;

        if(zanroviFilma.some(z => z.id === zanr.id)){
            checkbox.checked=true;
            checkbox.disabled=true;
        }

        let label = document.createElement("label");
        label.htmlFor = `zanr-${zanr.id}`;
        label.textContent = zanr.name;

        let div = document.createElement("div");
        div.appendChild(checkbox);
        div.appendChild(label);

        zanroviDiv.appendChild(div);
    }
}


async function dohvatiZanroveFilma(idFilm){
    let parametri = {method: "GET"};
    let odgovor = await fetch(url + `/api/zanrovi/film/${idFilm}`, parametri);
    if (odgovor.status==200){
        let podaci = await odgovor.text();
        let zanroviFilma = JSON.parse(podaci);
        return zanroviFilma;
    }
    return [];
}
async function dodajZanruFilm(idZanr, idFilm){
    let parametri={ method: "POST", 
                    headers: {
                    'Content-Type': 'application/json',
                    }
                    };
    let odgovor = await fetch(url + `/api/zanr/${idZanr}/${idFilm}`, parametri);
    if(odgovor.status == 201){
        let podaci = await odgovor.text();
        console.log(podaci);
        return true;
    } else 
        return false;
}

