using KafeTerningkast.Models;

namespace KafeTerningkast.Services;

public class GameService
{
    private readonly List<BoardGame> _games = new()
    {
        new BoardGame
        {
            Id = 1,
            Name = "Den forvunnede diamant",
            MinPlayers = 2,
            MaxPlayers = 5,
            PlayTimeMinutes = 30,
            Category = "Familiespill",
            Rating = 4,
            Description = "Et kappløp på det afrikanske kontinentet på leting etter den verdifulle diamanten"
        },
        new BoardGame
        {
            Id = 2,
            Name = "Risk",
            MinPlayers = 2,
            MaxPlayers = 6,
            PlayTimeMinutes = 120,
            Category = "Strategi",
            Rating = 5,
            Description = "Et strategispill hvor du jobber for globalt herredømme"
        },

        new BoardGame
        {
            Id = 3,
            Name = "Yatzy",
            MinPlayers = 1,
            MaxPlayers = 6,
            PlayTimeMinutes = 20,
            Category = "Terningspill",
            Rating = 5,
            Description = "Klassikeren Yatsy er et terningspill hvor du skal sikre deg den beste poengscoren"
        },
        new BoardGame
        {
            Id = 4,
            Name = "Monopol",
            MinPlayers = 2,
            MaxPlayers = 6,
            PlayTimeMinutes = 90,
            Category = "Familiespill",
            Rating = 2,
            Description = "Kjøp eiendommer, bygg hus og hoteller, og slå motstanderne dine konkurs."
        },

        new BoardGame
        {
            Id = 5,
            Name = "Poker Texas Hold'em",
            MinPlayers = 2,
            MaxPlayers = 10,
            PlayTimeMinutes = 60,
            Category = "Kortspill",
            Rating = 5,
            Description = "Det mest populære pokerspillet i verden, basert på taktikk, psykologi og sannsynlighet."
        },

        new BoardGame
        {
            Id = 6,
            Name = "Sjakk",
            MinPlayers = 2,
            MaxPlayers = 2,
            PlayTimeMinutes = 45,
            Category = "Strategi",
            Rating = 6,
            Description = "Det ultimate duellspillet med dyp taktikk."
        },

        new BoardGame
        {
            Id = 7,
            Name = "Othello",
            MinPlayers = 2,
            MaxPlayers = 2,
            PlayTimeMinutes = 20,
            Category = "Strategi",
            Rating = 4,
            Description = "Et strategispill det tar et minutt å lære, men en mannsalder å mestre"
        },

        new BoardGame
        {
            Id = 8,
            Name = "Bezzerwizzer",
            MinPlayers = 2,
            MaxPlayers = 6,
            PlayTimeMinutes = 45,
            Category = "Quiz",
            Rating = 5,
            Description = "Et kunnskapsspill der du kan stjele motstanderens spørsmål og briljere med egen kunnskap."
        }
    };

    public List<BoardGame> GetAllGames()
    {
        return _games;
    }
    
    // add game()?
    // remove game()?
    
    
}