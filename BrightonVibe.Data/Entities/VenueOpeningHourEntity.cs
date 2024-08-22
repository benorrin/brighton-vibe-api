using System;
using System.ComponentModel.DataAnnotations.Schema;
using BrightonVibe.Domain.Enums;

namespace BrightonVibe.Data.Entities
{
    [Table("venue_opening_hours")]
    public class VenueOpeningHourEntity
    {
        [Column("id")]
        public Guid Id { get; set; }
        
        [Column("venue_id")]
        public Guid VenueId { get; set; }
        
        [Column("week_day")]
        public WeekDay WeekDay { get; set; }
        
        [Column("opening_time")]
        public TimeSpan? OpeningTime { get; set; }
        
        [Column("closing_time")]
        public TimeSpan? ClosingTime { get; set; }
        
        [Column("created_at")]
        public DateTime CreatedAt { get; init; }

        #region Navigation properties

        public VenueEntity Venue { get; set; }

        #endregion
        
    }
}