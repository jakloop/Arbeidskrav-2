using KafeTerningkast.Models;

namespace KafeTerningkast.Services;


public class GameNightState
{
    private List<BoardGame> selectedGames = new();

    public void AddGame(BoardGame game)
    {
        if (!selectedGames.Any(g => g.Id == game.Id))
        {
            selectedGames.Add(game);
        }
    }

    public void RemoveGame(BoardGame game)
    {
        if (selectedGames.Any( g=> g.Id == game.Id))
        {
            selectedGames.Remove(game);
        }
    }

    public IReadOnlyList<BoardGame> GetAllGameNightGames()
    {
        return selectedGames.AsReadOnly();
    }
}