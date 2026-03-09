# Bibliotekarski Sistem 

Višeslojna klijent-server desktop aplikacija za upravljanje radom biblioteke razvijena u C#/.NET-u sa WinForms korisničkim interfejsom. Sistem omogućava bibliotekaru da upravlja knjigama, članovima, pozajmicama i smenama.

---

## Arhitektura projekta

Projekat prati tronivojsku arhitekturu (UI → Aplikaciona logika → Skladište podataka) i organizovan je u 7 slojeva:

```
Biblioteka/
├── Domeni/                  # Domenske klase, IEntity interfejs
├── BrokerBP/                # Generički pristup bazi podataka
├── SistemskeOp/             # Poslovna logika, Template Method patern
├── Zajednicki/              # Zahtev, Odgovor, Operacija, JsonNetworkSerializer
├── Server/                  # TCP server, Kontroler (Singleton), ClientHandler
├── KlijentskaAplikacija/    # WinForms UI, Komunikacija (Singleton), UserControls
└── Testovi/                 # XUnit testovi
```

Komunikacija između klijenta i servera odvija se kroz TCP sokete u JSON formatu. Klijent šalje `Zahtev` (tip operacije + podaci), server izvršava odgovarajuću SO klasu i vraća `Odgovor` (signal uspešnosti + rezultat).

---

## Domenske klase (8)

Sve klase implementiraju interfejs `IEntity` koji definiše metapodatke za automatsko generisanje SQL upita — `TableName`, `PrimaryKey`, `InsertColumns`, `Values`, `Join`, `GetReaderList`. Ovo omogućava `Broker`-u da radi generički sa svim klasama.

`Bibliotekar`, `Clan`, `Clanstvo`, `Knjiga`, `Pozajmica`, `StavkaPozajmice`, `BibSmena`, `TerminSmene`

---

## Sistemske operacije (17)

Sve SO klase nasleđuju `SOBase` koja implementira **Template Method** patern — otvara konekciju, pokreće transakciju, poziva `ExecuteConcreteOperation()` koji svaka SO implementira, i na kraju commituje ili rollbackuje.

Operacije pokrivaju: login, upravljanje knjigama (ubaci, pretraži, izmeni, obriši), upravljanje članovima (kreiraj, pretraži, izmeni, obriši), upravljanje pozajmicama (kreiraj, pretraži, vrati knjigu, izmeni rok) i upravljanje smenama (pretraži, dodaj, izmeni, vrati sve termine).

---

## Korisnički interfejs

Aplikacija sadrži forme `FrmLogin` i `FrmMeni`, te sledeće UserControls:

- **UCUbaciKnjigu / UCPrikazKnjiga** — dodavanje i pregled knjiga
- **UCDodajClana / UCPrikazClanova** — registracija i upravljanje članovima
- **UCKreirajPozajmicu / UCSvaZaduzenja** — kreiranje pozajmice, vraćanje knjiga, izmena roka
- **UCSmena** — pregled smena za narednih 7 dana, pretraga po imenu, prikaz detalja i zahtev za promenu smene (vidljiv samo za sopstvene buduće smene)

---

## Testovi i dokumentacija

Projekat sadrži **85 XUnit testova** koji svi prolaze. Testovi domenskih klasa pokrivaju computed properties i IEntity metapodatke, a testovi SO klasa proveravaju ispravno kreiranje objekta i početno stanje pre izvršavanja — bez potrebe za konekcijom na bazu.

Sve domenske i SO klase dokumentovane su XML Summary komentarima. Dokumentacija se automatski generiše pri buildu (`GenerateDocumentationFile = true`) kao `Domeni.xml` i `SistemskeOp.xml`.

---

## Pokretanje aplikacije

1. Otvoriti `Projekat-Softveri.sln` u Visual Studio 2022
2. Podesiti connection string u `BrokerBP/Broker.cs`
3. Pokrenuti SQL skriptu za kreiranje baze
4. Pokrenuti projekat **Server** → kliknuti **START**
5. Pokrenuti projekat **KlijentskaAplikacija** i prijaviti se

Kredencijali: `iva/iva123`, `ana/ana123`, `pera/pera123`

---

