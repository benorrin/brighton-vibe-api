using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrightonVibe.Data.Entities
{
    [Table("venue_image")]
    public class VenueImageEntity
    {
        [Column("id")]
        public Guid Id { get; set; }
        
        [Required]
        [Column("venue_id")]
        public Guid VenueId { get; set; }
        
        [Url]
        [MaxLength(100)]
        [Column("image_url")]
        public string? ImageUrl { get; set; }
        
        [Column("featured")]
        public bool Featured { get; set; }
        
        [Column("created_at")]
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public VenueEntity Venue { get; set; }
    }
}