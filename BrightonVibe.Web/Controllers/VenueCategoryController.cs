using Microsoft.AspNetCore.Mvc;
using BrightonVibe.Application.Services;

[ApiController]
[Route("venue-categories")]
public class VenueCategorysController : ControllerBase
{
    private readonly VenueCategoryApplicationService _venueCategoryApplicationService;

    public VenueCategorysController(VenueCategoryApplicationService venueCategoryApplicationService)
    {
        _venueCategoryApplicationService = venueCategoryApplicationService;
    }

    [HttpGet("{venueCategorySlug}")]
    public async Task<IActionResult> GetVenueCategoryBySlugAsync(string venueCategorySlug)
    { 
        var venueDto = await _venueCategoryApplicationService.GetVenueCategoryBySlugAsync(venueCategorySlug);
        
        return Ok(venueDto);
    }
    
    [HttpGet("{venueCategorySlug}/summary")]
    public async Task<IActionResult> GetVenueCategorySummaryBySlugAsync(string venueCategorySlug)
    { 
        var venueDto = await _venueCategoryApplicationService.GetVenueCategorySummaryBySlugAsync(venueCategorySlug);
        
        return Ok(venueDto);
    }

}