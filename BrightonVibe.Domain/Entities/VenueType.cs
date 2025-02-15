﻿namespace BrightonVibe.Domain.Entities;

public class VenueType
{
    public Guid Id { get; set; }
    public Guid VenueCategoryId { get; set; }
    public string Slug { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }

    #region Navigation properties

    public VenueCategory VenueCategory { get; set; }

    #endregion
}