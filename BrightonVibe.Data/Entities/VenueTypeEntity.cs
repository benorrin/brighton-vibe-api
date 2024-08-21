using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BrightonVibe.Domain.Enums;

namespace BrightonVibe.Data.Entities
{
    [Table("venue_type")]
    public class VenueTypeEntity
    {
        [Column("id")]
        public Guid Id { get; init; }
        
        [Column("slug")]
        public string Slug { get; init; }
        
        [Required]
        [MaxLength(25)]
        [Column("name")]
        public string Name { get; init; }
        
        [Required]
        [Column("description")]
        public string Description { get; init; }
        
        [Required]
        [Column("created_at")]
        public DateTime CreatedAt { get; init; }

    }
}