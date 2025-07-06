import express from "express";
import kolacici from "cookie-parser";
import {Konfiguracija} from "./zajednicko/konfiguracija.js";
import { __dirname, dajPort, dajPortServis } from "./zajednicko/esmPomocnik.js";
import {RestKorisnik} from "./servis/restKorisnik.js";
import { RestTMDB} from "./servis/restTMDB.js";
import {HtmlUpravitelj} from "./aplikacija/htmlUpravitelj.js"
import session from "express-session";
import cors from "cors";

const server = express();
server.use(
	cors({
		origin: function (origin, povratniPoziv) {
			console.log(origin);
			if (
				!origin ||
				origin.startsWith("http://spider.foi.hr:") ||
				origin.startsWith("http://localhost:")
			) {
				povratniPoziv(null, true);
			} else {
				povratniPoziv(new Error("Nije dozvoljeno zbog CORS"));
			}
		},
		optionsSuccessStatus: 200,
	})
);
let port = dajPortServis("mmatonick22");
if (process.argv[3] != undefined) {
	port = process.argv[3];
}

let konf = new Konfiguracija();
konf.ucitajKonfiguraciju()
    .then(pokreniServer)
    .catch((err) =>{
        if (process.argv.length == 2)
            console.error("Potrebno je dati naziv datoteke");
        else if (err.path != undefined)
            console.error("Nije moguće otvoriti datoteku" + err.path);
        else console.log(err.message);
    });

    function pokreniServer() {
        server.use(express.urlencoded({extended: true}));
        server.use(express.json());
        server.use(kolacici());
        server.use(
            session({
            secret: "alkasgjkldjjl5kdjkl78997843879sg",
            saveUninitialized:true,
            cookie: { 
                maxAge:  1000*60*60*3,
                secure: false,
                httpOnly: true,
                },
            resave: false
            })
        );
    server.use("/resursi", express.static(__dirname() + "/aplikacija/resursi"));
    server.use("/js", express.static(__dirname() + "/aplikacija/jsk"));
    server.use("/css", express.static(__dirname() + "/aplikacija/css"));

    pripremiPutanjeResursKorisnika();
    pripremiPutanjeResursTMDB();
    pripremiPutanjePocetna();
    pripremiPutanjeDetaljiFilma();
    pripremiPutanjeDodavanjeZanra();
    pripremiPutanjeAutentifikacija();
    pripremiPutanjeDetaljiZanra();
    pripremiPutanjeZanrovi();
    pripremiPutanjeDokumentacija();
	server.use((zahtjev, odgovor) => {
		odgovor.status(404);
		var poruka = { greska: "nepostojeći resurs" };
		odgovor.send(JSON.stringify(poruka));
	});

	server.listen(port, () => {
		console.log(`Server pokrenut na portu: ${port}`);
	});
}

function pripremiPutanjeResursKorisnika() {
    let restKorisnik = new RestKorisnik();
    server.get("/api/sesija", restKorisnik.getSesija.bind(restKorisnik));

    server.get("/api/korisnici", restKorisnik.getKorisnici.bind(restKorisnik));
    server.post("/api/korisnici", restKorisnik.postKorisnik.bind(restKorisnik));
    server.put("/api/korisnici", restKorisnik.putKorisnici.bind(restKorisnik));
    server.delete("/api/korisnici", restKorisnik.putKorisnici.bind(restKorisnik));

    server.get ("/api/korisnici/:korime", restKorisnik.getKorisnik.bind(restKorisnik));
    server.post("/api/korisnici/:korime", restKorisnik.postKorisniciKorime.bind(restKorisnik));
    server.put("/api/korisnici/:korime", restKorisnik.putKorisniciKorime.bind(restKorisnik));
    server.delete("/api/korisnici/:korime", restKorisnik.deleteKorisniciKorime.bind(restKorisnik));

    server.post("/api/registracija", restKorisnik.postKorisnikRegistracija.bind(restKorisnik));

    server.get ("/api/korisnici/:korime/prijava", restKorisnik.getKorisnikPrijava.bind(restKorisnik));
    server.post ("/api/korisnici/:korime/prijava", restKorisnik.postKorisnikPrijava.bind(restKorisnik));
    server.put ("/api/korisnici/:korime/prijava", restKorisnik.putKorisnikPrijava.bind(restKorisnik));
    server.delete ("/api/korisnici/:korime/prijava", restKorisnik.deleteKorisnikPrijava.bind(restKorisnik));

    server.get("/api/zanr", restKorisnik.getZanrovi.bind(restKorisnik));
    server.post("/api/zanr", restKorisnik.postZanrovi.bind(restKorisnik));
    server.put("/api/zanr", restKorisnik.putZanrovi.bind(restKorisnik));
    server.delete("/api/zanr", restKorisnik.deleteZanrovi.bind(restKorisnik));

    server.get("/api/zanr/:id", restKorisnik.getZanr.bind(restKorisnik));   
    server.post("/api/zanr/:id", restKorisnik.postZanR.bind(restKorisnik));
    server.put("/api/zanr/:id", restKorisnik.putZanr.bind(restKorisnik));
    server.delete("/api/zanr/:id", restKorisnik.deleteZanr.bind(restKorisnik));

    server.get("/api/zanr/:id/:id_film", restKorisnik.getZanrIdFilm.bind(restKorisnik));
    server.post("/api/zanr/:id/:id_film", restKorisnik.postZanr.bind(restKorisnik));
    server.put("/api/zanr/:id/:id_film", restKorisnik.putZanrIdFilm.bind(restKorisnik));
    server.delete("/api/zanr/:id/:id_film", restKorisnik.deleteZanrIdFilm.bind(restKorisnik));

    server.get("/api/film", restKorisnik.getFilm.bind(restKorisnik));
    server.post("/api/film", restKorisnik.postFilm.bind(restKorisnik));
    server.put("/api/film", restKorisnik.putFilm.bind(restKorisnik));
    server.delete("/api/film", restKorisnik.deleteFilm.bind(restKorisnik));

    server.get("/api/film/:id", restKorisnik.getFilmId.bind(restKorisnik));
    server.post("/api/film/:id", restKorisnik.postFilmId.bind(restKorisnik));
    server.put("/api/film/:id", restKorisnik.putFilmId.bind(restKorisnik));
    server.delete("/api/film/:id", restKorisnik.deleteFilmId.bind(restKorisnik));


    server.get("/api/zanr/filmovi/broj/:id", restKorisnik.getBrojFilmovaUZanru.bind(restKorisnik));
    server.get("/api/zanrovi/film/:id", restKorisnik.getZanrFilma.bind(restKorisnik));
    server.delete("/api/zanr/:id", restKorisnik.deleteZanr.bind(restKorisnik));
    server.post("/api/zanr", restKorisnik.postZanrovi.bind(restKorisnik));
    server.post("/api/zanr/:id/:id_film", restKorisnik.postZanr.bind(restKorisnik));
    server.get("/api/filmovi", restKorisnik.getFilmovi.bind(restKorisnik));
}

function pripremiPutanjeResursTMDB(){
    let restTMDB = new RestTMDB(konf.dajKonf()["tmdbApiKeyV3"]);
    server.get("/api/tmdb/filmovi", restTMDB.getFilmovi.bind(restTMDB));
    server.post("/api/tmdb/filmovi", restTMDB.postFilmovi.bind(restTMDB));
    server.put("/api/tmdb/filmovi", restTMDB.putFilmovi.bind(restTMDB));
    server.delete("/api/tmdb/filmovi", restTMDB.deleteFilmovi.bind(restTMDB));

    server.get("/api/tmdb/film/", restTMDB.getFilmNazivId.bind(restTMDB));

    server.get("/api/tmdb/zanr", restTMDB.getZanr.bind(restTMDB));
    server.post("/api/tmdb/zanr", restTMDB.postZanr.bind(restTMDB));
    server.put("/api/tmdb/zanr", restTMDB.putZanr.bind(restTMDB));
    server.delete("/api/tmdb/zanr", restTMDB.deleteZanr.bind(restTMDB));
}

function pripremiPutanjePocetna(){
    let htmlUpravitelj = new HtmlUpravitelj(port, konf.dajKonf().tajniKljucSesija);
    server.get("/", htmlUpravitelj.pocetna.bind(htmlUpravitelj));
}

function pripremiPutanjeDetaljiFilma(){
    let htmlUpravitelj = new HtmlUpravitelj(port, konf.dajKonf().tajniKljucSesija);
    server.get("/detaljiFilma", htmlUpravitelj.detaljiFilma.bind(htmlUpravitelj));
}

function pripremiPutanjeDodavanjeZanra(){
    let htmlUpravitelj = new HtmlUpravitelj(port, konf.dajKonf().tajniKljucSesija);
    server.get("/dodajZanrFilm/:id", htmlUpravitelj.dodajZanrFilm.bind(htmlUpravitelj));
}

function pripremiPutanjeDetaljiZanra(){
    let htmlUpravitelj = new HtmlUpravitelj(port, konf.dajKonf().tajniKljucSesija);
    server.get("/detaljZanr", htmlUpravitelj.detaljiZanra.bind(htmlUpravitelj));
}

function pripremiPutanjeZanrovi(){
    let htmlUpravitelj = new HtmlUpravitelj(port, konf.dajKonf().tajniKljucSesija);
    server.get("/zanrovi", htmlUpravitelj.zanrovi.bind(htmlUpravitelj));
}
function pripremiPutanjeDokumentacija(){
    let htmlUpravitelj = new HtmlUpravitelj(port, konf.dajKonf().tajniKljucSesija);
    server.get("/dokumentacija", htmlUpravitelj.dokumentacija.bind(htmlUpravitelj));
}

function pripremiPutanjeAutentifikacija(){
    let htmlUpravitelj = new HtmlUpravitelj(port, konf.dajKonf().tajniKljucSesija);
    server.get("/registracija", htmlUpravitelj.registracija.bind(htmlUpravitelj));
    server.post("/registracija", htmlUpravitelj.registracija.bind(htmlUpravitelj));
    server.get("/prijava", htmlUpravitelj.prijava.bind(htmlUpravitelj));
    server.post("/prijava", htmlUpravitelj.prijava.bind(htmlUpravitelj));
    server.get("/odjava", htmlUpravitelj.odjava.bind(htmlUpravitelj));
}





