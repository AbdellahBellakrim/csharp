using GameStore.Api.Dtos;
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
        gamesRouteGroup.MapGet("", async (IGamesRepository repo) => (await repo.GetAllAsync()).Select(game => game.AsDto()));

        //  Get game by Id endpoint
        gamesRouteGroup
            .MapGet(
                "/{id}",
                async (int id, IGamesRepository repo) =>
                {
                    Game? game = await repo.GetAsync(id);
                    return game is not null ? Results.Ok(game.AsDto()) : Results.NotFound();
                }
            )
            .WithName(GetGameEndpointName);

        // Post game endpoint
        gamesRouteGroup.MapPost(
            "/",
            async (CreateGameDto gameDto, IGamesRepository repo) =>
            {
                Game game = new()
                {
                    Name = gameDto.Name,
                    Genre = gameDto.Genre,
                    Price = gameDto.Price,
                    ReleaseDate = gameDto.ReleaseDate,
                    ImageUrl = gameDto.ImageUrl
                };
                await repo.CreateAsync(game);
                return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.Id }, game.AsDto());
            }
        );

        // Put game endpoint
        gamesRouteGroup.MapPut(
            "/{id}",
            async (int id, UpdateGameDto updatedGameDto, IGamesRepository repo) =>
            {
                Game? existingGame = await repo.GetAsync(id);
                if (existingGame is null)
                    return Results.NotFound();
                existingGame.Name = updatedGameDto.Name;
                existingGame.Genre = updatedGameDto.Genre;
                existingGame.Price = updatedGameDto.Price;
                existingGame.ReleaseDate = updatedGameDto.ReleaseDate;
                existingGame.ImageUrl = updatedGameDto.ImageUrl;

                await repo.UpdateAsync(existingGame);
                return Results.NoContent();
            }
        );

        // Delete game endpoint
        gamesRouteGroup.MapDelete(
            "/{id}",
            async (int id, IGamesRepository repo) =>
            {
                Game? game = await repo.GetAsync(id);
                if (game is not null)
                    await repo.DeleteAsync(id);
                return Results.NoContent();
            }
        );
        return gamesRouteGroup;
    }
}
