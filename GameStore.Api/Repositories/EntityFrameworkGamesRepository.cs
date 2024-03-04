using GameStore.Api.data;
using GameStore.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Repositories;

public class EntityFrameworkGamesRepository : IGamesRepository
{
    private readonly GameStoreContext _dbContext;

    public EntityFrameworkGamesRepository(GameStoreContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<Game>> GetAllAsync()
    {
        return await _dbContext.Games.AsNoTracking().ToListAsync();
    }
    public async Task<Game?> GetAsync(int Id)
    {
        return await _dbContext.Games.FindAsync(Id);
    }

    public async Task CreateAsync(Game game)
    {
        _dbContext.Games.Add(game);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Game updatedGame)
    {
        _dbContext.Games.Update(updatedGame);
        await _dbContext.SaveChangesAsync();
    }
    public async Task DeleteAsync(int Id)
    {
        await _dbContext.Games.Where(game => game.Id == Id).ExecuteDeleteAsync();
    }
}