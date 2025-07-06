import express, { Router } from "express";
import ProductsController from "../controllers/products.controller";
import { authenticateToken } from "../validation/authentication.js";
import { checkRole } from "../validation/check.role.js";

export class ProductsRouter {
    private productsController: ProductsController;
    public productsRouter: Router;

    constructor(productsController: ProductsController){
        this.productsController = productsController;
        this.productsRouter = express.Router();
        this.setupProductsRoutes();
    }

    private setupProductsRoutes() {
        this.productsRouter.get("/all", this.productsController.getProducts.bind(this.productsController));
        this.productsRouter.get("/:id", this.productsController.getProductsById.bind(this.productsController));
        this.productsRouter.post("/add",authenticateToken, this.productsController.postProducts.bind(this.productsController));
        this.productsRouter.post("/remove", this.productsController.deleteProduct.bind(this.productsController));
    }

    public getProductsRouter(): Router {
        return this.productsRouter;
    }
    
}