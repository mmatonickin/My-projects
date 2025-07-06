import { __dirname } from "../zajednicko/esmPomocnik.js";
import ds from "fs/promises";
import { ServisKlijent } from "./servisKlijent.js";
import "express-session";
export class HtmlUpravitelj {
    port;
    servisKlijent;
    constructor(port) {
        this.port = port;
        this.servisKlijent = new ServisKlijent(port);
    }
    async pocetna(zahtjev, odgovor) {
        let pocetna = await this.ucitajStranicu("pocetna");
        odgovor.cookie("port", this.port, { httpOnly: false });
        odgovor.send(pocetna);
    }
    async dodajZanrFilm(zahtjev, odgovor) {
        let sesija = zahtjev.session;
        if (sesija.korime) {
            let zanrFilma = await this.ucitajStranicu("dodajZanrFilm");
            odgovor.cookie("port", this.port, { httpOnly: false });
            return odgovor.send(zanrFilma);
        }
        else {
            return odgovor.status(403).send(JSON.stringify({ greška: "Zabranjen pristup" }));
        }
    }
    async detaljiFilma(zahtjev, odgovor) {
        let sesija = zahtjev.session;
        if (sesija.korime) {
            let detaljiFilma = await this.ucitajStranicu("detaljiFilma");
            odgovor.cookie("port", this.port, { httpOnly: false });
            return odgovor.send(detaljiFilma);
        }
        else {
            return odgovor.status(403).send(JSON.stringify({ greška: "Zabranjen pristup" }));
        }
    }
    async zanrovi(zahtjev, odgovor) {
        let sesija = zahtjev.session;
        if (sesija.korime && sesija.uloga == 1) {
            let zanrovi = await this.ucitajStranicu("zanrovi");
            odgovor.cookie("port", this.port, { httpOnly: false });
            return odgovor.send(zanrovi);
        }
        else if (sesija.uloga == 2) {
            return odgovor.status(403).send(JSON.stringify({ greška: "Zabranjen pristup, nemate dovoljno prava" }));
        }
        else {
            return odgovor.status(403).send(JSON.stringify({ greška: "Zabranjen pristup" }));
        }
    }
    async detaljiZanra(zahtjev, odgovor) {
        let sesija = zahtjev.session;
        if (sesija.korime) {
            let detaljZanr = await this.ucitajStranicu("detaljZanr");
            odgovor.cookie("port", this.port, { httpOnly: false });
            return odgovor.send(detaljZanr);
        }
        else {
            return odgovor.status(403).send(JSON.stringify({ greška: "Zabranjen pristup" }));
        }
    }
    async registracija(zahtjev, odgovor) {
        console.log(zahtjev.body);
        let greska = "";
        if (zahtjev.method == "POST") {
            let rezultat = await this.servisKlijent.dodajKorisnika(zahtjev.body);
            odgovor.cookie("port", this.port, { httpOnly: false });
            console.log("status:", rezultat);
            if (rezultat == true) {
                odgovor.status(200).send({ preusmjeri: "/prijava" });
            }
            else {
                odgovor.status(rezultat.status).send(rezultat.data);
            }
            return;
        }
        let stranica = await this.ucitajStranicu("registracija", greska);
        odgovor.send(stranica);
    }
    async odjava(zahtjev, odgovor) {
        let sesija = zahtjev.session;
        sesija.korisnik = null;
        zahtjev.session.destroy((err) => {
            console.log("Sesija uništena! Error (ako ima je):" + err);
        });
        odgovor.redirect("/");
    }
    async prijava(zahtjev, odgovor) {
        let greska = "";
        if (zahtjev.method == "POST") {
            var korime = zahtjev.body.username;
            var lozinka = zahtjev.body.password;
            console.log(lozinka);
            console.log(korime);
            var rezultat = await this.servisKlijent.prijaviKorisnika(korime, lozinka);
            odgovor.cookie("port", this.port, { httpOnly: false });
            console.log(rezultat);
            if ("status" in rezultat) {
                return odgovor.status(rezultat.status).send(rezultat.data);
            }
            else {
                const korisnik = rezultat;
                const sesija = zahtjev.session;
                sesija.korisnik = korisnik.name + " " + korisnik.surname;
                sesija.korime = korisnik.username;
                sesija.uloga = korisnik.role_id;
                return odgovor.status(200).send({ preusmjeri: "/" });
            }
        }
        let stranica = await this.ucitajStranicu("prijava", greska);
        return odgovor.send(stranica);
    }
    async dokumentacija(zahtjev, odgovor) {
        let stranica = await this.ucitajStranicu("dokumentacija");
        odgovor.cookie("port", this.port, { httpOnly: false });
        odgovor.send(stranica);
    }
    async ucitajStranicu(nazivStranice, poruka = "") {
        let stranice = [
            this.ucitajHTML(nazivStranice),
            this.ucitajHTML("navigacija"),
        ];
        let [stranica, nav] = await Promise.all(stranice);
        if (stranica != undefined && nav != undefined) {
            stranica = stranica.replace("#navigacija#", nav);
            stranica = stranica.replace("#poruka#", poruka);
            return stranica;
        }
        return "";
    }
    ucitajHTML(htmlStranica) {
        return ds.readFile(__dirname() + "/html/" + htmlStranica + ".html", "utf-8");
    }
}
