using KafeTerningkast.Models;

namespace KafeTerningkast.Services;


public class GameNightState
{
    private List<BoardGame> selectedGames = new();
    public event Action? OnChange;

    public void AddGame(BoardGame game)
    {
        if (!selectedGames.Any(g => g.Id == game.Id))
        {
            selectedGames.Add(game);
            OnChange?.Invoke();
        }
    }

    public void RemoveGame(BoardGame game)
    {
        var gameToRemove = selectedGames.FirstOrDefault(g => g.Id == game.Id);

        if (gameToRemove is not null)
        {
            selectedGames.Remove(gameToRemove);
            OnChange?.Invoke();
        }
    }

    public IReadOnlyList<BoardGame> GetAllGameNightGames()
    {
        return selectedGames.AsReadOnly();
    }
    
    public int Count => selectedGames.Count;
    
    public bool ContainsGame(int gameId)
    {
        return selectedGames.Any(g => g.Id == gameId);
    }
    
    
}