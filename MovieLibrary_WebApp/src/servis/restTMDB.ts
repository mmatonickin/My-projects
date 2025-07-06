import {  FilmI, FilmoviTmdbI, ZanrI } from "../zajednicko/tmdbI";
import { Request, Response} from "express";
import { TMDBklijent } from "./klijentTMDB.js";


export class RestTMDB {
    private tmdbKlijent: TMDBklijent;
    constructor(api_kljuc: string){
        this.tmdbKlijent = new TMDBklijent(api_kljuc);
        console.log(api_kljuc);
    }

    getFilmovi(zahtjev: Request, odgovor: Response) {
		console.log(this);
		odgovor.type("application/json");

		let stranica = zahtjev.query["stranica"];
		let trazi = decodeURIComponent(zahtjev.query["trazi"]as string || "");
		let appStranicenje = 5;

		if (
			stranica == null ||
			trazi == null ||
			typeof stranica != "string" ||
			typeof trazi != "string"
		) {
			odgovor.status(404);
			odgovor.send({ greska: "neocekivani podaci" });
			return;
		}
		const stranicaVrijednost = typeof stranica === "string" ? stranica : "1";
		this.tmdbKlijent
			.pretraziFilmovePoNazivu(trazi, Math.ceil((parseInt(stranicaVrijednost)* appStranicenje)/20))
			.then((filmovi: FilmoviTmdbI) => {
				const startIndex = ((parseInt(stranicaVrijednost)-1)* appStranicenje) % 20;
				const prilagođeniFilmovi = filmovi.results.slice(startIndex, startIndex + appStranicenje);
				const prilagođeneStranice = Math.ceil(filmovi.total_results / appStranicenje);
				odgovor.send({
					page: filmovi.page,
					results: prilagođeniFilmovi,
					total_results: filmovi.total_results,
					total_pages: prilagođeneStranice,
				});
				
			})
			.catch((greska) => {
				odgovor.json(greska);
			});
	}
	postFilmovi(zahtjev: Request, odgovor: Response) {
        odgovor.type("application/json");
        odgovor.status(405);
        let poruka = { greska: "zabranjena metoda"};
        odgovor.send(JSON.stringify(poruka));
      };
	putFilmovi(zahtjev: Request, odgovor: Response) {
        odgovor.type("application/json");
        odgovor.status(405);
        let poruka = { greska: "zabranjena metoda"};
        odgovor.send(JSON.stringify(poruka));
      };
	deleteFilmovi(zahtjev: Request, odgovor: Response) {
        odgovor.type("application/json");
        odgovor.status(405);
        let poruka = { greska: "zabranjena metoda"};
        odgovor.send(JSON.stringify(poruka));
      };
    
     getZanr (zahtjev: Request, odgovor: Response){
        console.log(this);
        odgovor.type("application/json");

        this.tmdbKlijent.dohvatiZanrove()
            .then((zanrovi: Array<ZanrI>) =>{
                odgovor.status(200).json(zanrovi);
            })
            .catch((greska) =>{
                odgovor.json(greska);
            });
     }

	postZanr(zahtjev: Request, odgovor: Response) {
        odgovor.type("application/json");
        odgovor.status(405);
        let poruka = { greska: "zabranjena metoda"};
        odgovor.send(JSON.stringify(poruka));
      };

	putZanr(zahtjev: Request, odgovor: Response) {
        odgovor.type("application/json");
        odgovor.status(405);
        let poruka = { greska: "zabranjena metoda"};
        odgovor.send(JSON.stringify(poruka));
      };
	deleteZanr(zahtjev: Request, odgovor: Response) {
        odgovor.type("application/json");
        odgovor.status(405);
        let poruka = { greska: "zabranjena metoda"};
        odgovor.send(JSON.stringify(poruka));
      };

	 getFilmNazivId(zahtjev: Request, odgovor: Response){
		odgovor.type("application/json");
		let filmId = zahtjev.query["id"];
		let stranica = zahtjev.query["stranica"];
		if (
			stranica == null ||
			filmId == null ||
			typeof stranica != "string" ||
			typeof filmId != "string"
		) {
			odgovor.status(404);
			odgovor.send({ greska: "neocekivani podaci" });
			return;
		}
		const stranicaVrijednost = parseInt(stranica, 10) || 1;
		this.tmdbKlijent.pretraziFilmPoId(filmId, stranicaVrijednost)
			.then((film: FilmI) =>{
			odgovor.status(200).send(JSON.stringify(film));
			})
			.catch((greska) =>{
				odgovor.json(greska);
			});

	 }
}