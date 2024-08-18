﻿namespace BrightonVibe.Domain.Entities;

public class VenueImage
{
    public Guid Id { get; set; }
    public Guid VenueId { get; set; }
    public string ImageUrl { get; set; }
    public DateTime CreatedAt { get; init; }
}