import dsPromise from "fs/promises";

type tipKonf ={
    tajniKljucSesija: string;
    tmdbApiKeyV3: string;
    tmdbApiKeyV4: string;
};

export class Konfiguracija {
    private konf: tipKonf;
    public constructor () {
        this.konf = this.initKonf();
    }

    private initKonf() {
        return {
            tajniKljucSesija: "",
            tmdbApiKeyV3: "",
            tmdbApiKeyV4: ""
        };
    }
    public dajKonf() {
        return this.konf;
    }
    public async ucitajKonfiguraciju() {
		let putanja: string | undefined = process.argv[2];
		if (typeof putanja == "string") {
			let podaci = await dsPromise.readFile(putanja, { encoding: "utf-8" });
			this.pretvoriJSONkonfig(podaci);
			this.provjeriPodatkeKonfiguracije();
		} else {
			throw new Error("Niste definirali naziv konf datoteke!");
		}

		console.log(this.konf);
	}

	private pretvoriJSONkonfig(podaci: string) {
		console.log(podaci);
		let konf: { [kljuc: string]: string } = {};
		var nizPodataka = podaci.split("\n");
		for (let podatak of nizPodataka) {
			var podatakNiz = podatak.split("=");
			var naziv = podatakNiz[0];
			if (typeof naziv != "string" || naziv == "") continue;
			var vrijednost: string = podatakNiz[1] ?? "";
			konf[naziv] = vrijednost;
		}
		this.konf = konf as tipKonf;
	}

	private provjeriPodatkeKonfiguracije() {
		if (
			this.konf.tmdbApiKeyV3 == undefined ||
			this.konf.tmdbApiKeyV3.trim() == ""
		) {
			throw new Error("Fali TMDB API ključ u tmdbApiKeyV3");
		}
		if (
			this.konf.tmdbApiKeyV4 == undefined ||
			this.konf.tmdbApiKeyV4.trim() == ""
		) {
			throw new Error("Fali TMDB API ključ u tmdbApiKeyV4");
		}
		if (
			this.konf.tajniKljucSesija == undefined ||
			this.konf.tajniKljucSesija.trim() == ""
		) {
			throw new Error("Fali tajni kljuc sesija!");
		}
        if (this.konf.tmdbApiKeyV3.length != 32) {
            throw new Error ("TMDB API ključ nema odgovarajući broj znakova u tmdbApiKeyV4")
        }
    }
}