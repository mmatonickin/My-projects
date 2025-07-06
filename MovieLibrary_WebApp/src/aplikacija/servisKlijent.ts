import { KorisnikI } from "src/zajednicko/korisnikI.js";
import * as kodovi from "../zajednicko/kodovi.js";
import { FilmI } from "src/zajednicko/tmdbI.js";

export class ServisKlijent {
    private port:number;

    constructor(port:number){
      this.port=port;
    }

    async dodajKorisnika(korisnik:{name:string, surname:string,email:string,username:string,password:string, role_id: number}) {
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
        }
        let odgovor = await fetch("http://localhost:" +this.port  + "/api/registracija", parametri)

        if (odgovor.status == 200) {
            console.log("Korisnik ubačen na servisu");
            return true;
        } else {
            const greska = await odgovor.text();
            console.log(odgovor.status);
            return {status: odgovor.status, data: greska};
        }
    }

    async prijaviKorisnika(korime:string, lozinka:string): Promise<KorisnikI | {status: number, data: string}>{
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
        }
        let odgovor = await fetch("http://localhost:"+this.port+"/api/korisnici/" + korime + "/prijava", parametri)

        if (odgovor.status == 201) {
            return JSON.parse(await odgovor.text()) as KorisnikI;
        } else {
            const greska = await odgovor.text();
            return {status: odgovor.status, data: greska};
        }
    }

    async dajFilmove(trazi: string, stranica: number): Promise<FilmI | false>{
        let zaglavlje = new Headers();
        zaglavlje.set("Content-Type", "application/json");
        let parametri = {
            method: 'GET',
            headers: zaglavlje
        };
        let odgovor = await fetch ("http://localhost"+this.port+"/api/tmdb/filmovi?trazi" + trazi + "&stranica" + stranica, parametri);
        if (odgovor.status == 201) {
            return JSON.parse(await odgovor.text()) as FilmI;
        } else {
            return false;
        }
    }
}

    
