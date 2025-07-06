
export function validirajEmail (email:string): boolean {
    const emailRegex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
    return emailRegex.test(email); 
}

export function validirajUsername (username: string): boolean {
    const usernameRegex = /^[a-z0-9]{3,}$/;
    return usernameRegex.test(username);
}

export function provjeriObaveznePodatke (name: string, surname: string, email: string, username: string, password?: string): boolean{
    return name !== "" && surname !== "" && email !== "" && username !== "" && password !== "";
}
