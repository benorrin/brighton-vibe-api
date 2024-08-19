using BrightonVibe.Application.Exceptions;
using BrightonVibe.Domain.Entities;
using BrightonVibe.Domain.Interfaces;

namespace BrightonVibe.Application.Services;

public class VenueCategoryApplicationService
{
    private readonly IVenueCategoryRepository _venueCategoryRepository;

    public VenueCategoryApplicationService(
        IVenueCategoryRepository venueCategoryRepository)
    {
        _venueCategoryRepository = venueCategoryRepository;
    }
    
    /// <summary>
    /// Asynchronously retrieves a venue category by its unique identifier.
    /// </summary>
    /// <param name="venueCategoryId">The unique identifier of the venue category to retrieve.</param>
    /// <returns>A <see cref="VenueCategory"/> object representing the venue category with the specified ID, if found.</returns>
    /// <exception cref="VenueCategoryNotFoundException">Thrown when a venue category with the specified ID does not exist in the repository.</exception>
    public async Task<VenueCategory> GetVenueCategoryByIdAsync(Guid venueCategoryId)
    {
        var venueCategory = await _venueCategoryRepository.GetVenueCategoryByIdAsync(venueCategoryId);
        
        if (venueCategory is null)
        {
            throw new VenueCategoryNotFoundException();
        }

        return venueCategory;
    }
}