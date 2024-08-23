using BrightonVibe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightonVibe.Application.DTOs;

public class VenueCategoryDto
{
    public string Slug { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

}