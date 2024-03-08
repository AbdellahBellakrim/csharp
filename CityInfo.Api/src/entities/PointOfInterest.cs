
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CityInfo.Api.src.entities;

public class PointOfInterest
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }

    public string? Description { get; set; }

    // this is the foreign key property : we use it to create a relationship between the City and PointOfInterest entities, (this property is not required, only for clarity purposes)
    [ForeignKey("CityId")]
    public City? City { get; set; }
    public int CityId { get; set; }

    public PointOfInterest(string name)
    {
        Name = name;
    }
}