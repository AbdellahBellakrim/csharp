

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<entities.City>().HasData(
            new entities.City("New York City")
            {
                Id = 1,
                Description = "The one with that big park."
            },
            new entities.City("Antwerp")
            {
                Id = 2,
                Description = "The one with the cathedral that was never really finished."
            },
            new entities.City("Paris")
            {
                Id = 3,
                Description = "The one with that big tower."
            }
        );

        modelBuilder.Entity<entities.PointOfInterest>().HasData(
            new entities.PointOfInterest("Central Park")
            {
                Id = 1,
                CityId = 1
            },
            new entities.PointOfInterest("Empire State Building")
            {
                Id = 2,
                CityId = 1
            },
            new entities.PointOfInterest("The Cloisters")
            {
                Id = 3,
                CityId = 1
            },
            new entities.PointOfInterest("Cathedral of Our Lady")
            {
                Id = 4,
                CityId = 2
            },
            new entities.PointOfInterest("Antwerp Central Station")
            {
                Id = 5,
                CityId = 2
            },
            new entities.PointOfInterest("Eiffel Tower")
            {
                Id = 6,
                CityId = 3
            },
            new entities.PointOfInterest("The Louvre")
            {
                Id = 7,
                CityId = 3
            }
        );
        base.OnModelCreating(modelBuilder);
    }
}