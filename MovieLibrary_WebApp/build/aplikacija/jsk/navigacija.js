
document.addEventListener("DOMContentLoaded", async () => {
    const prijavaLink = document.getElementById("prijava");
    const odjavaLink = document.getElementById("odjava");
    let prijavljen = await provjeriSesiju();

    const azurirajNavigaciju = () => {
        if (prijavljen) {
            prijavaLink.style.display = "none";
            odjavaLink.style.display = "inline";
        } else {
            prijavaLink.style.display = "inline";
            odjavaLink.style.display = "none";
        }
    };

    azurirajNavigaciju();

    prijavaLink.addEventListener("click", () => {
        sessionStorage.setItem("prijavljen", "true");
        azurirajNavigaciju();
    });

    odjavaLink.addEventListener("click", () => {
        sessionStorage.removeItem("prijavljen");
        azurirajNavigaciju();
    });
});

async function provjeriSesiju() {
    let parametri = { method: "GET" };
    try {
        let odgovor = await fetch(url + "/api/sesija", parametri);
        if (odgovor.ok) { 
            return true; 
        } else {
            return false;
        }
    } catch (error) {
        console.error("Greška prilikom provjere sesije:", error);
        return false;
    }
}
