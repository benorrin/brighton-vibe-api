using Microsoft.AspNetCore.Mvc;
using BrightonVibe.Application.Services;

[ApiController]
[Route("venue-types")]
public class VenueTypesController : ControllerBase
{
    private readonly VenueTypeApplicationService _venueTypeApplicationService;

    public VenueTypesController(VenueTypeApplicationService venueTypeApplicationService)
    {
        _venueTypeApplicationService = venueTypeApplicationService;
    }

    [HttpGet("{venueTypeId:guid}")]
    public async Task<IActionResult> GetVenueTypeByIdAsync(Guid venueTypeId)
    { 
        var venueDto = await _venueTypeApplicationService.GetVenueTypeByIdAsync(venueTypeId);
        
        return Ok(venueDto);
    }

}