import express, { Response, Request ,Router, NextFunction } from "express";
import UsersController from "../controllers/users.controller";
import { authenticateToken } from "../validation/authentication.js";

export class UsersRouter {
    private usersController: UsersController;
    public usersRouter: Router;

    constructor(usersController: UsersController){
        this.usersController = usersController;
        this.usersRouter = express.Router();
        this.setupUsersRoutes();
    }

    private setupUsersRoutes() {
        this.usersRouter.post("/Registration", async (req: Request, res: Response, next: NextFunction) => {
            try {
                await this.usersController.insertUser(req, res, next);
            } catch (error) {
                next(error);
            }
        });
    
        this.usersRouter.post("/Login", async (req, res, next) => {
            try {
                await this.usersController.loginUser(req, res, next); 
            } catch (error) {
                next(error);
            }
        });
    }
    
    

    public getUsersRouter(): Router {
        return this.usersRouter;
    }
    
}