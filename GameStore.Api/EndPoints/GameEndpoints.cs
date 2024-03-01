using GameStore.Api.Entities;
using GameStore.Api.Repositories;

namespace GameStore.Api.EndPoints;

public static class GameEndpoints
{
    const string GetGameEndpointName = "GetGame";
    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    {
        var gamesRouteGroup = routes.MapGroup("/games").WithParameterValidation();

        //  Get games endpoint
        gamesRouteGroup.MapGet("", (IGamesRepository repo) => repo.GetAll());

        //  Get game by Id endpoint
        gamesRouteGroup
            .MapGet(
                "/{id}",
                (int id, IGamesRepository repo) =>
                {
                    Game? game = repo.Get(id);
                    return game is not null ? Results.Ok(game) : Results.NotFound();
                }
            )
            .WithName(GetGameEndpointName);

        // Post game endpoint
        gamesRouteGroup.MapPost(
            "/",
            (Game game, IGamesRepository repo) =>
            {
                repo.Create(game);
                return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game);
            }
        );

        // Put game endpoint
        gamesRouteGroup.MapPut(
            "/{id}",
            (int id, Game updatedGame, IGamesRepository repo) =>
            {
                Game? existingGame = repo.Get(id);
                if (existingGame is null)
                    return Results.NotFound();
                existingGame.Name = updatedGame.Name;
                existingGame.Genre = updatedGame.Genre;
                existingGame.Price = updatedGame.Price;
                existingGame.ReleaseDate = updatedGame.ReleaseDate;
                existingGame.ImageUrl = updatedGame.ImageUrl;

                repo.Update(existingGame);
                return Results.NoContent();
            }
        );

        // Delete game endpoint
        gamesRouteGroup.MapDelete(
            "/{id}",
            (int id, IGamesRepository repo) =>
            {
                Game? game = repo.Get(id);
                if (game is not null)
                    repo.Delete(id);
                return Results.NoContent();
            }
        );
        return gamesRouteGroup;
    }
}
