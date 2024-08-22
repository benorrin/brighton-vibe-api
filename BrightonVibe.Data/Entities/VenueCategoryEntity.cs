using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrightonVibe.Data.Entities;

[Table("venue_category")]
public class VenueCategoryEntity
{
    [Column("id")]
    public Guid Id { get; init; }
        
    [Column("slug")]
    public string Slug { get; init; }
        
    [Required]
    [MaxLength(25)]
    [Column("name")]
    public string Name { get; init; }
        
    [Required]
    [Column("description")]
    public string Description { get; init; }
        
    [Required]
    [Column("created_at")]
    public DateTime CreatedAt { get; init; }
    
    #region Navigation properties
    
    public ICollection<VenueTypeEntity> VenueTypes { get; init; } = new List<VenueTypeEntity>();
    
    #endregion Navigation properties

}