using GameStore.Api.Entities;

namespace GameStore.Api.Repositories;

public interface IGamesRepository
{
    Task CreateAsync(Game game);
    Task DeleteAsync(int Id);
    Task<IEnumerable<Game>> GetAllAsync();
    Task<Game?> GetAsync(int Id);
    Task UpdateAsync(Game updatedGame);
}
