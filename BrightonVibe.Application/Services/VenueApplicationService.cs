using AutoMapper;
using BrightonVibe.Domain.Entities;
using BrightonVibe.Domain.Interfaces;
using BrightonVibe.Application.DTOs;
using BrightonVibe.Application.Exceptions;
using BrightonVibe.Domain.Enums;
using BrightonVibe.Domain.Services;

namespace BrightonVibe.Application.Services;

public class VenueApplicationService
{
    private readonly IVenueRepository _venueRepository;
    private readonly IVenueImageRepository _venueImageRepository;

    public VenueApplicationService(
        IVenueRepository venueRepository,
        IVenueImageRepository venueImageRepository)
    {
        _venueRepository = venueRepository;
        _venueImageRepository = venueImageRepository;
    }

    public async Task<VenueDto> GetVenueByIdAsync(Guid venueId)
    {
        var venue = await _venueRepository.GetVenueByIdAsync(venueId);
        
        if (venue is null)
        {
            throw new VenueNotFoundException(venueId);
        }

        var venueImages = await _venueImageRepository.GetVenueImagesByVenueId(venueId);

        var venueImagesDto = venueImages.Select(image => new VenueImage
        {
            Id = image.Id,
            ImageUrl = image.ImageUrl,
            VenueId = image.VenueId
        });
        
        return new VenueDto
        {
            Id = venue.Id,
            Name = venue.Name,
            Type = venue.Type,
            VenueImages = venueImagesDto,
            Address = venue.Address,
            PhoneNumber = venue.PhoneNumber,
            EmailAddress = venue.EmailAddress,
            Website = venue.Website,
            Instagram = venue.Instagram,
            Facebook = venue.Facebook
        };
    }

    public async Task<IEnumerable<Venue>> GetAllVenuesAsync()
    {
        var venues = await _venueRepository.GetAllVenuesAsync();

        return venues;
    }
    
    public async Task<IEnumerable<Venue>> GetVenuesByTypeAsync(VenueType venueType)
    {
        var venues = await _venueRepository.GetVenuesByTypeAsync(venueType);

        return venues;
    }

}