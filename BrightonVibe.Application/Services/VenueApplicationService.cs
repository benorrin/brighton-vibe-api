using BrightonVibe.Domain.Entities;
using BrightonVibe.Domain.Interfaces;
using BrightonVibe.Application.DTOs;
using BrightonVibe.Application.Exceptions;

namespace BrightonVibe.Application.Services;

public class VenueApplicationService
{
    private readonly IVenueRepository _venueRepository;
    private readonly IVenueTypeRepository _venueTypeRepository;
    private readonly IVenueCategoryRepository _venueCategoryRepository;
    private readonly IVenueImageRepository _venueImageRepository;
    private readonly IVenueOpeningHourRepository _venueOpeningHourRepository;

    public VenueApplicationService(
        IVenueRepository venueRepository,
        IVenueCategoryRepository venueCategoryRepository,
        IVenueTypeRepository venueTypeRepository,
        IVenueImageRepository venueImageRepository,
        IVenueOpeningHourRepository venueOpeningHourRepository)
    {
        _venueRepository = venueRepository;
        _venueCategoryRepository = venueCategoryRepository;
        _venueTypeRepository = venueTypeRepository;
        _venueImageRepository = venueImageRepository;
        _venueOpeningHourRepository = venueOpeningHourRepository;
    }

    /// <summary>
    /// Asynchronously retrieves the details of a venue by its slug.
    /// 
    /// This method fetches the venue's information and associated images from the repository. 
    /// If the venue with the specified ID does not exist, it throws a <see cref="VenueNotFoundException"/>.
    /// The venue images are collected and included in the result. If there are no images associated 
    /// with the venue, the returned list of images in the <see cref="VenueDto"/> will be empty but not null.
    /// 
    /// <param name="venueId">The unique identifier of the venue to retrieve.</param>
    /// <returns>A <see cref="VenueDto"/> containing the venue details and associated images.</returns>
    /// <exception cref="VenueNotFoundException">Thrown when a venue with the specified ID is not found.</exception>
    /// </summary>
    public async Task<VenueDto> GetVenueBySlugAsync(string venueSlug)
    {
        var venue = await _venueRepository.GetVenueBySlugAsync(venueSlug);
        
        if (venue is null)
        {
            throw new VenueNotFoundException();
        }

        var venueType = await _venueTypeRepository.GetVenueTypeByIdAsync(venue.VenueTypeId);

        if (venue is null)
        {
            throw new VenueTypeNotFoundException();
        }

        var venueTypeDto = new VenueTypeDto
        {
            Slug = venueType.Slug,
            Name = venueType.Name,
            Description = venueType.Description
        };

        var venueCategory = await _venueCategoryRepository.GetVenueCategoryByIdAsync(venueType.VenueCategoryId);

        if (venueCategory is null)
        {
            throw new VenueCategoryNotFoundException();
        }

        var venueCategoryDto = new VenueCategoryDto
        {
            Slug = venueType.Slug,
            Name = venueType.Name,
            Description = venueType.Description
        };

        var venueDto = new VenueDto
        {
            Id = venue.Id,
            Slug = venue.Slug,
            Name = venue.Name,
            VenueType = venueTypeDto,
            VenueCategory = venueCategoryDto,
            Summary = venue.Summary,
            Description = venue.Description,
            Address = venue.Address,
            PhoneNumber = venue.PhoneNumber,
            EmailAddress = venue.EmailAddress,
            Website = venue.Website,
            Instagram = venue.Instagram,
            Facebook = venue.Facebook,
            VenueImages = venue.VenueImages,
            VenueOpeningHours = venue.VenueOpeningHours
        };

        return venueDto;
    }
    
    public async Task<IEnumerable<Venue>> GetVenuesByTypeIdAsync(Guid venueTypeId)
    {
        var venues = await _venueRepository.GetVenuesByTypeIdAsync(venueTypeId);
        
        if (venues.Count() == 0)
        {
            throw new VenueNotFoundException();
        }

        return venues;
    }

}