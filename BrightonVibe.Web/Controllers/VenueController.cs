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
        
        return Ok(venueDto);
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

}
