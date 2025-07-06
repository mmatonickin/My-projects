import dsPromise from "fs/promises";
export class Konfiguracija {
    konf;
    constructor() {
        this.konf = this.initKonf();
    }
    initKonf() {
        return {
            tajniKljucSesija: "",
            tmdbApiKeyV3: "",
            tmdbApiKeyV4: ""
        };
    }
    dajKonf() {
        return this.konf;
    }
    async ucitajKonfiguraciju() {
        let putanja = process.argv[2];
        if (typeof putanja == "string") {
            let podaci = await dsPromise.readFile(putanja, { encoding: "utf-8" });
            this.pretvoriJSONkonfig(podaci);
            this.provjeriPodatkeKonfiguracije();
        }
        else {
            throw new Error("Niste definirali naziv konf datoteke!");
        }
        console.log(this.konf);
    }
    pretvoriJSONkonfig(podaci) {
        console.log(podaci);
        let konf = {};
        var nizPodataka = podaci.split("\n");
        for (let podatak of nizPodataka) {
            var podatakNiz = podatak.split("=");
            var naziv = podatakNiz[0];
            if (typeof naziv != "string" || naziv == "")
                continue;
            var vrijednost = podatakNiz[1] ?? "";
            konf[naziv] = vrijednost;
        }
        this.konf = konf;
    }
    provjeriPodatkeKonfiguracije() {
        if (this.konf.tmdbApiKeyV3 == undefined ||
            this.konf.tmdbApiKeyV3.trim() == "") {
            throw new Error("Fali TMDB API ključ u tmdbApiKeyV3");
        }
        if (this.konf.tmdbApiKeyV4 == undefined ||
            this.konf.tmdbApiKeyV4.trim() == "") {
            throw new Error("Fali TMDB API ključ u tmdbApiKeyV4");
        }
        if (this.konf.tajniKljucSesija == undefined ||
            this.konf.tajniKljucSesija.trim() == "") {
            throw new Error("Fali tajni kljuc sesija!");
        }
        if (this.konf.tmdbApiKeyV3.length != 32) {
            throw new Error("TMDB API ključ nema odgovarajući broj znakova u tmdbApiKeyV4");
        }
    }
}
