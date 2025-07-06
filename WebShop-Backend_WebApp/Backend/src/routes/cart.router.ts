import { CartController } from "../controllers/cart.controller";
import express, { Router } from "express";
import ProductsController from "../controllers/products.controller";
import { authenticateToken } from "../validation/authentication.js";

export class CartRouter {
    private cartController: CartController;
    public cartRouter: Router;

    constructor(cartController: CartController){
        this.cartController = cartController;
        this.cartRouter = express.Router();
        this.setupProductsRoutes();
    }

    private setupProductsRoutes() {
        this.cartRouter.post("/Items",authenticateToken, this.cartController.postProductsInCart.bind(this.cartController));
    }

    public getCartRouter(): Router {
        return this.cartRouter;
    }
    
}