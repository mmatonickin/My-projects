import Database from "../database/db";
import { ProductsI } from "./models/products.model";
import sql from "mssql";
import { UserI } from "./models/users.model";
import { SpecificationsI } from "./models/specifications.model";
import { CartI } from "./models/cart.model";
import { CartItemI } from "./models/cartItem.model";
import { OrderI } from "./models/order.model";
import { any, number } from "zod";

export class DAO {
  private db: Database;

  constructor(db: Database) {
    this.db = db;
  }

  async fetchUserbyEmail(email: string): Promise<UserI | null> {
    let query = "SELECT * FROM Users WHERE Email= @Email";
    let params = [{ name: "Email", type: sql.VarChar, value: email }];
    let data = await this.db.executeQuery(query, params);
    if (!data || data.recordset.length === 0) {
      return null;
    }
    let p = data.recordset[0];
    let user: UserI = {
      firstName: p["FirstName"],
      lastName: p["LastName"],
      houseNumber: p["HouseNumber"],
      street: p["Street"],
      stateId: p["StateID"],
      town: p["Town"],
      email: p["Email"],
      userName: p["Username"],
    };
    return user;
  }

  async fetchUserbyUsername(username: string): Promise<UserI | null> {
    let query = "SELECT * FROM Users WHERE Username= @Username";
    let params = [{ name: "Username", type: sql.VarChar, value: username }];
    let data = await this.db.executeQuery(query, params);
    if (!data || data.recordset.length === 0) {
      return null;
    }
    let p = data.recordset[0];
    let user: UserI = {
      userId:p["UserID"],
      firstName: p["FirstName"],
      lastName: p["LastName"],
      houseNumber: p["HouseNumber"],
      street: p["Street"],
      stateId: p["StateID"],
      town: p["Town"],
      email: p["Email"],
      userName: p["Username"],
      password: p["Pass"],
      roleId: p["RoleID"],
    };
    return user;
  }

  async fetchAllProducts(): Promise<Array<ProductsI>> {
    let query = "SELECT * FROM Products";
    let data = await this.db.executeQuery(query);

    if (!data || !data.recordset || data.recordset.length === 0) {
      throw new Error("Failed to fetch data");
    }
    let result = new Array<ProductsI>();
    for (let d of data.recordset) {
      let p: ProductsI = {
        productName: d["ProductName"],
        price: d["Price"],
        premiumOffer: d["PremiumOffer"],
        stock: d["Stock"],
      };
      result.push(p);
    }
    return result;
  }

  async getProductsById(productId: number): Promise<Array<ProductsI>> {
    let query = "SELECT * FROM Products WHERE ProductID=@id";

    let params = [{ name: "id", type: sql.Int, value: productId }];
    let data = await this.db.executeQuery(query, params);
    if (!data) {
      throw new Error("Failed to fetch data");
    }
    let result = new Array<ProductsI>();
    for (let d of data.recordset) {
      result.push(d as ProductsI);
    }
    return result;
  }

  async insertUser(user: UserI) {
    let query =
      "INSERT INTO Users (FirstName, LastName, HouseNumber, Street, StateID, Town, Email, Username, Pass, RoleID) OUTPUT INSERTED.UserID VALUES (@firstName, @lastName, @houseNumber, @street, @stateId, @town, @email, @userName, @password, @roleId);";
    let params = [
      { name: "firstName", type: sql.VarChar, value: user.firstName },
      { name: "lastName", type: sql.VarChar, value: user.lastName },
      { name: "houseNumber", type: sql.Int, value: user.houseNumber },
      { name: "street", type: sql.VarChar, value: user.street },
      { name: "stateId", type: sql.Int, value: user.stateId },
      { name: "town", type: sql.VarChar, value: user.town },
      { name: "email", type: sql.VarChar, value: user.email },
      { name: "userName", type: sql.VarChar, value: user.userName },
      { name: "password", type: sql.VarChar, value: user.password },
      { name: "roleId", type: sql.Int, value: user.roleId },
    ];
    let data = await this.db.executeQuery(query, params);
    if (data && data.rowsAffected && data.rowsAffected[0] > 0) {
      console.log("Query sucessfully executed");
      return data.recordset[0].UserID;
    } else {
      console.log("Query not executed or does not affect any rows");
    }
  }

  async insertNewProduct(product: ProductsI) {
    let query =
      "INSERT INTO Products (ProductName, Price, PremiumOffer, Stock) OUTPUT INSERTED.ProductID VALUES (@productName, @price, @premiumOffer, @stock);";
    let params = [
      { name: "productName", type: sql.VarChar, value: product.productName },
      { name: "price", type: sql.Int, value: product.price },
      { name: "premiumOffer", type: sql.Bit, value: product.premiumOffer },
      { name: "stock", type: sql.Int, value: product.stock },
    ];
    let data = await this.db.executeQuery(query, params);
    if (data && data.rowsAffected && data.rowsAffected[0] > 0) {
        return data.recordset[0].ProductID;
    } else {
      console.log("Query not executed or does not affect any rows");
    }
  }

  async insertSpecifications(specifications: SpecificationsI) {
    let query = `
        SET IDENTITY_INSERT Specifications ON;
        
        INSERT INTO Specifications (ProductID, CPU, CPU_GHz, CPU_Cores, GPU, GPU_VRAM, RAM, RAM_size, Storage_HDD, Storage_SSD) 
        VALUES (@productId, @cpu, @cpuGhz, @cpuCores, @gpu, @gpuVram, @ram, @ramSize, @storageHdd, @storageSsd);

        SET IDENTITY_INSERT Specifications OFF;
    `;
    let params = [
      { name: "productId", type: sql.Int, value: specifications.productId },
      { name: "cpu", type: sql.VarChar, value: specifications.cpu },
      { name: "cpuGhz", type: sql.Float, value: specifications.cpuGhz },
      { name: "cpuCores", type: sql.Int, value: specifications.cpuCores },
      { name: "gpu", type: sql.VarChar, value: specifications.gpu },
      { name: "gpuVram", type: sql.Int, value: specifications.gpuVram },
      { name: "ram", type: sql.VarChar, value: specifications.ram },
      { name: "ramSize", type: sql.Int, value: specifications.ramSize },
      { name: "storageHdd", type: sql.Int, value: specifications.storageHdd },
      { name: "storageSsd", type: sql.Int, value: specifications.storageSsd },
    ];
    let data = await this.db.executeQuery(query, params);
    if (data && data.rowsAffected && data.rowsAffected[0] > 0) {
      console.log("Query sucessfully executed");
    } else {
      console.log("Query not executed or does not affect any rows");
    }
  }

  async insertCategory(productId: number ,categoryId: number){
    let query = "INSERT INTO CategoryProduct (ProductID, CategoryID) VALUES (@productId, @categoryId);";
    let params = [
      {name: "productId", type: sql.Int, value: productId},
      {name: "categoryId", type: sql.Int, value: categoryId}
    ]
    let data = await this.db.executeQuery(query, params);
    if(data && data.rowsAffected && data.rowsAffected[0]>0)
      console.log("Query sucessfully executed");
    else
      console.log("Query not executed or does not affect any rows");
  }
  async insertNewCart (cart:CartI){
    let query = "INSERT INTO Cart (UserID, CreatedDate, UpdatedDate, CartStatusID) OUTPUT INSERTED.CartID VALUES (@userId, @createdDate, @updatedDate, @cartStatusId);";
    let params = [
      {name: "userId", type: sql.Int, value: cart.userId},
      {name: "createdDate", type: sql.DateTime, value: cart.createdDate},
      {name: "updatedDate", type: sql.DateTime, value: cart.updatedDate},
      {name: "cartStatusId", type: sql.Int, value: cart.cartStatusId}
    ]
    let data = await this.db.executeQuery(query, params);
    if(data && data.rowsAffected && data.rowsAffected[0]>0){
      console.log("Query sucessfully executed");
      return data.recordset[0].CartID;
    }
    else
    console.log("Query not executed or does not affect any rows");
  }

  async insertProductsIntoCart(productId: number, cartId: number, amount: number){
    let query = `INSERT INTO CartItem
                (ProductID, CartID, Amount)
                VALUES
                (@productId, @cartId, @amount);`;
    let params = [
      {name: "productId", type: sql.Int, value: productId},
      {name: "cartId", type: sql.Int, value: cartId},
      {name: "amount", type: sql.Int, value: amount}
    ]
    let data = await this.db.executeQuery(query, params);
    
    if(data && data.rowsAffected && data.rowsAffected[0]>0){
      console.log("Query sucessfully executed");
    }
    else
    console.log("Query not executed or does not affect any rows");
  }

  async getLastCart (userId: number){
    let query = `SELECT TOP 1 * 
                  FROM Cart 
                  WHERE UserID = @userId 
                  ORDER BY UpdatedDate DESC, CartID DESC;
                  `;
    let params = [{ name: "userId", type: sql.Int, value: userId }];
    let data = await this.db.executeQuery(query, params);
    if (!data) {
      throw new Error("Failed to fetch data");
    }
    let p = data.recordset[0];
    let cart: CartI = {
      chartId: p["CartID"],
      userId: p["UserID"],
      createdDate: p["CreatedDate"],
      updatedDate: p["UpdatedDate"],
      cartStatusId: p["CartStatusID"]
    };
    return cart;
  }

  async getChartItems (cartId: number): Promise<Array<CartItemI>>{
    let query = `SELECT *
                FROM CartItem
                WHERE CartID = @cartId;`;
    let params = [
      {name: "cartId", type: sql.Int, value: cartId}
    ]
    let data = await this.db.executeQuery(query,params);
    if (!data) {
      throw new Error("Failed to fetch data");
    }
    let result = new Array<CartItemI>();
    for (let d of data.recordset){
      let p: CartItemI = {
        productId: d["ProductID"],
        amount: d["Amount"]
      };
      result.push(p);
    }
    return result;
  }

  async updateChartItemAmount(amount:number,cartId:number ,productId: number){
    let query =`UPDATE CartItem
                SET Amount = Amount + @addedAmount
                WHERE CartID = @CartID AND ProductID = @ProductID;
                `;
    let params = [
      {name: "addedAmount", type:sql.Int, value: amount},
      {name: "cartId", type:sql.Int, value: cartId},
      {name:"productId", type:sql.Int, value: productId}
    ]
    let data = await this.db.executeQuery(query,params);
    if(data && data.rowsAffected && data.rowsAffected[0]>0)
      console.log("Query sucessfully executed");
    else
    console.log("Query not executed or does not affect any rows");
  }

  async deleteSpecifications(productId: number): Promise<void> {
    let query = "DELETE FROM Specifications WHERE ProductID=@id";

    let params = [{ name: "id", type: sql.Int, value: productId }];
    let data = await this.db.executeQuery(query, params);
    if(data && data.rowsAffected && data.rowsAffected[0]>0)
      console.log("Query sucessfully executed");
    else
    console.log("Query not executed or does not affect any rows");
  }

  async deleteCategories(productId: number): Promise<void> {
    let query = "DELETE FROM CategoryProduct WHERE ProductID=@id";

    let params = [{ name: "id", type: sql.Int, value: productId }];
    let data = await this.db.executeQuery(query, params);
    if(data && data.rowsAffected && data.rowsAffected[0]>0)
      console.log("Query sucessfully executed");
    else
    console.log("Query not executed or does not affect any rows");  
  }

  async deleteProduct(productId: number): Promise<void> {
    let query = "DELETE FROM Products WHERE ProductID=@id";

    let params = [{ name: "id", type: sql.Int, value: productId }];
    let data = await this.db.executeQuery(query, params);
    if(data && data.rowsAffected && data.rowsAffected[0]>0)
      console.log("Query sucessfully executed");
    else
    console.log("Query not executed or does not affect any rows"); 
  }

  async insertNewOrder(order: OrderI){
    let query = `INSERT INTO Orders (UserID, TotalPrice, OrderDate, ShipmentDate, ShipmentAdress, OrderStatusID) OUTPUT INSERTED.OrderID
                VALUES
                (@userId, @totalPrice, @orderDate, @shipmentDate, @shipmentAdress, @orderStatusId) 
    ;`;
    let params = [
      {name: "userId", type:sql.Int, value: order.userId},
      {name: "totalPrice", type:sql.Int, value: order.totalPrice},
      {name: "orderDate", type: sql.Date, value: order.orderDate},
      {name: "shipmentDate", type: sql.Date, value: order.shipmentDate},
      {name: "shipmentAdress", type:sql.VarChar, value: order.shipmentAdress},
      {name: "orderStatusId", type:sql.Int, value: order.orderStatusId}
    ]
    let data = await this.db.executeQuery(query, params);
    if(data && data.rowsAffected && data.rowsAffected[0]>0){
      console.log("Query sucessfully executed");
      return data.recordset[0].OrderID;
    }
    else
    console.log("Query not executed or does not affect any rows");
  }

  async getOrderAmount(userId: number): Promise<number | null>{
    let query = `SELECT SUM(ci.Amount * p.Price) AS TotalPrice
                FROM CartItem ci
                JOIN Products p ON ci.ProductID = p.ProductID
                WHERE ci.CartID = (
                  SELECT TOP 1 CartID
                  FROM Cart
                  WHERE UserID = @UserID AND CartStatusID = 1
                ORDER BY UpdatedDate DESC
                );
                `;
    let params = [
      {name:"userId", type:sql.Int, value: userId}
    ]
    let result = await this.db.executeQuery(query,params);
    if (!result.recordset[0] || result.recordset[0].TotalPrice === null) {
      return 0;
    }
    return result.recordset[0].TotalPrice;
  }

  async updateCartStatus(userId: number){
    let query = `UPDATE Cart
                SET CartStatusID = 2
                WHERE CartID = (
                SELECT TOP 1 CartID
                FROM Cart
                WHERE UserID = @UserID AND CartStatusID = 1
                ORDER BY UpdatedDate DESC, CartID DESC
                );
                ;`;
    let params = [
      {name:"userId", type:sql.Int, value: userId}
    ]
    let result = await this.db.executeQuery(query,params);
    if(result && result.rowsAffected && result.rowsAffected[0]>0){
      console.log("Query sucessfully executed");
      return true;
    }
    else{
      console.log("Query not executed or does not affect any rows");
      return;
    }
  
  }

  async insertItemsIntoOrder(orderId: number, userId: number){
    let query = `INSERT INTO OrderItem (ProductID, OrderID, Amount)
                SELECT 
                    ci.ProductID,
                    @orderId,
                    ci.Amount
                FROM CartItem ci
                WHERE ci.CartID = (
                    SELECT TOP 1 CartID
                    FROM Cart
                    WHERE UserID = @userId AND CartStatusID = 2
                    ORDER BY UpdatedDate DESC, CartID DESC
                );
                ;`;
    let params = [
      {name: "orderId", type:sql.Int, value: orderId},
      {name: "userId", type: sql.Int, value: userId},
    ]
    let result = await this.db.executeQuery(query,params);
    if(result && result.rowsAffected && result.rowsAffected[0]>0){
      console.log("Query sucessfully executed");
      return true;
    }
    else{
      console.log("Query not executed or does not affect any rows");
      return false;
    }
  }

  async fetchOrders(){
    let query=`SELECT 
                o.*, 
                oi.ProductID, 
                oi.Amount
              FROM Orders o
              LEFT JOIN OrderItem oi ON o.OrderID = oi.OrderID
              ORDER BY o.OrderID;
              `;
    let data = await this.db.executeQuery(query);
    if (!data || !data.recordset || data.recordset.length === 0) {
      throw new Error("Failed to fetch data");
    }
    let orderMap = new Map<number, any>();
    for (let d of data.recordset){
      let orderId = d["OrderID"];

      if(!orderMap.has(orderId)){
        orderMap.set(orderId, {
          orderId: orderId,
                userId: d["UserID"],
                totalPrice: d["TotalPrice"],
                orderDate: d["OrderDate"],
                shipmentDate: d["ShipmentDate"],
                shipmentAdress: d["ShipmentAdress"],
                orderStatusId: d["OrderStatusID"],
                items: []
        });
      }
      orderMap.get(orderId).items.push({
        productId: d["ProductID"],
        amount: d["Amount"]
      });
    }
  return Array.from(orderMap.values());
  }
}
