# FlexyBox Developer Test Project

FlexyBox er en selvhostet restaurant-oversigtsapplikation med en Blazor WebAssembly-frontend, en .NET Web API-backend og et modulært design baseret på Clean Architecture. Applikationen indeholder responsive komponenter, caching der fungerer offline, og en fallback-løsning til billeder for at sikre en problemfri brugeroplevelse. Funktionerne er beskrevet i et billede, men da designet kun var vist i en bredde på 640 px, har jeg gjort siden responsiv ud fra det.

## Overblik

Dette projekt er en fuldt ud selvkørende applikation med en **Blazor WebAssembly** frontend og en **.NET Web API** backend. Det er struktureret efter **Clean Architecture** principper for at sikre høj grad af adskillelse, testbarhed og genbrugelighed.^
Det skal benyttes som en udviklertest for flexybox.


## Billede, der beskriver hvordan de skal se ud.
![image](https://github.com/user-attachments/assets/815f39d5-4491-483a-9d60-6bc944bb6ee8)

Billedet hertil er lavet for 648 bredde skærm, så har skaleret det op ift. ipad og pc-skærm

## Endelig Resultat
![image](https://github.com/user-attachments/assets/a22fbd20-bad7-402a-86f2-755e80aea0e1)
![image](https://github.com/user-attachments/assets/ee01c9f7-70c7-452e-939e-5823bb96e877)
![image](https://github.com/user-attachments/assets/e39941e5-05b1-4428-83c4-15717d4d27f7)


## Arkitektur og Designmønstre

* **Clean Architecture**: Projektet er opdelt i lag (Domain, Application, Infrastructure, WebUI) for at sikre klar adskillelse af ansvar.
* **MediatR & CQRS**: Anvendt i Application-laget & Presentationslaget for at håndtere forespørgsler (Queries) sendt fra presentationslaget og kommandoer (Commands) på en ensartet måde.
* **Generic Repository & Unit of Work**: I Infrastructure-laget for at standardisere dataadgang og sikre atomare transaktioner.
* **Dependency Injection**: Konfigureret i både API og Blazor for at give løs kobling.

## Funktioner

* **Restaurationsliste**: kortbaserede visninger med navigation til detaljer via "/".
* **Detaljevisning**: Visning af ét enkelt `ResturantDTO` via rute `restaurant/{id}`.
* **Favorit-tilføjelse**: Gemmer brugers favorit-restauranter i `localStorage` med userId og likedRestaurants.
* **StatusToggle**: Åben/lukket-knap bunden til DTO’s `Open`-property.
* **ActionBtns**: Konsistente genbrugelige knapper (telefon, e-mail, audio guide).
* **Responsive design**: Siden justerer automatisk font og layout responsivt baseret på brugerens skærmstørrelse.
* **ImageWithFallback**: Wrapper-komponent der falder tilbage til placeholder, hvis billed-URL ikke findes.
* **SEED Data**: `SeedData`-klasse i Infrastructure initierer databasen med testdata (FlexyBox) på første kørsel.
* **CI Pipeline** Created an Github Action that automatically test the code of this repo.

## Optional Enhancements

Overvejelser over ekstra krav.

* Brugerautentificering og -autorisation (Azure AD, IdentityServer).
* Filuploads for restaurationsbilleder.
* Avanceret filtrering og søgning på restauranter.
* Dark mode eller tema-skift.
* 2 billeder på ipad, 3-4 på skærm 

## Installations- og Kørselinstruktioner

Åbn i visual studio, on upstart it should create a local database with the name flexybox.

ONLY The first resturant adheres 100 % to the design, since everything else is seeded data, to check for errors. (and test closed as well)


## Oversigt over Implementerede Features

| Feature                  | Beskrivelse                                    |
| ------------------------ | ---------------------------------------------- |
| Clean Architecture       | Layers for Domain, Application, Infrastructure |
| MediatR & CQRS           | Queries & Commands pattern                     |
| Generic Repository + UoW | Data access abstraction                        |
| Favorit-håndtering       | `localStorage` persistence                     |
| Responsiv billedslider   | Auto-play + swipe/key navigation               |
| Genbrugelige Komponenten | Card, Accordion, StatusToggle, ActionBtns      |
| SeedData                 | Automatisk databaseinitialisering              |
| ImageWithFallback        | Håndtering af manglende billeder               |

## Yderligere Bemærkninger

* Projektet er sat op med **Strict Null-Checks** og **C# 10**
* **Blazor WebAssembly** kombineret med **.NET 6** giver både klient- og serverkode i samme løsning.
* CSS anvender **CSS Variables** for nemt tema/bytte af farver.
* JS-interops er minimalt og indkapslet i `slider.js` for bedre performance.

Kontakt mig endelig, hvis noget skal uddybes!
