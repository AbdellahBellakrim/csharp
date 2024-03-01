using GameStore.Api.Entities;

namespace GameStore.Api.Repositories;

public interface IGamesRepository
{
    void Create(Game game);
    void Delete(int Id);
    IEnumerable<Game> GetAll();
    Game? Get(int Id);
    void Update(Game updatedGame);
}
