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

    public VenueApplicationService(
        IVenueRepository venueRepository)
    {
        _venueRepository = venueRepository;
    }

    public async Task<Venue> GetVenueByIdAsync(Guid venueId)
    {
        var venue = await _venueRepository.GetVenueByIdAsync(venueId);
        
        if (venue is null)
        {
            throw new VenueNotFoundException(venueId);
        }
        
        return venue;
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