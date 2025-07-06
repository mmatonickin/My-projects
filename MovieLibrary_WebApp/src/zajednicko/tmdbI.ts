export interface ZanrI{
    id: number;
    name: string;
}

export interface FilmZanrI{
    movie_id:number;
    genre_id: number;
    movieName?: string | undefined;
    genreName?: string | undefined;
}

export interface FilmI{
    adult:boolean;
    backdrop_path:string;
    genre_ids?: number[];
    id:number;
    original_language:string;
    original_title:string;
    overview:string;
    popularity:number;
    poster_path:string;
    release_date:string;
    title:string;
    video:boolean;
    vote_average:number;
    vote_count:number;
    user_id: number;

}

export interface PartialFilmI {
    id: number;
    title: string;
}

export interface FilmoviTmdbI {
    page:number;
    results:Array<FilmI>;
    total_pages:number;
    total_results:number;
}


export interface FilmoviTmdbI {
    page:number;
    results:Array<FilmI>;
    total_pages:number;
    total_results:number;
}