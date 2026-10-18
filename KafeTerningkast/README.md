# Arbeidskrav 2 - Modul 2: Software Design
 - Dato: 9. oktober - 30. oktober 2026

# Filtre



# Oppgave 1 - Ansvarsfordeling og testresultat
Som en del av oppgave 1 skal man forklare ansvarsfordelingen i programmet (så langt).

1. GameCard
GameCard tar inn et enkelt BoardGame-objekt og brukes når man skal vise et enkelt spill. GameCard
brukes senere når spillene skal vises visuelt i /games. Her printer man eksempelvis ut flere GameCard som viser
ulike verdier basert på hvilket BoardGame-objekt de har mottatt. 


2. Games.razor
Games.razor håndterer spillsøk, filtrering, antall søk, og visningen av spill. Visningen av spill fungerer slik
at alle spill hentes via OnIntialized(), slik at List<BoardGame> _games inneholder alle spillene.

```
    protected override void OnInitialized()
    {
        _games = GameService.GetAllGames();
    }
```
Deretter så filtreres hva som vises til brukeren gjennom FilteredGames. Her kontrolleres spillene opp mot
søkefeltet og antall spillere, og det returneres som en liste. FilteredGames.Count brukes også for å vise antall treff.

Når det kommer til "trill terning" funksjonaliteten så har jeg løst dette ved å lage komponenten
EnhanceGameCard og FindRandomGame. FindARandomGame() tar inn en filtrert liste av spill (List<BoardGame> FilteredGames) og velger
et spill basert på en tilfeldig index i listen.

## Tester Oppgave 1
I denne oppgaven har jeg gjennomført følgende manuelle tester:

### Testtabell - oppgave 1

| Hva testes?                                              | Forventet resultat          | Faktisk resultat            | Bestått? |
|:---------------------------------------------------------|:----------------------------|:----------------------------|:---------|
| Søk etter eksisterende spill, med store og små bokstaver | Spillene vises              | Spillene vises              | Bestått  |
| Søke etter spill som ikke finnes                         | Spillene vises ikke         | Spillene vises ikke         | Bestått  |
| Test grenseverdier for antall spillere                   | Riktige spill vises         | Riktige spill vises         | Bestått  |
| Test spillerfilteret for antall spillere                 | Riktige spill vises         | Riktige spill vises         | Bestått  |
| Tilfeldig spill                                          | Et spill flyttes til toppen | Et spill flyttes til toppen | Bestått  |
| Hele spillsamlingen vises når søkefeltet er tomt         | Viser alle spill            | Viser alle spill            | Bestått  |


# Oppgave 2 -


### Testtabell - oppgave 2

| Hva testes?                                              | Forventet resultat        | Faktisk resultat          | Bestått? |
|:---------------------------------------------------------|:--------------------------|:--------------------------|:---------|
| Åpne games/ med en ID som ikke finnes                    | Fant ikke spillet         | Fant ikke spillet         | Bestått  |
| Åpne /games/abc                                          | Not found                 | Not found                 | Bestått  |
| Forelder får riktig verdi når man trykker på terningkast | Forleder får riktig verdi | Forelder får riktig verdi | Bestått  |
| DiceRating er Readonly og ikke klikkbar i /games         | Readonly fungerer         | Readonly fungerer         | Bestått  |
| Verdi utenfor 1-6                                        | Ugyldig verdi             | Ugydlig verdi             | Bestått  |
| Menyen er markert og følger siden jeg er på              | Markert                   | Markert                   | Bestått  |

### Forklaring for hvorfor games/abc ikke treffer spillsiden
Den treffer ikke spillsiden, fordi verdien {game.Id} er en integer. Dermed så feiler navigeringen til spillsiden
og man får opp feilmeldingen

### DiceRating får en ugyldig verdi

I det ene kanttilfellet så sender man en verdi utenfor 1-6 inn til DiceRating. Dette gjøres ved å legge inn denne 
linjen i GameDetails.razor

```
    <DiceRating Value="7" ReadOnly="true" />
```
Svaret jeg får er TerningKast: 7 - som er en ugydlig verdi. 

Dette kanttilfellet løste jeg med en enkel if-setning i DiceRating.razor som kontrollerer om verdien er mellom 1 og 6.
Hvis den er ugyldig nå så vil meldingen "ugyldig terningkast" vises.  Komponenten endrer altså ikke den ugyldige verdien men viser en feilmelding. 



Kilder:
Bootstrap card "Horizontal" - https://getbootstrap.com/docs/5.3/components/card/#grid-cards