import { DAO } from "../DAO";
import { Request, Response } from "express";
import { CartI } from "../models/cart.model";
import z from "zod";
import { OrderI } from "../models/order.model";

export class OrderController{
    private dao: DAO;
    
      constructor(dao: DAO) {
        this.dao = dao;
      }

    async postPlaceOrder(req: Request, res: Response){
        res.type("application/json");
        const data = req.body;
        const {ShipmentAdress} = data;
        const orderSchema = z.object({   
            ShipmentAdress: z.string(),
        });
        const validation = orderSchema.safeParse(data);

        if(!validation.success){
            res.status(400).json({ message: "Invalid or missing fields", errors: validation.error.format() });
            return;
        }
        const loggedUserId = res.locals.user.userId;
        const orderTotalPrice = await this.dao.getOrderAmount(loggedUserId);
        
        if(orderTotalPrice == 0){
            res.status(400).send(JSON.stringify({message: "This users do not have any items in cart"}));
            return;
        }
        const estimatedShipmentDate = new Date();
        estimatedShipmentDate.setHours(estimatedShipmentDate.getHours() + 48);
        const newOrder: OrderI = {
            userId: loggedUserId,
            totalPrice: orderTotalPrice,
            orderDate: new Date(),
            shipmentDate: estimatedShipmentDate,
            shipmentAdress: validation.data.ShipmentAdress,
            orderStatusId: 1
        }
        const newOrderId = await this.dao.insertNewOrder(newOrder);
        await this.dao.updateCartStatus(loggedUserId);
        await this.dao.insertItemsIntoOrder(newOrderId, loggedUserId);
        res.status(201).send(JSON.stringify({message: "Order successfully placed!"}))
        return;
    }

    async getAllOrders(req: Request, res: Response){
        res.type("application/json");
        this.dao.fetchOrders().then((orders: Array<OrderI>) => {
              res.status(200);
              res.send(JSON.stringify(orders));
            });

    }
}