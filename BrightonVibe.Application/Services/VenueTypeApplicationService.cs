using BrightonVibe.Application.Exceptions;
using BrightonVibe.Domain.Entities;
using BrightonVibe.Domain.Interfaces;

namespace BrightonVibe.Application.Services;

public class VenueTypeApplicationService
{
    private readonly IVenueTypeRepository _venueTypeRepository;

    public VenueTypeApplicationService(
        IVenueTypeRepository venueTypeRepository)
    {
        _venueTypeRepository = venueTypeRepository;
    }
    
    /// <summary>
    /// Asynchronously retrieves a venue Type by its unique identifier.
    /// </summary>
    /// <param name="venueTypeId">The unique identifier of the venue Type to retrieve.</param>
    /// <returns>A <see cref="VenueType"/> object representing the venue Type with the specified ID, if found.</returns>
    /// <exception cref="VenueTypeNotFoundException">Thrown when a venue Type with the specified ID does not exist in the repository.</exception>
    public async Task<VenueType> GetVenueTypeByIdAsync(Guid venueTypeId)
    {
        var venueType = await _venueTypeRepository.GetVenueTypeByIdAsync(venueTypeId);
        
        if (venueType is null)
        {
            throw new VenueTypeNotFoundException();
        }

        return venueType;
    }
}