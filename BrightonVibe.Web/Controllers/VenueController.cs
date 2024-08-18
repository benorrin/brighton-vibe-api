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

    [HttpGet("{venueSlug}")]
    public async Task<IActionResult> GetVenueByIdAsync(string venueSlug)
    { 
        var venueDto = await _venueApplicationService.GetVenueBySlugAsync(venueSlug);
        
        return Ok(venueDto);
    }
    
    [HttpGet("type/{venueCategory}")]
    public async Task<IActionResult> GetVenuesByType(VenueCategory venueCategory)
    {
        var venues = await _venueApplicationService.GetVenuesByTypeAsync(venueCategory);

        if (venues == null || !venues.Any())
        {
            return NotFound();
        }

        return Ok(venues);
    }

}
