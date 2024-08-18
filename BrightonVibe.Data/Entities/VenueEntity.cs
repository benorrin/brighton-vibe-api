using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BrightonVibe.Domain.Enums;

namespace BrightonVibe.Data.Entities
{
    [Table("venue")]
    public class VenueEntity
    {
        [Column("id")]
        public Guid Id { get; set; }
        
        [Required]
        [MaxLength(100)]
        [Column("name")]
        public string Name { get; set; }
        
        [Required]
        [Column("type")]
        public VenueType Type { get; set; }
        
        [Required]
        [MaxLength(200)]
        [Column("address")]
        public string Address { get; set; }
        
        [Phone]
        [MaxLength(15)]
        [Column("phone_number")]
        public string? PhoneNumber { get; set; }
        
        [EmailAddress]
        [MaxLength(100)]
        [Column("email_address")]
        public string? EmailAddress { get; set; }
        
        [Url]
        [MaxLength(100)]
        [Column("website")]
        public string? Website { get; set; }
        
        [MaxLength(100)]
        [Column("instagram")]
        public string? Instagram { get; set; }
        
        [MaxLength(100)]
        [Column("facebook")]
        public string? Facebook { get; set; }
    }
}