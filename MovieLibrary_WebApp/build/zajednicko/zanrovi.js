export class Zanrovi {
    naziviZanrova;
    constructor() {
        this.naziviZanrova = [
            "Action",
            "Adventure",
            "Animation",
            "Comedy",
            "Crime",
            "Documentary",
            "Drama",
            "Family",
            "Fantasy",
            "History",
            "Horror",
            "Music",
            "Mystery",
            "Romance",
            "Science Fiction",
            "TV Movie",
            "Thriller",
            "War",
            "Western"
        ];
    }
    validanZanr(zanr) {
        return this.naziviZanrova.includes(zanr);
    }
}
