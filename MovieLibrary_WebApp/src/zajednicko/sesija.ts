import {Session} from "express-session";

export interface RWASession extends Session {
    idKorisnik: number;
    korisnik: any;
    korime: string;
    uloga: number;
}
