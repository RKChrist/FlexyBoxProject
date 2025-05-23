# FlexyBox Project

**FlexyBox** is a self-hosted restaurant directory application featuring a Blazor WebAssembly frontend, a .NET Web API backend, and a modular Clean Architecture design. It provides responsive components, offline-ready caching, and an image-fallback mechanism for a seamless user experience.

## Overblik

Dette projekt er en fuldt ud selvk�rende applikation med en **Blazor WebAssembly** frontend og en **.NET Web API** backend. Det er struktureret efter **Clean Architecture** principper for at sikre h�j grad af adskillelse, testbarhed og genbrugelighed.

## Link til krav omkring features:
https://www.figma.com/design/BPYVMBj1ZgYK2U4gp218HU/Flexybook---DevTest?node-id=1-10282&t=Lod4mSn7BonpPL63-4

## Arkitektur og Designm�nstre

* **Clean Architecture**: Projektet er opdelt i layers (Domain, Application, Infrastructure, WebUI) for at sikre klar adskillelse af ansvar.
* **MediatR & CQRS**: Anvendt i Application-laget for at h�ndtere foresp�rgsler (Queries) og kommandoer (Commands) p� en ensartet m�de.
* **Generic Repository & Unit of Work**: I Infrastructure-laget for at standardisere dataadgang og sikre atomare transaktioner.
* **Dependency Injection**: Konfigureret i b�de API og Blazor for at give l�s kobling.

## Funktioner

* **Restaurationsliste**: kortbaserede visninger med navigation til detaljer.
* **Detaljevisning**: Visning af �t enkelt `ResturantDTO` via rute `restaurant/{id}`.
* **Favorit-tilf�jelse**: Gemmer brugers favorit-restauranter i `localStorage` med userId og likedRestaurants.
* **StatusToggle**: �ben/lukket-knap bunden til DTO�s `Open`-property.
* **ActionBtns**: Konsistente genbrugelige knapper (telefon, e-mail, audio guide).
* **Responsive design**: Siden justerer automatisk font og layout responsivt baseret p� brugerens sk�rmst�rrelse.
* **ImageWithFallback**: Wrapper-komponent der falder tilbage til placeholder, hvis billed-URL ikke findes.
* **SEED Data**: `SeedData`-klasse i Infrastructure initierer databasen med testdata (FlexyBox) p� f�rste k�rsel.
* **CI Pipeline** Created an Github Action that automatically test the code of this repo.

## Optional Enhancements

Overvejelser over ekstra krav.

* Brugerautentificering og -autorisation (Azure AD, IdentityServer).
* Filuploads for restaurationsbilleder.
* Avanceret filtrering og s�gning p� restauranter.
* Dark mode eller tema-skift.

## Installations- og K�rselinstruktioner

�bn i visual studio, on upstart it should create a local database with the name flexybox.

ONLY The first resturant adheres 100 % to the design, since everything else is seeded data, to check for errors. (and test closed as well)


## Oversigt over Implementerede Features

| Feature                  | Beskrivelse                                    |
| ------------------------ | ---------------------------------------------- |
| Clean Architecture       | Layers for Domain, Application, Infrastructure |
| MediatR & CQRS           | Queries & Commands pattern                     |
| Generic Repository + UoW | Data access abstraction                        |
| Favorit-h�ndtering       | `localStorage` persistence                     |
| Responsiv billedslider   | Auto-play + swipe/key navigation               |
| Genbrugelige Komponenten | Card, Accordion, StatusToggle, ActionBtns      |
| SeedData                 | Automatisk databaseinitialisering              |
| ImageWithFallback        | H�ndtering af manglende billeder               |

## Yderligere Bem�rkninger

* Projektet er sat op med **Strict Null-Checks** og **C# 10**
* **Blazor WebAssembly** kombineret med **.NET 6** giver b�de klient- og serverkode i samme l�sning.
* CSS anvender **CSS Variables** for nemt tema/bytte af farver.
* JS-interops er minimalt og indkapslet i `slider.js` for bedre performance.

Kontakt mig endelig, hvis noget skal uddybes!
