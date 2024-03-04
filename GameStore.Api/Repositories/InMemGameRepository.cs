using GameStore.Api.Entities;

namespace GameStore.Api.Repositories;
public class InMemGamesRepository : IGamesRepository
{
    private readonly List<Game> games =
    new()
    {
            new Game()
            {
                Id = 1,
                Name = "The Witcher 3",
                Genre = "RPG",
                Price = 29.99M,
                ReleaseDate = new DateTime(2015, 5, 19),
                ImageUrl = "https://placehold.co/100"
            },
            new Game()
            {
                Id = 2,
                Name = "Cyberpunk 2077",
                Genre = "RPG",
                Price = 59.99M,
                ReleaseDate = new DateTime(2020, 12, 10),
                ImageUrl = "https://placehold.co/100"
            },
            new Game()
            {
                Id = 3,
                Name = "Doom Eternal",
                Genre = "FPS",
                Price = 49.99M,
                ReleaseDate = new DateTime(2020, 3, 20),
                ImageUrl = "https://placehold.co/100"
            }
    };

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await Task.FromResult(games);
    }

    public async Task<Game?> GetAsync(int Id)
    {
        return await Task.FromResult(games.Find(game => game.Id == Id));
    }

    public async Task CreateAsync(Game game)
    {
        game.Id = games.Max(game => game.Id) + 1;
        games.Add(game);
        await Task.CompletedTask;
    }

    public async Task UpdateAsync(Game updatedGame)
    {
        var index = games.FindLastIndex(game => game.Id == updatedGame.Id);
        games[index] = updatedGame;
        await Task.CompletedTask;
    }

    public async Task DeleteAsync(int Id)
    {
        var index = games.FindIndex(game => game.Id == Id);
        games.RemoveAt(index);
        await Task.CompletedTask;
    }
}