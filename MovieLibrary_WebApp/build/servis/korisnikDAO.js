import Baza from "../zajednicko/sqliteBaza.js";
export class KorisnikDAO {
    baza;
    constructor() {
        this.baza = new Baza("podaci/RWA2024mmatonick22.sqlite");
    }
    async dajSve() {
        let sql = "SELECT * FROM user;";
        var podaci = await this.baza.dajPodatkePromise(sql, []);
        let rezultat = new Array();
        for (let p of podaci) {
            let k = { id: p["id"], name: p["name"], surname: p["surname"], username: p["username"], password: p["password"], email: p["email"], role_id: p["role_id"] };
            rezultat.push(k);
        }
        return rezultat;
    }
    async dajSveFilmove() {
        let sql = "SELECT * FROM movie;";
        var podaci = await this.baza.dajPodatkePromise(sql, []);
        let rezultat = new Array();
        for (let p of podaci) {
            let k = { id: p["id"], adult: p["adult"], backdrop_path: p["backdrop_path"], original_language: p["original_language"], original_title: p["original_title"], overview: p["overview"], popularity: p["popularity"],
                poster_path: p["poster_path"], release_date: p["release_date"], title: p["title"], video: p["video"], vote_average: p["vote_average"],
                vote_count: p["vote_count"], user_id: p["user_id"] };
            rezultat.push(k);
        }
        return rezultat;
    }
    async dajSveFilmoveId(id) {
        let sql = "SELECT * FROM movie WHERE id = ?;";
        var podaci = await this.baza.dajPodatkePromise(sql, [id]);
        if (podaci.length === 1 && podaci[0] !== undefined) {
            let p = podaci[0];
            let k = {
                id: p["id"],
                adult: p["adult"],
                backdrop_path: p["backdrop_path"],
                original_language: p["original_language"],
                original_title: p["original_title"],
                overview: p["overview"],
                popularity: p["popularity"],
                poster_path: p["poster_path"],
                release_date: p["release_date"],
                title: p["title"],
                video: p["video"],
                vote_average: p["vote_average"],
                vote_count: p["vote_count"],
                user_id: p["user_id"]
            };
            return k;
        }
        return null;
    }
    async daj(korime) {
        let sql = "SELECT * FROM user WHERE username=?;";
        var podaci = await this.baza.dajPodatkePromise(sql, [korime]);
        if (podaci.length == 1 && podaci[0] != undefined) {
            let p = podaci[0];
            let k = { id: p["id"], name: p["name"], surname: p["surname"], username: p["username"], password: p["password"], email: p["email"], role_id: p["role_id"] };
            return k;
        }
        return null;
    }
    async dajZanr(name) {
        let sql = "SELECT * FROM genre WHERE name=?;";
        var podaci = await this.baza.dajPodatkePromise(sql, [name]);
        if (podaci.length == 1 && podaci[0] != undefined) {
            let p = podaci[0];
            let k = { id: p["id"], name: p["name"] };
            return k;
        }
        return null;
    }
    async dajZanrId(id) {
        let sql = "SELECT * FROM genre WHERE id=?;";
        var podaci = await this.baza.dajPodatkePromise(sql, [id]);
        if (podaci.length == 1 && podaci[0] != undefined) {
            let p = podaci[0];
            let k = { id: p["id"], name: p["name"] };
            return k;
        }
        return null;
    }
    async dajFilmId(id) {
        let sql = "SELECT * FROM movie WHERE id=?;";
        var podaci = await this.baza.dajPodatkePromise(sql, [id]);
        if (podaci.length == 1 && podaci[0] != undefined) {
            let p = podaci[0];
            let k = { id: p["id"], title: p["title"] };
            return k;
        }
        return null;
    }
    dodaj(korisnik) {
        console.log(korisnik);
        let sql = `INSERT INTO user (name,surname,email,username,password,role_id) VALUES (?,?,?,?,?,?)`;
        let podaci = [korisnik.name,
            korisnik.surname,
            korisnik.email,
            korisnik.username,
            korisnik.password,
            2];
        this.baza.ubaciAzurirajPodatke(sql, podaci);
        return true;
    }
    dodajFilm(film) {
        console.log(film);
        let sql = "INSERT INTO movie (adult, backdrop_path, id, original_language, original_title, overview, popularity, poster_path, release_date, title, video, vote_average, vote_count, user_id)VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";
        let podaci = [
            film.adult ? 1 : 0,
            film.backdrop_path,
            film.id,
            film.original_language,
            film.original_title,
            film.overview,
            film.popularity,
            film.poster_path,
            film.release_date,
            film.title,
            film.video ? 0 : 1,
            film.vote_average,
            film.vote_count,
            film.user_id
        ];
        this.baza.ubaciAzurirajPodatke(sql, podaci);
        if (film.genre_ids && Array.isArray(film.genre_ids)) {
            const zanroviSql = "INSERT INTO movieGenre (movie_id, genre_id) VALUES (?, ?)";
            for (let genreId of film.genre_ids) {
                let movieGenrePodaci = [film.id, genreId];
                console.log('Genre IDs:', film.genre_ids);
                this.baza.ubaciAzurirajPodatke(zanroviSql, movieGenrePodaci);
            }
        }
        else {
            console.log("Film nema pridružene žanrove.");
        }
        return true;
    }
    obrisiFilm(idFilm) {
        console.log(idFilm);
        let sqlObrisiZanr = `DELETE FROM movieGenre WHERE movie_id = ?`;
        let sqlObrisiFilm = "DELETE FROM movie WHERE id=?";
        let podaci = [idFilm];
        if (idFilm) {
            this.baza.ubaciAzurirajPodatke(sqlObrisiZanr, podaci);
            this.baza.ubaciAzurirajPodatke(sqlObrisiFilm, podaci);
            return true;
        }
        return false;
    }
    obrisiSekvFilm(idFilm) {
        let sqlObrisiSekvZanr = "DELETE FROM sqlite_sequence WHERE name='movieGenre';";
        let sqlObrisiSekvFilm = "DELETE FROM sqlite_sequence WHERE name='movie';";
        let podaci = [idFilm];
        if (idFilm) {
            this.baza.ubaciAzurirajPodatke(sqlObrisiSekvFilm, podaci);
            this.baza.ubaciAzurirajPodatke(sqlObrisiSekvZanr, podaci);
            return true;
        }
        return false;
    }
    dodajZanr(zanr) {
        console.log(zanr);
        let sql = "INSERT INTO genre (id, name) VALUES (?, ?)";
        let podaci = [zanr.id, zanr.name];
        this.baza.ubaciAzurirajPodatke(sql, podaci);
        return true;
    }
    dodajZanrFilm(zanrFilm) {
        console.log(zanrFilm);
        let sqlProvjeriFilm = "SELECT * FROM movie WHERE id =?";
        let filmPostoji = this.baza.dajPodatke(sqlProvjeriFilm, [zanrFilm.movie_id]);
        if (filmPostoji.length === 0) {
            throw new Error("Film s ID-em " + zanrFilm.movie_id + " nije pronađen.");
        }
        let sqlProvjeriZanr = "SELECT * FROM genre WHERE id =?";
        let zanrPostoji = this.baza.dajPodatke(sqlProvjeriZanr, [zanrFilm.genre_id]);
        if (zanrPostoji.length === 0) {
            throw new Error("Žanr s ID-em " + zanrFilm.genre_id + " nije pronađen.");
        }
        try {
            let sql = "INSERT INTO movieGenre (movie_id, genre_id) VALUES (?, ?)";
            let podaci = [zanrFilm.movie_id, zanrFilm.genre_id];
            this.baza.ubaciAzurirajPodatke(sql, podaci);
            return true;
        }
        catch (error) {
            if (error instanceof Error) {
                if (error.message.includes('UNIQUE constraint failed')) {
                    throw new Error("Ovaj žanr je već dodan filmu.");
                }
            }
            throw new Error("Nepoznata greška prilikom izvršavanja upita.");
        }
    }
    async dajZanrFilm(idZanr) {
        const sql = "SELECT movie.id AS movie_id, movie.original_title AS movieName, genre.id AS genre_id, genre.name AS genreName FROM movie JOIN movieGenre ON movie.id = movieGenre.movie_id JOIN genre ON movieGenre.genre_id = genre.id WHERE genre.id = ?";
        var podaci = await this.baza.dajPodatkePromise(sql, [idZanr]);
        if (podaci.length == 0 && podaci[0] != undefined) {
            return null;
        }
        const rezultat = {};
        for (const film of podaci) {
            if (film.genreName) {
                if (!rezultat[film.genreName]) {
                    rezultat[film.genreName] = [];
                }
                rezultat[film.genreName].push({
                    id_filma: film.movie_id,
                    naziv_filma: film.movieName,
                    žanr_id: film.genre_id,
                    naziv_žanra: film.genreName
                });
            }
        }
        return rezultat;
    }
    async dajZanroveFilma(idFilm) {
        let sql = "SELECT g.id, g.name FROM movieGenre mg INNER JOIN genre g ON mg.genre_id = g.id WHERE mg.movie_id=?";
        var podaci = await this.baza.dajPodatkePromise(sql, [idFilm]);
        let rezultat = new Array();
        for (let p of podaci) {
            let k = { id: p["id"], name: p["name"] };
            rezultat.push(k);
        }
        return rezultat;
    }
    async obrisiZanrbezFilma(idZanr) {
        let sql = "SELECT  COUNT(movie_id) AS brojFilmova FROM movieGenre WHERE genre_id = ?";
        const podaci = await this.baza.dajPodatkePromise(sql, [idZanr]);
        console.log(podaci);
        if (podaci[0]?.brojFilmova === 0) {
            let sqlBrisanje = "DELETE FROM genre WHERE id = ?";
            let sqlResetSekvence = "DELETE FROM sqlite_sequence WHERE name='genre';";
            this.baza.ubaciAzurirajPodatke(sqlResetSekvence, []);
            this.baza.ubaciAzurirajPodatke(sqlBrisanje, [idZanr]);
            return true;
        }
        return false;
    }
    async dajSveZanrove() {
        let sql = "SELECT * FROM genre;";
        let podaci = await this.baza.dajPodatkePromise(sql, []);
        let rezultat = new Array();
        for (let p of podaci) {
            let k = { id: p["id"], name: p["name"] };
            rezultat.push(k);
        }
        return rezultat;
    }
    async dajBrojFilmovaUZanru(idZanr) {
        let sql = `
			SELECT COUNT(movie_id) AS broj_filmova
			FROM movieGenre
			WHERE genre_id = ?
		`;
        let podaci = await this.baza.dajPodatkePromise(sql, [idZanr]);
        if (Array.isArray(podaci) && podaci.length > 0) {
            let rezultat = podaci[0];
            return rezultat.broj_filmova;
        }
        return 0;
    }
}
