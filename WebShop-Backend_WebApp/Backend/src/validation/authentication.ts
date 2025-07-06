import {NextFunction, Request, Response} from "express";
import jwt, { JwtPayload } from 'jsonwebtoken';

export async function authenticateToken(req: Request, res: Response, next: NextFunction): Promise<void> {
    try {
        const authHeaders = req.headers["authorization"];
        const token = authHeaders && authHeaders.split(" ")[1];

        if (!token || !process.env.ACCESS_TOKEN) {
            res.status(400).json({ message: "Token is missing" });
            return;
        }

        const decoded = await new Promise<JwtPayload | string>((resolve, reject) => {
            jwt.verify(token, process.env.ACCESS_TOKEN!, (err, response) => {
                if (err || !response) reject(err || new Error("Invalid token"));
                resolve(response as JwtPayload | string);
            });
        });

        res.locals.user = decoded as JwtPayload;
        return next();
    } catch (error) {
        res.status(403).json({ error: "Invalid or expired token" });
        return;
    }
}