

using Microsoft.EntityFrameworkCore;

namespace CityInfo.Api.src.dbContexts;

public class CityInfoContext : DbContext
{
    public CityInfoContext(DbContextOptions<CityInfoContext> options)
    : base(options)
    {
    }
    public DbSet<entities.City> Cities { get; set; } = null!;
    public DbSet<entities.PointOfInterest> PointsOfInterest { get; set; } = null!;
}