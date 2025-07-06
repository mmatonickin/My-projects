import sql from "mssql";
import { QueryParamI } from "../src/models/query.model";
import dotenv from "dotenv";

dotenv.config();

export default class Database {
    private config: sql.config; 

    constructor() {
        this.config = {
            server: process.env.SERVER || 'PLATOMAT-KB-02',
            database: process.env.DATABASE || 'webshopDB',
            user: process.env.USER ||'webshop2',
            password: process.env.PASSWORD || 'webshopProjekt',
            options: {
                trustedConnection: process.env.TRUSTEDCONNECTION === 'true',
                trustServerCertificate: process.env.TRUSTSERVERCERTIFICATE === 'true',
                enableArithAbort: process.env.ENABLEARITHABORT === 'true'
            },
        };
    }

    // Metoda za izvršavanje SQL upita
    public async executeQuery(query: string, params: QueryParamI[] = []) {
        let pool;
        try {
            pool = await sql.connect(this.config);

            let request = pool.request();

            // Dodavanje parametara u upit
            params.forEach(param => {
                request.input(param.name, param.type, param.value);
            });

            let result = await request.query(query);
            return result;
        } catch (error) {
            console.error('Greška pri izvršavanju upita:', error);
            throw error;
        } finally {
            if (pool) {
                await pool.close();
                console.log('Konekcija zatvorena');
            }
        }
    }
}
