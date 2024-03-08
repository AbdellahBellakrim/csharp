using CityInfo.Api.src.models;

namespace CityInfo.Api.src.dataStores;
public class CitiesDataStore
{
    public List<CityDto> Cities { get; set; }
    // public static CitiesDataStore Current { get; } = new CitiesDataStore();
    public CitiesDataStore()
    {
        Cities = new List<CityDto>(){
            new CityDto(){
                Id = 1,
                Name = "Marrakech",
                Description = "The best envirement for your child to live in.",
                PointsOfInterest = new List<PointsOfInterestDto>(){
                    new PointsOfInterestDto(){
                        Id = 1,
                        Name = "Koutoubia Mosque",
                        Description = "The largest mosque in Marrakech."
                    },
                    new PointsOfInterestDto(){
                        Id = 2,
                        Name = "Jardin Majorelle",
                        Description = "The Majorelle Garden is a two and half acre botanical garden and artist's landscape garden in Marrakech."
                    }
                }
            },
            new CityDto(){
                Id = 2,
                Name = "Antwerp",
                Description = "The one with the cathedral that was never really finished.",
                PointsOfInterest = new List<PointsOfInterestDto>(){
                    new PointsOfInterestDto(){
                        Id = 1,
                        Name = "Antwerp Central Station",
                        Description = "The finest example of railway architecture in Belgium"
                    },
                    new PointsOfInterestDto(){
                        Id = 2,
                        Name = "Antwerp Zoo",
                        Description = "The oldest animal park in the country, and one of the oldest in the world."
                    }
                }
            },
            new CityDto(){
                Id = 3,
                Name = "Paris",
                Description = "The one with that big tower.",
                PointsOfInterest = new List<PointsOfInterestDto>(){
                    new PointsOfInterestDto(){
                        Id = 1,
                        Name = "Paris Tower",
                        Description = "The tallest structure in Paris and the most-visited paid monument in the world."
                    },
                    new PointsOfInterestDto(){
                        Id = 2,
                        Name = "Paris Zoo",
                        Description = "The zoo is home to about 2,000 animals representing more than 180 species."
                    }
                }
            }
        };
    }
}