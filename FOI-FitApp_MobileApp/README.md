# Health and Fitness aplikacija

## Projektni tim

Ime i prezime | E-mail adresa (FOI) | JMBAG | Github korisničko ime
------------  | ------------------- | ----- | ---------------------
Žana Marija Podgorelec | zpodgorel22@student.foi.hr | 0331001511 | ZanaMarija22
Ivan Mihelić | imihelic21@student.foi.hr | 0016157432 | imihelic21
Iva Baniček | ibanicek22@student.foi.hr | 0016159143 | ibanicek22
Mateus Matoničkin | mmatonick22@student.foi.hr | 0016158396 | Matonickin

## Opis domene
Projektom se želi razviti mobilna aplikacija za praćenje zdravih navika s naglaskom na vježbanje i pravilnu prehranu. Mogućnosti aplikacije bit će podijeljene na dvije cjeline: fizičku aktivnost i prehranu. U skladu s tim, korisnik će moći planirati svoje treninge unošenjem ciljanih vježbi (npr. mršavljenje, unaprjeđenja kondicije) i na temelju unesenog cilja, aplikacija će generirati plan treninga. Osim toga, korisnik će moći zakazati fizičku aktivnost (trčanje ili hodanje), dok će na kraju treninga korisnik moći na kalendaru pratiti koliko je i kada trenirao.
Što se tiče prehrane, korisnik će moći unijeti predviđenu potrošnju kalorija u danu te će aplikacija, na temelju unesenih vrijednosti, generirati i ispisati na ekranu plan prehrane. Osim toga, korisnik će moći pregledavati recepte uz mogućnost filtriranja istih prema određenoj namirnici. Aplikacija će za svaki recept prikazati sliku jela, popis sastojaka, detaljne korake pripreme, te vrijeme pripreme. Aplikacija će nuditi i mogućnost korisnicima da objave vlastite recepte, te će omiljene recepte korisnik moći spremati. 
Nadalje, aplikacija će sadržavati nekoliko elemenata iz područja videoigara. Tako će korisnik moći odigrati mini igru u kojoj glavni lik skuplja različite namirnice koje ga mogu ubrzati ili usporiti s obzirom na to preporučuju li nutricionisti unos istih (npr. jabuka bi dala ubrzanje, a pizza bi usporavala lika). Osim toga, kretanjem lika po aplikacji, korisnik bi skupljao bodove vidljive na ekranu.

## Specifikacija projekta

Oznaka | Naziv | Kratki opis
------ | ----- | ----------- 
F01 | Korisnički račun i navigacija | Novi korisnik treba ispuniti registracijsku formu s osobnim podacima kako bi mogao pristupiti aplikaciji. Unos podataka podrazumijeva ime, prezime, dob, visinu, težinu, email, korisničko ime i lozinku. Kada je korisnik registriran, može se prijaviti s pomoću korisničkog imena i lozinke da bi pristupio svom profilu i funkcijama aplikacije. Korisnik će se moći kretati s pomoću navigacije kako bi jednostavno pristupio svim funkcionalnostima aplikacije (treninzi, obroci, recepti, videoigra). Primarni izbornik bit će prikazan kao gornja navigacijska traka (top bar), dok će sekundarni izbornik biti implementiran kao bočni izbornik (side drawer) koji se otvara pritiskom na hamburger ikonu.
F02 | Trening i planiranje aktivnosti | Korisnik će moći unijeti cilj treninga (mršavljenje ili poboljšanje kondicije) kako bi aplikacija mogla generirati personalizirani plan temeljen na njegovom odabiru cilja. Također, korisnik će moći zakazati svoje treninge unaprijed, odabrati vrstu treninga i definirati vrijeme kada će trenirati. Osim toga, korisnik će moći pratiti njegove prošle treninge i vidjeti napredak kroz vrijeme, uključujući datume, trajanje i tipove treninga.
F03 | Prehrana i planiranje obroka | Korisnik će na svom profilu moći nijeti broj kalorija koje planira potrošiti u danu, kako bi mi aplikacija mogla generirati plan prehrane prema njegovim ciljevima.
F04 | Recepti | Korisnik će moći pregledavati popis svih dostupnih recepata u aplikaciji, a klikom na pojedini recept aplikacija omogućava otvaranje dijaloškog okvira unutar kojeg će pisati svi detalji recepta (ime recepta, način pripreme, potrebni sastojci i procijenjeni broj kalorija). Osim toga, aplikacija će omogućiti korisniku unos vlastitog recepta, uključujući naziv recepta, sastojke, vrijeme izrade, postupak pripreme i procjenu kalorija. Također, korisnik će moći filtrirati recepte prema sastojcima, sortirati iste prema količini kalorija i dodavati željene recepte u favorite klikom na zvjezdicu pored recepta.
F05 | Zakazivanje aktivnosti | Sustav omogućuje zakazivanje fizičke aktivnosti. Postoje četiri kategorije fizičkih aktivnosti: hodanje, trčanje, plivanje i bicikliranje. Kada korisnik odabere jednu od ponuđenih kategorija unutar padajućeg izbornika i odabere gumb spremi, sustav sprema zakazanu aktivnost u bazu podataka.
F06 | Videoigra | Korisnik će moći odigrati igricu u koji se njegov lik može kretati kroz 2D prostor,  skupljati različite elemente (namirnice: jabuke ili pizze) pomoću kojih može ubrzavati ili usporavati. Lik u igri će moći preskakati različite prepreke i skupljati nasumično generirane elemente (namirnice), pri čemu će skupljati bodove. Aplikacija će najbolji rezultati (najveći broj bodova) pohraniti u bazu i prikazati korisniku na ekranu. Igra će završiti kada lik udari u prepreku.


**Nefunkcionalni zahtjevi:**

NFZ-1 Sustav će interakciju s korisnikom provoditi preko grafičkog sučelja.

NFZ-2 Sustav će ponuditi mehanizme koji će smanjiti mogućnost grešaka prilikom unosa kalorija, razine stresa, zadovoljstva, recenzija i objave recepata.

NFZ-3 Sustav će osigurati preciznost za decimalne brojeve za dva decimalna mjesta.

NFZ-4 Sustav će omogućiti prijavu korisnika u aplikaciju.

NFZ-5 Sustav će prikupljati, obrađivati i čuvati podatke o studentima u skladu s odredbama Uredbe (EU) 2016/679 Europskog parlamenta i Vijeća o zaštiti pojedinaca (27. travnja 2016.).

NFZ-6 Sustav podržava Android mobilne uređaje.

## Tehnologije i oprema
Projekt će se razvijati koristeći Android Studio okvir za razvoj androidnih aplikacija s ciljem stvaranja mobilne aplikacije s elementima igara te primjenom Scrum metode razvoja. Korišteni programski jezik bit će Kotlin, budući da se spomenuti jezik najčešće koristi prilikom kreiranja mobilnih aplikacija.
Uz to, koristit ćemo Git i GitHub platformu za verzioniranje i pohranjivanje koda, suradnju i praćenje zadataka. Za izradu tehničke i projektne dokumentacije koristit ćemo GitHub Wiki, dok ćemo planirati i pratiti projektne zadatke putem GitHub Projects i Jire. Članovi tima radit će na računalima s Windows operativnim sustavom.
