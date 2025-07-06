export class TMDBklijent {
    bazicniURL = "https://api.themoviedb.org/3";
    apiKljuc;
    constructor(apiKljuc) {
        this.apiKljuc = apiKljuc;
    }
    async pretraziFilmovePoNazivu(trazi, stranica) {
        let resurs = "/search/movie";
        let parametri = { sort_by: "popularity.desc",
            include_adult: false,
            query: trazi,
            page: stranica
        };
        let odgovor = await this.obaviZahtjev(resurs, parametri);
        return JSON.parse(odgovor);
    }
    async pretraziFilmPoId(id, stranica) {
        let resurs = `/movie/${id}`;
        let parametri = {
            query: id,
            page: stranica
        };
        let odgovor = await this.obaviZahtjev(resurs, parametri);
        return JSON.parse(odgovor);
    }
    async dohvatiZanrove() {
        let resurs = "/genre/movie/list";
        let odgovor = await this.obaviZahtjev(resurs);
        return JSON.parse(odgovor).genres;
    }
    async obaviZahtjev(resurs, parametri = {}) {
        let zahtjev = this.bazicniURL + resurs + "?api_key=" + this.apiKljuc;
        for (let p in parametri) {
            zahtjev += "&" + p + "=" + parametri[p];
        }
        console.log(zahtjev);
        let odgovor = await fetch(zahtjev);
        let rezultat = await odgovor.text();
        return rezultat;
    }
}
