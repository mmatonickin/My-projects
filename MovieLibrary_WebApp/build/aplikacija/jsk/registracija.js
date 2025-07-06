let url ="http://" + window.location.hostname + ":" + citajRestPortIzKolacica();
let poruka = document.getElementById("poruka");
document.addEventListener("DOMContentLoaded", ()=>{
    poruka = document.getElementById('poruka');
    document.getElementById("form").addEventListener("submit", async (event)=>{
        event.preventDefault();
        const korisnik ={
            name: document.getElementById("ime").value,
            surname: document.getElementById("prezime").value,
            email: document.getElementById("email").value,
            username: document.getElementById("korime").value,
            password: document.getElementById("lozinka").value,
            role_id: 2
        };
        await registracija(korisnik);
    });
});

async function registracija(korisnik){
    let zaglavlje = new Headers();
    zaglavlje.set("Content-Type", "application/json");
    let parametri = {
                    method: "POST",
                    body: JSON.stringify(korisnik),
                    headers: zaglavlje
                    };
    let odgovor = await fetch (url + "/registracija", parametri);
    if (odgovor.status == 200){
        console.log(odgovor);
        let rezultat = await odgovor.json();
        window.location.href = rezultat.preusmjeri;
    } else if (odgovor.status == 400){
        let rezultat = await odgovor.json();
        poruka.innerHTML = rezultat.greska;

    } else{
        poruka.innerHTML = "Greška na servisu";
    }
}
