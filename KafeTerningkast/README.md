# Arbeidskrav 2 - Modul 2: Software Design
 - Dato: 9. oktober - 30. oktober 2026
 - 


# Oppgave 1 - GameCard sitt ansvar
Som en del av oppgave 1 skal man forklare hvilket ansvar GameCard har og hvorfor
ansvaret er delt. I oppgaven står det at man skal lage komponenten GameCard som brukes til å vise det aktuelle spillet.
GameCard tar inn parameteret BoardGame er en klasse med de ulike spillene. 

Siden, /games, 
Denne komponenten får spillet inn som et parameter og har ikke ansvar for listen. I min løsning



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

Sources:

Bootstrap card "Horizontal" - https://getbootstrap.com/docs/5.3/components/card/#grid-cards