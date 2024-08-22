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
    /// Asynchronously retrieves a VenueCategory by its slug and throws an exception if not found.
    /// </summary>
    /// <param name="venueCategorySlug">The slug of the venue category to retrieve.</param>
    /// <returns>
    /// A task that represents the asynchronous operation. The task result contains the 
    /// <see cref="VenueCategory"/> object corresponding to the provided slug.
    /// </returns>
    /// <exception cref="VenueCategoryNotFoundException">
    /// Thrown if no venue category with the specified slug is found.
    /// </exception>
    public async Task<VenueCategory> GetVenueCategoryBySlugAsync(string venueCategorySlug)
    {
        var venueCategory = await _venueCategoryRepository.GetVenueCategoryBySlugAsync(venueCategorySlug);
        
        if (venueCategory is null)
        {
            throw new VenueCategoryNotFoundException();
        }

        return venueCategory;
    }
}