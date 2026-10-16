# Arbeidskrav 2 - Modul 2: Software Design
 - Dato: 9. oktober - 30. oktober 2026

# Filtre



# Oppgave 1 - GameCard sitt ansvar
Som en del av oppgave 1 skal man forklare ansvarsfordelingen i programmet (så langt).

1. GameCard
GameCard tar inn et enkelt BoardGame-objekt og brukes når man skal vise et enkelt spill. GameCard
brukes senere når spillene skal vises visuelt i /games.


2. Games.razor
De ulike spillene lages i GameService.cs og kan hentes med funksjonen GetAllGames(). 
Games.razor håndterer spillsøk, filtrering, antall søk, og visningen av spill. Visningen av spill fungerer slik
at alle spill hentes via OnIntialized(), slik at List<BoardGame> _games inneholder alle spillene.

```
    protected override void OnInitialized()
    {
        _games = GameService.GetAllGames();
    }
```
Deretter så filtreres hva som vises til brukeren gjennom FilteredGames. Her kontrolleres spillene opp mot
søkefeltet og antall spillere, og det returneres som en liste.

FilteredGames.Count brukes også for å vise antall treff.

Når det kommer til "trill terning" funksjonaliteten så har jeg løst dette ved å lage komponenten
EnhanceGameCard og FindRandomGame. FindARandomGame() tar inn en filtrert liste av spill (List<BoardGame> FilteredGames) og velger
et spill basert på en tilfeldig index i listen.

## Tester Oppgave 1
I denne oppgaven har jeg gjennomført følgende manuelle tester:

# Testtabell

| Hva testes?                                              | Forventet resultat          | Faktisk resultat            | Bestått? |
|:---------------------------------------------------------|:----------------------------|:----------------------------|:---------|
| Søk etter eksisterende spill, med store og små bokstaver | Spillene vises              | Spillene vises              | Bestått  |
| Søke etter spill som ikke finnes                         | Spillene vises ikke         | Spillene vises ikke         | Bestått  |
| Test grenseverdier for antall spillere                   | Riktige spill vises         | Riktige spill vises         | Bestått  |
| Test spillerfilteret for antall spillere                 | Riktige spill vises         | Riktige spill vises         | Bestått  |
| Tilfeldig spill                                          | Et spill flyttes til toppen | Et spill flyttes til toppen | Bestått  |
| Hele spillsamlingen vises når søkefeltet er tomt         | Viser alle spill            | Viser alle spill            | Bestått  |

Kilder:
Bootstrap card "Horizontal" - https://getbootstrap.com/docs/5.3/components/card/#grid-cards