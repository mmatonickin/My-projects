let prijavljen = false;
let administrator = false;
let url ="http://" + window.location.hostname + ":" + citajRestPortIzKolacica();

document.addEventListener("DOMContentLoaded", () => {
    let poruka = document.getElementById("poruka");
    let searchInput = document.getElementById('searchInput');
    let resultsDiv = document.getElementById('results');
    let currentPageSpan = document.getElementById('currentPage');
    let totalRes = document.getElementById("totalResults");
    let prevPageBtn = document.getElementById('prevPage');
    let nextPageBtn = document.getElementById('nextPage');
    let currentPage = 1;
    let totalPages = 0;
    let totalResults = 0;



    window.addEventListener("load", async () => {
        poruka = document.getElementById("poruka");
        dajFilmove(1);
        provjeriSesiju();
        document.getElementById("searchInput").addEventListener("keyup", (event) => {
            if(dajFilter().length> 3)
            dajFilmove(1);
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

    async function dajFilmove(str) {
        let parametri = { method: "GET" };
        let odgovor = await fetch(
            url + "/api/tmdb/filmovi?stranica=" + str + "&trazi=" + dajFilter(),
            parametri
        );
        if (odgovor.status == 200) {
            let podaci = await odgovor.text();
            podaci = JSON.parse(podaci);
            prikaziFilmove(podaci.results);

            if(podaci.total_pages > 0){
                totalPages = podaci.total_pages;
                totalResults = podaci.total_results;
                azurirajPaginaciju();
            }
        } else {
            poruka.innerHTML = "Greška u dohvatu filmova!";
        }
    }

    function prikaziFilmove(filmovi) {
        const resultsDiv = document.getElementById('results');
        let tablica = "<table border=1>";
        tablica += "<tr><th>Naslov</th><th>Poster</th></tr>"

        if (filmovi.length === 0) {
            resultsDiv.innerHTML = "<p>Nema rezultata</p>";
            return;
        }
        filmovi.forEach(film => {
            tablica += "<tr>";
            if (administrator || prijavljen){
                tablica += `<td><a href="/detaljiFilma?id=${film.id}&stranica=${currentPage}">${film.title}</a></td>`;
            } else{
            tablica += "<td>" + film.original_title + "</td>";
            }
            tablica +=
			"<td><img src='https://image.tmdb.org/t/p/w600_and_h900_bestv2/" +
			film.poster_path +
			"' width='100' alt='slika_" +
			film.title +
			"'/></td>";
            tablica += "</tr>";
        });
        tablica += "</table>";
        sessionStorage.dohvaceniFilmovi = JSON.stringify(filmovi);
        resultsDiv.innerHTML = tablica;
        console.log(prijavljen);
    }

    function azurirajPaginaciju() {
        currentPageSpan.textContent = `Stranica: ${currentPage}/${totalPages}`;
        prevPageBtn.disabled = currentPage === 1;
        nextPageBtn.disabled = currentPage === totalPages;
    }

    searchInput.addEventListener('input', (event) => {
        if (dajFilter().length >= 3) {
            currentPage = 1; 
            dajFilmove(currentPage);
        } else {
            resultsDiv.innerHTML = '';
            totalPages = 0;
            azurirajPaginaciju();
        }
    });

    prevPageBtn.addEventListener("click", () => {
        if (currentPage > 1) {
            currentPage--;
            dajFilmove(currentPage);
        }
    });

    nextPageBtn.addEventListener("click", () => {
        if (currentPage < totalPages) {
            currentPage++;
            dajFilmove(currentPage);
        }
    });

});

function dajFilter() {
    return document.getElementById("searchInput").value;
}


