namespace BrightonVibe.Domain.Entities;

public class VenueImage
{
    public Guid Id { get; set; }
    public Guid VenueId { get; set; }
    public string ImageUrl { get; set; }
    public bool Featured { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; init; }
}