import { DAO } from "../DAO";
import { Request, Response } from "express";
import { CartI } from "../models/cart.model";
export class CartController{
    private dao: DAO;
    
      constructor(dao: DAO) {
        this.dao = dao;
      }

    async postProductsInCart(req: Request, res:Response){
        res.type("application/json");
        let data = req.body;
        const {ProductID, Amount} = data;
        const loggedUser = res.locals.user.userId;

        if(!ProductID || !Amount){
            res.status(400).send(JSON.stringify({message: "All fields are mandatory"}));
            return;
        }
        console.log(loggedUser);
        let userChart = await this.dao.getLastCart(loggedUser);
        console.log(userChart.chartId, userChart.userId);
        if(userChart.cartStatusId == 2 || userChart.cartStatusId == 3){
            const createdAt = new Date();
            const newChart:CartI={
                userId: loggedUser,
                createdDate: createdAt,
                updatedDate: createdAt,
                cartStatusId: 1
            }
            const userNewChartId = await this.dao.insertNewCart(newChart);
            await this.dao.insertProductsIntoCart(ProductID,userNewChartId, Amount);
            res.status(201).send(JSON.stringify({message: "Product inserted"}));
        }
        else if (userChart.cartStatusId == 1){
                let currentCartItems = await this.dao.getChartItems(userChart.chartId!);
                for (let item of currentCartItems){
                    if(item.productId == ProductID){
                        res.status(201).send(JSON.stringify({message: "Product already exist, amount increase"}));
                        await this.dao.updateChartItemAmount(Amount, userChart.chartId!, ProductID);
                        return;
                    }
                }
                await this.dao.insertProductsIntoCart(ProductID, userChart.chartId!, Amount);
                res.status(201).send(JSON.stringify({message: "Product inserted"}));
                return;
                }
        else {
            res.status(400).send(JSON.stringify({message: "failed to insert products in cart"}));
            return;
        } 
    }
}