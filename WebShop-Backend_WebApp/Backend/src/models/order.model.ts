export interface OrderI {
    orderId?: number,
    userId: number,
    totalPrice: number | null,
    orderDate: string | Date,
    shipmentDate: string | Date,
    shipmentAdress: string,
    orderStatusId: number
}