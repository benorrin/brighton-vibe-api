﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BrightonVibe.Domain.Enums;

namespace BrightonVibe.Data.Entities
{
    [Table("venue")]
    public class VenueEntity
    {
        [Column("id")]
        public Guid Id { get; init; }
        
        [Required]
        [MaxLength(100)]
        [Column("name")]
        public string Name { get; init; }
        
        [Required]
        [Column("category")]
        public VenueCategory Category { get; init; }
        
        [Required]
        [Column("summary")]
        public string Summary { get; init; }
        
        [Required]
        [Column("Description")]
        public string Description { get; init; }
        
        [Required]
        [MaxLength(200)]
        [Column("address")]
        public string Address { get; init; }
        
        [Phone]
        [MaxLength(15)]
        [Column("phone_number")]
        public string? PhoneNumber { get; init; }
        
        [EmailAddress]
        [MaxLength(100)]
        [Column("email_address")]
        public string? EmailAddress { get; init; }
        
        [Url]
        [MaxLength(100)]
        [Column("website")]
        public string? Website { get; init; }
        
        [MaxLength(100)]
        [Column("instagram")]
        public string? Instagram { get; init; }
        
        [MaxLength(100)]
        [Column("facebook")]
        public string? Facebook { get; init; }
    }
}