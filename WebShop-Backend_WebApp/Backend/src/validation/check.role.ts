import {NextFunction, Request, Response} from "express";

export function checkRole(req: Request, res: Response, next:NextFunction){
    if(res.locals.user.roleId === process.env.CLIENT_ROLE || res.locals.user.roleId === process.env.ADMIN_ROLE)
        next();
    else
        res.sendStatus(403);
}