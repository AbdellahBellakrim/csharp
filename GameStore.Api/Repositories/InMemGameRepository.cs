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

    public IEnumerable<Game> GetAll()
    {
        return games;
    }

    public Game? Get(int Id)
    {
        return games.Find(game => game.Id == Id);
    }

    public void Create(Game game)
    {
        game.Id = games.Max(game => game.Id) + 1;
        games.Add(game);
    }

    public void Update(Game updatedGame)
    {
        var index = games.FindLastIndex(game => game.Id == updatedGame.Id);
        games[index] = updatedGame;
    }

    public void Delete(int Id)
    {
        var index = games.FindIndex(game => game.Id == Id);
        games.RemoveAt(index);
    }
}