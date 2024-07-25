using AutoMapper;
using BrightonVibe.Data.Entities;
using BrightonVibe.Domain.Entities;
using BrightonVibe.Domain.Enums;
using BrightonVibe.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BrightonVibe.Data.Repositories;

public class VenueRepository : IVenueRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public VenueRepository(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Venue> GetVenueByIdAsync(Guid id)
    {
        var venueEntity = await _context.Venues.FindAsync(id);
        if (venueEntity == null)
        {
            return null;
        }
        return _mapper.Map<Venue>(venueEntity);
    }

    public async Task<IQueryable<Venue>> GetAllVenuesAsync()
    {
        var venueEntities = await _context.Venues.ToListAsync();
        
        return _mapper.Map<IQueryable<Venue>>(venueEntities);
    }

    public async Task<IQueryable<Venue>> GetVenuesByTypeAsync(VenueType type)
    {
        var venueEntities = await _context
            .Venues
            .Where(venue => venue.Type == type)
            .ToListAsync();
        
        return _mapper.Map<IQueryable<Venue>>(venueEntities);
    }

    public async Task AddVenueAsync(Venue venue)
    {
        var venueEntity = _mapper.Map<VenueEntity>(venue);
        await _context.Venues.AddAsync(venueEntity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateVenueAsync(Venue venue)
    {
        var venueEntity = _mapper.Map<VenueEntity>(venue);
        _context.Venues.Update(venueEntity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteVenueAsync(Guid id)
    {
        var venueEntity = await _context.Venues.FindAsync(id);
        if (venueEntity != null)
        {
            _context.Venues.Remove(venueEntity);
            await _context.SaveChangesAsync();
        }
    }
}