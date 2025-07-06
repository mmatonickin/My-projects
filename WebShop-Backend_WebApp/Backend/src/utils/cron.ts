import cron from "node-cron";
import Database from "../../database/db.js";
import sql from "mssql";

const db = new Database();

export async function checkExpiredCartsOnStartup(){
    console.log("Running expiration check");

    const fortyEighHoursAgo = new Date();
    fortyEighHoursAgo.setHours(fortyEighHoursAgo.getHours()-48);
    const param = [
        {
            name:"fortyEightHoursAgo",
            type: sql.DateTime,
            value: fortyEighHoursAgo
        }
    ]

    try {
        const result = await db.executeQuery(`
            UPDATE Cart 
            SET CartStatusID = 3 
            WHERE UpdatedDate <= @fortyEightHoursAgo 
            AND CartStatusID = 1;
        `,param);
    
        console.log(`Updated ${result.rowsAffected} expired carts.`);
    } catch (error) {
        console.error("Error updating expired carts:", error);
    }
}

export function startCartExpirationJob(){
    cron.schedule('* * * * *', checkExpiredCartsOnStartup);
    console.log("Cart expiration check runs every hour");
}

export async function checkIfOrderIsShippedOnStartup(){
    console.log("Running shipment checks");

    const currentDate = new Date();
    const params = [
        {name: "currentDate", type:sql.Date, value: currentDate}
    ]
    
    try {
        const result = await db.executeQuery(`
            UPDATE Orders
            SET OrderStatusID = 2
            WHERE ShipmentDate <= @currentDate
            AND OrderStatusID = 1`, params);
            console.log(`Updated ${result.rowsAffected} orders`);
    } catch (error) {
        console.log("Error while updating order status", error);
    }
}

export function startOrderIsShippedCheck(){
    cron.schedule("0 */6 * * *", checkIfOrderIsShippedOnStartup);
    console.log("Executing cron job: Checking if orders are shipped...");
}
