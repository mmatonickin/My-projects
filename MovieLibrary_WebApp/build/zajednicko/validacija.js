export function validirajEmail(email) {
    const emailRegex = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/;
    return emailRegex.test(email);
}
export function validirajUsername(username) {
    const usernameRegex = /^[a-z0-9]{3,}$/;
    return usernameRegex.test(username);
}
export function provjeriObaveznePodatke(name, surname, email, username, password) {
    return name !== "" && surname !== "" && email !== "" && username !== "" && password !== "";
}
