export function checkMandatoryData (firstName: string, lastName: string, houseNumber: number, street: string, stateId:number, town: string, email: string, userName: string, password: string): boolean{
    return firstName !== "" && lastName !== "" && houseNumber != null && street !=="" && stateId !=null && town !=="" && email!=="" && userName!=="" && password!=="";
}

export function checkMandatoryDataProducts (productName: string, price: number, premiumOffer: number, stock:string): boolean{
    return productName !=="" && price != null && premiumOffer != null && stock != null;
}

export function checkMandatoryDataSpecs (cpu:string, cpuGhz:number, cpuCores:number, gpu:string, gpuVram:number, ram:string, ramSize:number, storageHdd:number, storageSsd:number): boolean{
    return cpu !=="" && cpuGhz !==null && cpuCores !==null && gpu !=="" && gpuVram !==null && ram !=="" && ramSize!==null && storageHdd !==null && storageSsd !== null;
}
export function checkMandatoryDataCategory (categoryId: number){
    return categoryId != null;
}