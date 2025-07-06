import "express-session";
import { KorisnikDAO } from "./korisnikDAO.js";
import { Zanrovi } from "../zajednicko/zanrovi.js";
import * as validacija from "../zajednicko/validacija.js";
import { kreirajSHA256 } from "../zajednicko/kodovi.js";
export class RestKorisnik {
    kdao;
    zanrovi;
    constructor() {
        this.kdao = new KorisnikDAO();
        this.zanrovi = new Zanrovi();
    }
    getSesija(zahtjev, odgovor) {
        odgovor.type("application/json");
        let sesija = zahtjev.session;
        if (sesija.korime && sesija.uloga == 2) {
            return odgovor.status(200).send(JSON.stringify({ prijavljen: true, admin: false }));
        }
        else if (sesija.korime && sesija.uloga == 1) {
            return odgovor.status(200).send(JSON.stringify({ prijavljen: true, admin: true }));
        }
        else {
            return odgovor.status(404).send(JSON.stringify({ prijavljen: false }));
        }
    }
    getKorisnici(zahtjev, odgovor) {
        odgovor.type("application/json");
        this.kdao.dajSve().then((korisnici) => {
            odgovor.status(200);
            console.log(korisnici);
            odgovor.send(JSON.stringify(korisnici));
        });
    }
    getKorisnik(zahtjev, odgovor) {
        odgovor.type("application/json");
        let korime = zahtjev.params["korime"];
        if (korime == undefined) {
            odgovor.status(400);
            odgovor.send(JSON.stringify({ greska: "Krivi podaci" }));
            return;
        }
        this.kdao.daj(korime).then((korisnik) => {
            console.log(korisnik);
            odgovor.status(200);
            odgovor.send(JSON.stringify(korisnik));
        });
    }
    postKorisnik = async (zahtjev, odgovor) => {
        odgovor.type("application/json");
        let korisnikPodaci = zahtjev.body;
        const { name, surname, email, username, password } = korisnikPodaci;
        let sesija = zahtjev.session;
        if (!sesija.uloga) {
            return odgovor.status(403).send(JSON.stringify({ greska: "Nedostatak prava" }));
        }
        if (!validacija.provjeriObaveznePodatke(name, surname, email, username, password)) {
            return odgovor.status(400).send(JSON.stringify({ greska: "Unesite podatke koji nedostaju" }));
        }
        if (!validacija.validirajEmail(email)) {
            return odgovor.status(400).send(JSON.stringify({ greska: "Email adresa nije u validnom formatu" }));
        }
        let korisnik = await this.kdao.daj(username);
        if (korisnik) {
            return odgovor.status(400).send(JSON.stringify({ greska: "Korisničko ime već postoji u bazi" }));
        }
        if (!validacija.validirajUsername(username)) {
            return odgovor.status(400).send(JSON.stringify({ greska: "Korisničko ime nije u validnom formatu. Dužina - najmanje 3 znaka. Dozvoljeni znakovi - mala slova i brojevi" }));
        }
        try {
            const hashedLozinka = kreirajSHA256(password, "moja sol");
            korisnikPodaci.password = hashedLozinka;
            this.kdao.dodaj(korisnikPodaci);
            return odgovor.status(201).send(JSON.stringify({ poruka: "Podaci dodani" }));
        }
        catch {
            return odgovor.status(500).send(JSON.stringify({ greska: "Pogreška prilikom dodavanja korisnika u bazu" }));
        }
    };
    putKorisnici(zahtjev, odgovor) {
        odgovor.type("application/json");
        odgovor.status(405);
        let poruka = { greska: "zabranjena metoda" };
        odgovor.send(JSON.stringify(poruka));
    }
    ;
    deleteKorisnici(zahtjev, odgovor) {
        odgovor.type("application/json");
        odgovor.status(405);
        let poruka = { greska: "zabranjena metoda" };
        odgovor.send(JSON.stringify(poruka));
    }
    ;
    postKorisniciKorime(zahtjev, odgovor) {
        odgovor.type("application/json");
        odgovor.status(405);
        let poruka = { greska: "zabranjena metoda" };
        odgovor.send(JSON.stringify(poruka));
    }
    ;
    putKorisniciKorime(zahtjev, odgovor) {
        odgovor.type("application/json");
        odgovor.status(405);
        let poruka = { greska: "zabranjena metoda" };
        odgovor.send(JSON.stringify(poruka));
    }
    ;
    deleteKorisniciKorime(zahtjev, odgovor) {
        odgovor.type("application/json");
        odgovor.status(405);
        let poruka = { greska: "zabranjena metoda" };
        odgovor.send(JSON.stringify(poruka));
    }
    ;
    postKorisnikRegistracija = async (zahtjev, odgovor) => {
        odgovor.type("application/json");
        let korisnikPodaci = zahtjev.body;
        const { name, surname, email, username, password } = korisnikPodaci;
        if (!validacija.provjeriObaveznePodatke(name, surname, email, username, password)) {
            return odgovor.status(400).send(JSON.stringify({ greska: "Unesite podatke koji nedostaju" }));
        }
        if (!validacija.validirajEmail(email)) {
            return odgovor.status(400).send(JSON.stringify({ greska: "Email adresa nije u validnom formatu" }));
        }
        let korisnik = await this.kdao.daj(username);
        if (korisnik) {
            return odgovor.status(400).send(JSON.stringify({ greska: "Korisničko ime već postoji u bazi" }));
        }
        if (!validacija.validirajUsername(username)) {
            return odgovor.status(400).send(JSON.stringify({ greska: "Korisničko ime nije u validnom formatu. Dužina - najmanje 3 znaka. Dozvoljeni znakovi - mala slova i brojevi" }));
        }
        try {
            this.kdao.dodaj(korisnikPodaci);
            return odgovor.status(200).send(JSON.stringify({ poruka: "Podaci dodani" }));
        }
        catch {
            return odgovor.status(500).send(JSON.stringify({ greska: "Pogreška prilikom dodavanja korisnika u bazu" }));
        }
    };
    postKorisnikPrijava(zahtjev, odgovor) {
        odgovor.type("application/json");
        let korime = zahtjev.params["korime"];
        if (korime == undefined) {
            odgovor.status(404);
            odgovor.send(JSON.stringify({ greska: "Unesite korisničko ime" }));
            return;
        }
        this.kdao.daj(korime).then((korisnik) => {
            if (korisnik != null) {
                const unesenaLozinka = zahtjev.body.lozinka;
                const hashedLozinka = kreirajSHA256(unesenaLozinka, "moja sol");
                if (korisnik.password === hashedLozinka) {
                    const sesija = zahtjev.session;
                    sesija.idKorisnik = korisnik.id;
                    sesija.korisnik = korisnik.name + " " + korisnik.surname;
                    sesija.korime = korisnik.username;
                    sesija.uloga = korisnik.role_id;
                    console.log("Podaci sesije:", zahtjev.session);
                    return odgovor.status(201).send(JSON.stringify(korisnik));
                }
                else {
                    return odgovor.status(404).send(JSON.stringify({ greska: "Krivi podaci" }));
                }
            }
            else {
                return odgovor.status(404).send(JSON.stringify({ greska: "Korisnik ne postoji" }));
            }
        });
    }
    getKorisnikPrijava(zahtjev, odgovor) {
        odgovor.type("application/json");
        odgovor.status(405);
        let poruka = { greska: "zabranjena metoda" };
        odgovor.send(JSON.stringify(poruka));
    }
    ;
    putKorisnikPrijava(zahtjev, odgovor) {
        odgovor.type("application/json");
        odgovor.status(405);
        let poruka = { greska: "zabranjena metoda" };
        odgovor.send(JSON.stringify(poruka));
    }
    ;
    deleteKorisnikPrijava(zahtjev, odgovor) {
        odgovor.type("application/json");
        odgovor.status(405);
        let poruka = { greska: "zabranjena metoda" };
        odgovor.send(JSON.stringify(poruka));
    }
    ;
    postZanrovi(zahtjev, odgovor) {
        odgovor.type("application/json");
        console.log(zahtjev.session);
        let zanr = zahtjev.body.name;
        let id = zahtjev.body.id;
        this.kdao.dajZanr(zanr).then((zanrBaza) => {
            if (!zanr || zanr.trim() === "") {
                return odgovor.send(JSON.stringify({ greska: "Nedostaje žanr, molimo unesite žanr" }));
            }
            if (!this.zanrovi.validanZanr(zanr)) {
                return odgovor.status(400).send(JSON.stringify({ greska: `Žanr nije validan` }));
            }
            if (zanr == zanrBaza?.name) {
                return odgovor.status(400).send(JSON.stringify({ greska: `Žanr '${zanr}' već postoji u bazi` }));
            }
            let sesija = zahtjev.session;
            if (sesija.uloga == 1) {
                console.log("dodavanje zanra", zanr);
                this.kdao.dodajZanr({ id: id, name: zanr });
                return odgovor.status(201).send(JSON.stringify({ message: `Žanr '${zanr}' je uspješno dodat` }));
            }
            else {
                console.log(sesija.korime);
                return odgovor.status(400).send(JSON.stringify({ greska: "Nemate dovoljno prava" }));
            }
        });
    }
    getZanrovi(zahtjev, odgovor) {
        let sesija = zahtjev.session;
        odgovor.type("application/json");
        this.kdao.dajSveZanrove().then((zanrovi) => {
            odgovor.status(200);
            console.log(zanrovi);
            console.log(sesija.uloga);
            odgovor.send(JSON.stringify(zanrovi));
        });
    }
    putZanrovi(zahtjev, odgovor) {
        odgovor.type("application/json");
        odgovor.status(405);
        let poruka = { greska: "zabranjena metoda" };
        odgovor.send(JSON.stringify(poruka));
    }
    ;
    deleteZanrovi(zahtjev, odgovor) {
        odgovor.type("application/json");
        odgovor.status(405);
        let poruka = { greska: "zabranjena metoda" };
        odgovor.send(JSON.stringify(poruka));
    }
    ;
    async getZanr(zahtjev, odgovor) {
        odgovor.type("application/json");
        let zanr = Number(zahtjev.params["id"]);
        let zanrBaza = await this.kdao.dajZanrId(zanr);
        console.log(zanr);
        if (zanr === zanrBaza?.id) {
            const rezultat = await this.kdao.dajZanrFilm(zanr);
            return odgovor.status(200).send(JSON.stringify(rezultat));
        }
        return odgovor.status(400).send(JSON.stringify({ greška: "Uneseni žanr ne nalazi se u bazi, shodno tome nema dostupnih filmova" }));
    }
    putZanr(zahtjev, odgovor) {
        odgovor.type("application/json");
        odgovor.status(405);
        let poruka = { greska: "zabranjena metoda" };
        odgovor.send(JSON.stringify(poruka));
    }
    ;
    postZanR(zahtjev, odgovor) {
        odgovor.type("application/json");
        odgovor.status(405);
        let poruka = { greska: "zabranjena metoda" };
        odgovor.send(JSON.stringify(poruka));
    }
    ;
    async getZanrFilma(zahtjev, odgovor) {
        odgovor.type("application/json");
        let film = Number(zahtjev.params["id"]);
        let filmBaza = await this.kdao.dajFilmId(film);
        console.log(film);
        if (film === filmBaza?.id) {
            console.log(filmBaza);
            const rezultat = await this.kdao.dajZanroveFilma(film);
            return odgovor.status(200).send(JSON.stringify(rezultat));
        }
        else {
            return odgovor.status(400).send(JSON.stringify({ greška: "Nema žanrova" }));
        }
    }
    async deleteZanr(zahtjev, odgovor) {
        let sesija = zahtjev.session;
        odgovor.type("application/json");
        let zanr = Number(zahtjev.params["id"]);
        let zanrBaza = await this.kdao.dajZanrId(zanr);
        if (sesija.uloga != 1) {
            return odgovor.status(403).send(JSON.stringify({ greška: "Nemate dovoljno prava" }));
        }
        if (isNaN(zanr)) {
            return odgovor.status(404).send(JSON.stringify({ greška: "Parametar žanr mora biti brojčanog tipa" }));
        }
        if (zanr == zanrBaza?.id) {
            const rezultat = await this.kdao.obrisiZanrbezFilma(zanr);
            if (rezultat)
                return odgovor.status(201).send(JSON.stringify({ poruka: "Obrisano" }));
        }
        if (zanr != zanrBaza?.id) {
            return odgovor.status(404).send(JSON.stringify({ greška: "Žanr koji želite obrisati ne postoji u bazi" }));
        }
        return odgovor.status(400).send(JSON.stringify({ greška: "Zabranjeno brisanje žanra koji sadrži filmove" }));
    }
    getZanrIdFilm(zahtjev, odgovor) {
        odgovor.type("application/json");
        odgovor.status(405);
        let poruka = { greska: "zabranjena metoda" };
        odgovor.send(JSON.stringify(poruka));
    }
    ;
    async postZanr(zahtjev, odgovor) {
        odgovor.type("application/json");
        let podaci = zahtjev.params;
        let zanrId = podaci["id"];
        let filmId = podaci["id_film"];
        let zanrIdNumber = Number(zanrId);
        let filmIdNumber = Number(filmId);
        let sesija = zahtjev.session;
        if (!sesija.uloga) {
            return odgovor.status(403).send(JSON.stringify({ greska: "Nedostatak prava" }));
        }
        if (isNaN(zanrIdNumber) || isNaN(filmIdNumber)) {
            return odgovor.status(400).send(JSON.stringify({ greska: "Unesite valjane parametre" }));
        }
        try {
            const filmZanr = {
                movie_id: filmIdNumber,
                genre_id: zanrIdNumber
            };
            this.kdao.dodajZanrFilm(filmZanr);
            return odgovor.status(201).send(JSON.stringify({ poruka: "Uspješno dodano" }));
        }
        catch (error) {
            if (error instanceof Error) {
                return odgovor.status(400).send(JSON.stringify({ greska: error.message }));
            }
            return odgovor.status(400).send(JSON.stringify({ greska: "Došlo je do nepoznate pogreške" }));
        }
    }
    putZanrIdFilm(zahtjev, odgovor) {
        odgovor.type("application/json");
        odgovor.status(405);
        let poruka = { greska: "zabranjena metoda" };
        odgovor.send(JSON.stringify(poruka));
    }
    ;
    deleteZanrIdFilm(zahtjev, odgovor) {
        odgovor.type("application/json");
        odgovor.status(405);
        let poruka = { greska: "zabranjena metoda" };
        odgovor.send(JSON.stringify(poruka));
    }
    ;
    async getBrojFilmovaUZanru(zahtjev, odgovor) {
        odgovor.type("application/json");
        let idZanra = Number(zahtjev.params["id"]);
        let zanroviUBazi = await this.kdao.dajSveZanrove();
        if (!zanroviUBazi || zanroviUBazi.length == 0) {
            return odgovor.status(400).send(JSON.stringify({ greska: "Greška prilikom dohvaćanja žanrova" }));
        }
        let zanrPronadjen = zanroviUBazi.find(zanr => zanr.id == idZanra);
        if (!zanrPronadjen) {
            return odgovor.status(404).send(JSON.stringify({ greska: "Uneseni žanr ne nalazi se u bazi" }));
        }
        let brojFlmova = await this.kdao.dajBrojFilmovaUZanru(idZanra);
        return odgovor.status(200).send(JSON.stringify(brojFlmova));
    }
    async getFilmId(zahtjev, odgovor) {
        odgovor.type("application/json");
        let podaci = Number(zahtjev.params["id"]);
        if (isNaN(podaci)) {
            return odgovor.status(400).send(JSON.stringify({ greška: "U parametar unesite brojčani tip podatka" }));
        }
        let filmBaza = await this.kdao.dajSveFilmoveId(podaci);
        if (podaci == filmBaza?.id) {
            return odgovor.status(200).send(JSON.stringify(filmBaza));
        }
        return odgovor.status(400).send(JSON.stringify({ greška: "Uneseni id fima ne postoji u bazi" }));
    }
    postFilmId(zahtjev, odgovor) {
        odgovor.type("application/json");
        odgovor.status(405);
        let poruka = { greska: "zabranjena metoda" };
        odgovor.send(JSON.stringify(poruka));
    }
    ;
    putFilmId(zahtjev, odgovor) {
        odgovor.type("application/json");
        odgovor.status(405);
        let poruka = { greska: "zabranjena metoda" };
        odgovor.send(JSON.stringify(poruka));
    }
    ;
    async deleteFilmId(zahtjev, odgovor) {
        odgovor.type("application/json");
        let idFilm = Number(zahtjev.params["id"]);
        let sesija = zahtjev.session;
        if (!sesija.uloga) {
            return odgovor.status(403).send(JSON.stringify({ greška: "Zabranjen pristup" }));
        }
        if (sesija.uloga != 1) {
            return odgovor.status(403).send(JSON.stringify({ greška: "Nemate dovoljno prava" }));
        }
        if (isNaN(idFilm)) {
            return odgovor.status(404).send(JSON.stringify({ greška: "Parametar zahtjeva brojčani unos" }));
        }
        let filmBaza = await this.kdao.dajFilmId(idFilm);
        if (filmBaza && idFilm == filmBaza.id) {
            this.kdao.obrisiFilm(idFilm);
            return odgovor.status(201).send(JSON.stringify({ poruka: `Film s ID-em '${idFilm}' je uspješno obrisan` }));
        }
        return odgovor.status(400).send(JSON.stringify({ greška: "Film koji pokušavate obrisati ne postoji u bazi" }));
    }
    async getFilmovi(zahtjev, odgovor) {
        odgovor.type("application/json");
        let filmBaza = await this.kdao.dajSveFilmove();
        if (filmBaza) {
            return odgovor.status(200).send(JSON.stringify({ filmBaza }));
        }
        return odgovor.status(400).send(JSON.stringify({ greška: "Greška u dohvatu podataka" }));
    }
    getFilm(zahtjev, odgovor) {
        odgovor.type("application/json");
        odgovor.status(405);
        let poruka = { greska: "zabranjena metoda" };
        odgovor.send(JSON.stringify(poruka));
    }
    ;
    async postFilm(zahtjev, odgovor) {
        odgovor.type("application/json");
        let podaci = zahtjev.body;
        let user_id = 1;
        podaci.user_id = user_id;
        console.log(podaci);
        let filmBaza = await this.kdao.dajSveFilmove();
        let postojiFilm = false;
        for (let film of filmBaza) {
            if (film.original_title === podaci.original_title ||
                film.title === podaci.title) {
                postojiFilm = true;
                break;
            }
        }
        if (postojiFilm) {
            return odgovor.status(400).send(JSON.stringify({ poruka: "Film s podacima koje želite dodati već postoji u bazi" }));
        }
        this.kdao.dodajFilm(podaci);
        return odgovor.status(201).send(JSON.stringify({ poruka: "Dodano" }));
    }
    putFilm(zahtjev, odgovor) {
        odgovor.type("application/json");
        odgovor.status(405);
        let poruka = { greska: "zabranjena metoda" };
        odgovor.send(JSON.stringify(poruka));
    }
    ;
    deleteFilm(zahtjev, odgovor) {
        odgovor.type("application/json");
        odgovor.status(405);
        let poruka = { greska: "zabranjena metoda" };
        odgovor.send(JSON.stringify(poruka));
    }
    ;
}
