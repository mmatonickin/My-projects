export interface UserI {
    userId?: number,
    firstName: string,
    lastName: string,
    houseNumber: number,
    street: string,
    stateId: number,
    town: string,
    email: string,
    userName: string,
    password?: string,
    roleId?: number
}