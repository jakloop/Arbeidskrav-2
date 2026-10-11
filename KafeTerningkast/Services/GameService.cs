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
            MaxPlayers = 4,
            PlayTimeMinutes = 90,
            Category = "",
            Rating = 5,
            Description = "Strategispill"
        },
        new BoardGame
        {
            Id = 2,
            Name = "Risk",
            MinPlayers = 3,
            MaxPlayers = 4,
            PlayTimeMinutes = 90,
            Category = "",
            Rating = 5,
            Description = "Strategispill"
        },

        new BoardGame
        {
            Id = 3,
            Name = "Yatzee",
            MinPlayers = 1,
            MaxPlayers = 6,
            PlayTimeMinutes = 90,
            Category = "",
            Rating = 5,
            Description = "Terningspill"
        },
        new BoardGame
        {
            Id = 4,
            Name = "Monopol",
            MinPlayers = 2,
            MaxPlayers = 4,
            PlayTimeMinutes = 90,
            Category = "",
            Rating = 5,
            Description = "Strategispill"
        },

        new BoardGame
        {
            Id = 5,
            Name = "Poker Texas Hold'em",
            MinPlayers = 2,
            MaxPlayers = 8,
            PlayTimeMinutes = 90,
            Category = "",
            Rating = 5,
            Description = "Kortspill"
        },

        new BoardGame
        {
            Id = 6,
            Name = "Sjakk",
            MinPlayers = 2,
            MaxPlayers = 2,
            PlayTimeMinutes = 90,
            Category = "",
            Rating = 5,
            Description = "Brettspill"
        },

        new BoardGame
        {
            Id = 7,
            Name = "Othello",
            MinPlayers = 2,
            MaxPlayers = 2,
            PlayTimeMinutes = 90,
            Category = "",
            Rating = 5,
            Description = "Brettspill"
        },

        new BoardGame
        {
            Id = 8,
            Name = "Bezzerwizzer",
            MinPlayers = 2,
            MaxPlayers = 2,
            PlayTimeMinutes = 90,
            Category = "",
            Rating = 5,
            Description = "Quizspill"
        }
    };

    public List<BoardGame> GetAllGames()
    {
        return _games;
    }
    
    // add game()?
    // remove game()?
    
    
}