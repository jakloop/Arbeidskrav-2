# Arbeidskrav 2 - Modul 2: Software Design
 - Dato: 9. oktober - 30. oktober 2026

# Filtre



# Oppgave 1 - Ansvarsfordeling og testresultat
Som en del av oppgave 1 skal man forklare ansvarsfordelingen i programmet (så langt).

- GameCard
GameCard tar inn et enkelt BoardGame-objekt og brukes når man skal vise et enkelt spill. GameCard
brukes senere når spillene skal vises visuelt i /games. Her printer man eksempelvis ut flere GameCard som viser
ulike verdier basert på hvilket BoardGame-objekt de har mottatt. 

- Games.razor
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


# Oppgave 2 - Terningkast og Spillsider


### Testtabell - oppgave 2

| Hva testes?                                              | Forventet resultat        | Faktisk resultat          | Bestått? |
|:---------------------------------------------------------|:--------------------------|:--------------------------|:---------|
| Åpne games/ med en ID som ikke finnes                    | Finner ikke spillet       | Fant ikke spillet         | Bestått  |
| Åpne /games/abc                                          | Not found                 | Not found                 | Bestått  |
| Forelder får riktig verdi når man trykker på terningkast | Forelder får riktig verdi | Forelder får riktig verdi | Bestått  |
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

# Oppgave 3

### Testing – Oppgave 3: Spillekveld

| Test                                                                     | Forventet resultat                         | Faktisk resultat                       | Status  |
|:-------------------------------------------------------------------------|:-------------------------------------------|:---------------------------------------|:--------|
| Legge til spill fra spillhylla                                           | Spillet legges til i spillekvelden         | Spillet ble lagt til                   | Bestått |
| Gå til en spillside og tilbake, og kontroller at spillkvelden er uendret | Spillkvelden er uendret                    | Spillkvelden er uendret                | Bestått |
| Forsøk å legge til samme spill to ganger                                 | Kun et av spillet dukker opp i GameNight   | Kun et spill dukker opp i GameNight    | Bestått |
| Fjerne spill fra spillekveldsiden og viser tom tilstand                  | Spillet fjernes fra listen og tom-tilstand | Spillet ble fjernet og tom-tilstand    | Bestått |
| Vise samlet spilletid på 3 spill (30 + 50 + 120)                         | Riktig spilltid vises i GameNight          | Riktig spilltid vises i GameNight      | Bestått |
| To faner i Scoped                                                        | De skal ikke påvirke hverandre             | De påvirker ikke hverandre             | Bestått |
| Spillhylla i ulike bredder (repsonsivt)                                  | Sidene tilpasser seg de ulike breddene     | Sidene tilpasset seg de ulike breddene | Bestått |




#### Prøve å legge in to eksemplarer av spillet
Dette testet jeg ved å kjøre AddGame to ganger på det samme spillet.
```
    protected override void OnInitialized()
    {
        var game = GameService.GetAllGames().First();
        GameNightState.AddGame(game);
        GameNightState.AddGame(game);
    }
```
Det dukket kun opp ett spill i razor

#### Begrunnelse for levetiden til tilstandstjenesten GameNightState
Tilstand handler om hvilken informasjon applikasjonen husker og bruker for å bestemme hva som vises.

I program.cs har jeg lagt inn
```
builder.Services.AddScoped<GameNightState>();
```
Jeg har lagt inn GameNightState som en scoped tilstand for å skille mellom hva ulike brukere/
faner ser. Når man legger inn addscoped så betyr det at det opprettes en GameNightState per tilkobling.
Komponentene innenfor samme tilkobling deler denne instansen (f.eks. /games, gamecard, gamedetails), slik at spillene jeg legger til på 
spillhylla også vises i spillekveldssiden. 

Jeg ønsker at brukerne bare skal være i stand til å se sine egne spillkvelder.
Om man lager to ulike faner så vil ikke spillene man legger inn i gamenight i den ene
fanen påvirke den andre.

Dersom jeg hadde valgt Singleton, ville alle brukerne på samme serverinstans delt den samme spillekvelden.
Spill som en bruker legger til, kunne derfor også dukket opp hos andre brukere.

Jeg har valgt Singleton i GameService, som inneholder spillene og funksjonen GetAllGames(). Dette er fordi
alle brukerne skal ha tilgang til den samme spillkatalogen.

#### Skjermbilder av Spillhylla i ulike bredder

- ![375px visning](images/skjermbredde375px.png)

- ![1600px visning](images/skjermbredde1600px.png)


Kilder:
Bootstrap card "Horizontal" - https://getbootstrap.com/docs/5.3/components/card/#grid-cards