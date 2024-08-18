﻿using BrightonVibe.Domain.Enums;

namespace BrightonVibe.Application.DTOs;

public class VenueDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public VenueType Type { get; set; }
    public string Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? EmailAddress { get; set; }
    public string? Website { get; set; }
    public string? Instagram { get; set; }
    public string? Facebook { get; set; }
}