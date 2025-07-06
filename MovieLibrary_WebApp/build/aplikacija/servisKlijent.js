import * as kodovi from "../zajednicko/kodovi.js";
export class ServisKlijent {
    port;
    constructor(port) {
        this.port = port;
    }
    async dodajKorisnika(korisnik) {
        let tijelo = {
            name: korisnik.name,
            surname: korisnik.surname,
            email: korisnik.email,
            username: korisnik.username,
            password: kodovi.kreirajSHA256(korisnik.password, "moja sol"),
            role_id: 2
        };
        let zaglavlje = new Headers();
        zaglavlje.set("Content-Type", "application/json");
        let parametri = {
            method: 'POST',
            body: JSON.stringify(tijelo),
            headers: zaglavlje
        };
        let odgovor = await fetch("http://localhost:" + this.port + "/api/registracija", parametri);
        if (odgovor.status == 200) {
            console.log("Korisnik ubačen na servisu");
            return true;
        }
        else {
            const greska = await odgovor.text();
            console.log(odgovor.status);
            return { status: odgovor.status, data: greska };
        }
    }
    async prijaviKorisnika(korime, lozinka) {
        console.log(lozinka);
        let tijelo = {
            lozinka: lozinka
        };
        let zaglavlje = new Headers();
        zaglavlje.set("Content-Type", "application/json");
        let parametri = {
            method: 'POST',
            body: JSON.stringify(tijelo),
            headers: zaglavlje
        };
        let odgovor = await fetch("http://localhost:" + this.port + "/api/korisnici/" + korime + "/prijava", parametri);
        if (odgovor.status == 201) {
            return JSON.parse(await odgovor.text());
        }
        else {
            const greska = await odgovor.text();
            return { status: odgovor.status, data: greska };
        }
    }
    async dajFilmove(trazi, stranica) {
        let zaglavlje = new Headers();
        zaglavlje.set("Content-Type", "application/json");
        let parametri = {
            method: 'GET',
            headers: zaglavlje
        };
        let odgovor = await fetch("http://localhost" + this.port + "/api/tmdb/filmovi?trazi" + trazi + "&stranica" + stranica, parametri);
        if (odgovor.status == 201) {
            return JSON.parse(await odgovor.text());
        }
        else {
            return false;
        }
    }
}
