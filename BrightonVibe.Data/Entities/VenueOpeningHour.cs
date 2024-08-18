using System.ComponentModel.DataAnnotations.Schema;
using BrightonVibe.Domain.Enums;

namespace BrightonVibe.Data.Entities;

[Table("venue_opening_hours")]
public class VenueOpeningHour
{
    [Column("id")]
    public Guid Id { get; set; }
    
    [Column("venue_id")]
    public Guid VenueId { get; set; }
    
    [Column("week_day")]
    public WeekDay WeekDay { get; set; }
    
    [Column("opening_time")]
    public DateTime OpeningTime { get; set; }
    
    [Column("closing_time")]
    public DateTime ClosingTime { get; set; }
}