import dotenv from "dotenv";
import express, { Request, Response } from "express";
import path from "path";
import { fileURLToPath } from "url";
import Database from "../database/db.js"
import { ProductsRouter } from "./routes/products.router.js";
import ProductsController from "./controllers/products.controller.js";
import { DAO } from "./DAO.js";
import UsersController from "./controllers/users.controller.js";
import { UsersRouter } from "./routes/users.router.js";
import { startCartExpirationJob, checkExpiredCartsOnStartup, startOrderIsShippedCheck, checkIfOrderIsShippedOnStartup } from "./utils/cron.js";
import { CartController } from "./controllers/cart.controller.js";
import { CartRouter } from "./routes/cart.router.js";
import { OrderController } from "./controllers/order.controller.js";
import { OrderRouter } from "./routes/order.router.js";

const database = new Database();
const dao = new DAO(database);
const productsController = new ProductsController(dao);
const productsRouter = new ProductsRouter(productsController);

const usersController = new UsersController(dao);
const usersRouter = new UsersRouter(usersController);

const cartController = new CartController(dao);
const cartRouter = new CartRouter(cartController);

const orderController = new OrderController(dao);
const orderRouter = new OrderRouter(orderController);

process.on("uncaughtException", (err)=>{
    console.log("Uncaught exception, server is shutting down");
    console.log(err.name, err.message);
    process.exit(1);
});

const app = express();
dotenv.config();

const port = normalizePort(process.env.PORT || '8080');
const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

checkExpiredCartsOnStartup();
startCartExpirationJob();

checkIfOrderIsShippedOnStartup();
startOrderIsShippedCheck();

app.get("/", (req: Request, res: Response)=>{
    res.status(200).json({message: "connected"});
});

app.use(express.json());
app.use(express.urlencoded({extended: true}));
app.use(express.static(__dirname));

app.use("/Products", productsRouter.getProductsRouter());
app.use("/Users", usersRouter.getUsersRouter());
app.use("/Cart", cartRouter.getCartRouter());
app.use("/Order", orderRouter.getOrderRouter());



/* database.connect()
    .then((connection) => {
        console.log("Connected to database");
    })
    .catch((error) => {
        console.log("Connection failed");
        console.log(error);
    }); */

app.use((req: Request, res: Response) => {
    res.send("Page not found");
});

app.listen(port, () =>{
    console.log(`Server is running on port:${port}`);


});

function normalizePort(val: any){
    const port = parseInt(val, 10);
    if(isNaN(port)){
        return val;
    }
    if(port>=0){
        return port;
    }
    return false;
}



