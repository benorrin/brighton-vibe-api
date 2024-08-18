using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BrightonVibe.Application.DTOs;
using BrightonVibe.Application.Services;
using BrightonVibe.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

[ApiController]
[Route("venues")]
public class VenueController : ControllerBase
{
    private readonly VenueApplicationService _venueApplicationService;

    public VenueController(VenueApplicationService venueService)
    {
        _venueApplicationService = venueService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetVenueByIdAsync(Guid id)
    { 
        var venueDto = await _venueApplicationService.GetVenueByIdAsync(id);
        
        if (venueDto is null)
        {
            return NotFound();
        }
        
        return Ok(venueDto);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllVenues()
    {
        var venues = await _venueApplicationService.GetAllVenuesAsync();
        
        if (venues == null || !venues.Any())
        {
            return NotFound();
        }
        
        return Ok(venues);
    }
    
    [HttpGet("type/{venueType}")]
    public async Task<IActionResult> GetVenuesByType(VenueType venueType)
    {
        var venues = await _venueApplicationService.GetVenuesByTypeAsync(venueType);

        if (venues == null || !venues.Any())
        {
            return NotFound();
        }

        return Ok(venues);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateVenue([FromBody] VenueDto venueDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        await _venueApplicationService.AddVenueAsync(venueDto);
        
        return CreatedAtAction(nameof(GetVenue), new { id = venueDto.Id }, venueDto);
    }

    [Authorize]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateVenue(Guid id, [FromBody] VenueDto venueDto)
    {
        if (id != venueDto.Id)
        {
            return BadRequest();
        }
        
        await _venueApplicationService.UpdateVenueAsync(venueDto);
        
        return NoContent();
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteVenue(Guid id)
    {
        await _venueApplicationService.DeleteVenueAsync(id);
        
        return NoContent();
    }
}
