let url ="http://" + window.location.hostname + ":" + citajRestPortIzKolacica();
let poruka = document.getElementById("poruka");
let naslov = document.getElementById("naslov");
let sadrzajDiv = document.getElementById("sadrzaj");
let zanrBazaDiv = document.getElementById("zanroviBaza");
let zanrTMDB = document.getElementById("zanroviTMDB");

window.addEventListener("load", async () => {
    poruka = document.getElementById("poruka");
    sadrzajDiv = document.getElementById("sadrzaj");
    naslov = document.getElementById("naslov");
    zanrBazaDiv = document.getElementById("zanroviBaza");
    zanrTMDB = document.getElementById("zanroviTMDB");
    naslov.innerHTML="Popis žanrova";
    await prikaziZanroveIzBaze();
    await prikaziZanroveTMDB();
});

async function dohvatiSveZanrove(){
    let parametri = {method: "GET"};
    let odgovor = await fetch (url + "/api/zanr", parametri);
    if (odgovor.status == 200){
        let podaci = await odgovor.text();
        let zanrovi = JSON.parse(podaci);
        console.log(zanrovi);
        return zanrovi;
    }
    return false;
}

async function prikaziZanroveTMDB(){
    let zanrovi = await dohvatiSveZanroveTMDB();
    let zanroviUBazi = await dohvatiSveZanrove();
    if(!zanrovi || zanrovi.length == 0){
        poruka.innerHTML = "Nema dostupnih žanrova";
        return;
    }
    zanrBazaDiv.innerHTML="<h3>Žanrovi iz TMDB</h3>";
    let lista = document.createElement("ul");

    for(let zanr of zanrovi){
        let listItem = document.createElement("li");
        listItem.textContent=zanr.name;
        listItem.style.display = "block";
        lista.appendChild(listItem);
        let zanrPostojiBaza = zanroviUBazi.some(zanrBaza => zanrBaza.id == zanr.id);
        if(!zanrPostojiBaza){
            let button = document.createElement("button");
            button.textContent = "Dodaj žanr";
            button.id=`dodavanjeZanra-${zanr.id}`;
            button.addEventListener("click", async () => {
                let uspjesno = await dodajZanr(zanr);
                if (uspjesno) {
                    button.disabled = true;
                    button.textContent = "Dodano";
                    window.scrollTo({
                        top: 0, 
                        behavior: "smooth"
                    });
                }
                window.scrollTo({
                    top: 0, 
                    behavior: "smooth"
                });
            });

            listItem.appendChild(button);
        }
    }
    zanrBazaDiv.appendChild(lista);
}

async function prikaziZanroveIzBaze(){
    let zanrovi = await dohvatiSveZanrove();
    if(!zanrovi || zanrovi.length == 0){
        poruka.innerHTML = "Nema dostupnih žanrova";
        return;
    }
    zanrTMDB.innerHTML="<h3>Žanrovi iz baze</h3>";
    let lista = document.createElement("ul");

    for(let zanr of zanrovi){
        let brojFilmova = await dohvatiBrojFilmovaUZanru(zanr.id);

        let listItem = document.createElement("li");
        let poveznica = document.createElement("a");
        let button = document.createElement("button");
        button.textContent="Obriši žanr"
        button.id=`brisanjeZanra-${zanr.id}`;

        button.addEventListener("click", async () => {
            let uspjesno = await brisiZanr(zanr.id);
            if (uspjesno) {
                listItem.remove();
                poruka.innerHTML = `Žanr "${zanr.name}" obrisan.`;
                await new Promise(resolve => setTimeout(resolve, 50));
                window.scrollTo({
                    top: 0, 
                    behavior: "smooth"
                });
            }
            window.scrollTo({
                top: 0, 
                behavior: "smooth"
            });
        });

        poveznica.href=`/detaljZanr`;
        poveznica.textContent=`${zanr.name} (${brojFilmova || 0} filmova)`;
        poveznica.style.display = "block";
        lista.appendChild(listItem);
        listItem.appendChild(poveznica);
        listItem.appendChild(button);
    }
    zanrTMDB.appendChild(lista);
}

async function dohvatiSveZanroveTMDB(){
    let parametri = {method: "GET"};
    let odgovor = await fetch (url + "/api/tmdb/zanr", parametri);
    if (odgovor.status == 200){
        let zanrovi = await odgovor.json();
        console.log(zanrovi);
        return zanrovi;
    }
    return false;
}

async function dohvatiBrojFilmovaUZanru(idZanr){
    let parametri = {method: "GET"};
    let odgovor = await fetch (url + `/api/zanr/filmovi/broj/${idZanr}`, parametri);
    if (odgovor.status == 200){
        let brojFilmova = await odgovor.json();
        return brojFilmova;
    }
    return false;
}

async function brisiZanr(idZanr){
    let parametri={method:"DELETE"};
    let odgovor = await fetch (url + `/api/zanr/${idZanr}`, parametri);
    if (odgovor.status == 201){
        let podaci = await odgovor.text();
        console.log(podaci);
        poruka.innerHTML="Žanr obrisan";
        return true;
    } else if (odgovor.status == 400){
        poruka.innerHTML="Zabranjeno brisanje žanra koji sadrži filmove";
        return false;
    } else
        poruka.innerHTML="Greška prilikom brisanja žanra";
        return false;
}

async function dodajZanr(zanrTMDB){
    let parametri = {method:"POST",
                    body: JSON.stringify(zanrTMDB),
                    headers: {
                        'Content-Type': 'application/json',
                            }
                    }
    let odgovor = await fetch (url + "/api/zanr", parametri);
    if(odgovor.status == 201){
        poruka.innerHTML="Žanr je dodan u bazu";
        return true;
    }else if (odgovor.status == 400){
        poruka.innerHTML="Žanr već postoji u bazi";
        return false;
    }else{
        poruka.innerHTML="Greška prilikom upisa u bazu";
        return false;
    }
}

