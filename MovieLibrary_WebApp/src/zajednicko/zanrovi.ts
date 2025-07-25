export class Zanrovi {
    naziviZanrova: string[];

    constructor (){
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

    validanZanr(zanr: string): boolean {
        return this.naziviZanrova.includes(zanr);
    }
}