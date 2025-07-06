import { CartController } from "../controllers/cart.controller";
import express, { Router } from "express";
import ProductsController from "../controllers/products.controller";
import { authenticateToken } from "../validation/authentication.js";
import { OrderController } from "../controllers/order.controller";

export class OrderRouter {
    private orderController: OrderController;
    public orderRouter: Router;

    constructor(orderController: OrderController){
        this.orderController = orderController;
        this.orderRouter = express.Router();
        this.setupOrderRoutes();
    }

    private setupOrderRoutes() {
        this.orderRouter.post("/PlaceOrder", authenticateToken,this.orderController.postPlaceOrder.bind(this.orderController));
        this.orderRouter.get("/AllOrders", authenticateToken, this.orderController.getAllOrders.bind(this.orderController));
    }

    public getOrderRouter(): Router {
        return this.orderRouter;
    }
    
}