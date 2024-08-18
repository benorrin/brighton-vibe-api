namespace BrightonVibe.Application.Exceptions;

public class VenueNotFoundException : Exception
{
    public Guid VenueId { get; }

    public VenueNotFoundException(Guid venueId) 
        : base($"Venue with ID {venueId} not found.")
    {
        VenueId = venueId;
    }
}