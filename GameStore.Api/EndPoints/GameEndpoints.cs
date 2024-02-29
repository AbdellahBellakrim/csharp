using GameStore.Api.Entities;

namespace GameStore.Api.EndPoints;

public static class GameEndpoints
{
    const string GetGameEndpointName = "GetGame";

    static List<Game> games =
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

    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var gamesRouteGroup = routes.MapGroup("/games").WithParameterValidation();

        //  Get games endpoint
        gamesRouteGroup.MapGet("", () => games);

        //  Get game by Id endpoint
        gamesRouteGroup
            .MapGet(
                "/{id}",
                (int id) =>
                {
                    Game? game = games.Find(g => g.Id == id);
                    if (game is null)
                        return Results.NotFound();
                    return Results.Ok(game);
                }
            )
            .WithName(GetGameEndpointName);

        // Post game endpoint
        gamesRouteGroup.MapPost(
            "/",
            (Game game) =>
            {
                game.Id = games.Max(game => game.Id) + 1;
                games.Add(game);

                return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
            }
        );

        // Put game endpoint
        gamesRouteGroup.MapPut(
            "/{id}",
            (int id, Game updatedGame) =>
            {
                Game? existingGame = games.Find(g => g.Id == id);
                if (existingGame is null)
                    return Results.NotFound();
                existingGame.Name = updatedGame.Name;
                existingGame.Genre = updatedGame.Genre;
                existingGame.Price = updatedGame.Price;
                existingGame.ReleaseDate = updatedGame.ReleaseDate;
                existingGame.ImageUrl = updatedGame.ImageUrl;
                return Results.NoContent();
            }
        );

        // Delete game endpoint
        gamesRouteGroup.MapDelete(
            "/{id}",
            (int id) =>
            {
                Game? game = games.Find(g => g.Id == id);
                if (game is not null)
                    games.Remove(game);
                return Results.NoContent();
            }
        );
        return gamesRouteGroup;
    }
}
