namespace BrightonVibe.Domain.Entities;

public class VenueCategory
{
    public Guid Id { get; set; }
    public string Slug { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }

    #region Navigation properties

    public ICollection<VenueType> VenueTypes { get; set; } = new List<VenueType>();

    #endregion
}