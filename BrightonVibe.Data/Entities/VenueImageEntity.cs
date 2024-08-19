using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrightonVibe.Data.Entities
{
    [Table("venue_image")]
    public class VenueImageEntity
    {
        [Column("id")]
        public Guid Id { get; init; }
        
        [Required]
        [Column("venue_id")]
        public Guid VenueId { get; init; }
        
        [Url]
        [Required]
        [MaxLength(100)]
        [Column("image_url")]
        public string? ImageUrl { get; init; }
        
        [Required]
        [Column("featured")]
        public bool Featured { get; init; }
        
        [Required]
        [Column("description")]
        public string Description { get; init; }
        
        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; init; }

        // Navigation properties
        public VenueEntity Venue { get; init; }
    }
}