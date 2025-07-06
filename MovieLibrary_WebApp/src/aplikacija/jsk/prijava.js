let url ="http://" + window.location.hostname + ":" + citajRestPortIzKolacica();
let poruka = document.getElementById("poruka");
document.addEventListener("DOMContentLoaded", ()=>{
    poruka = document.getElementById('poruka');
    document.getElementById("login").addEventListener("submit", async (event)=>{
        event.preventDefault();
            const korisnik = {
                            username: document.getElementById("korime").value,
                            password: document.getElementById("lozinka").value
                            };
        
        prijava(korisnik);
    });
});

async function prijava (korisnik){
    let parametri = {
                        method: "POST",
                        body: JSON.stringify(korisnik),
                        headers: { "Content-Type": "application/json" }
                    };
    let odgovor = await fetch (url + "/prijava", parametri);
    if (odgovor.status == 200){
        console.log(odgovor);
        let rezultat = await odgovor.json();
        window.location.href = rezultat.preusmjeri;
    } else if (odgovor.status == 404){
        let rezultat = await odgovor.json();
        poruka.innerHTML = rezultat.greska;
        console.log(korisnik);

    } else{
        poruka.innerHTML = "Greška na servisu";
    }

}