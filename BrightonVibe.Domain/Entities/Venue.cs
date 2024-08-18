using BrightonVibe.Domain.Enums;

namespace BrightonVibe.Domain.Entities;

public class Venue
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public VenueType Type { get; set; }
    public string Summary { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string? PhoneNumber { get; set; }
    public string? EmailAddress { get; set; }
    public string? Website { get; set; }
    public string? Instagram { get; set; }
    public string? Facebook { get; set; }

    public Venue(
        string name,
        VenueType type,
        string address
    )
    {
        Id = Guid.NewGuid();
        Name = name;
        Type = type;
        Address = address;
    }
    
    public void UpdateName(string name)
    {
        Name = name;
    }
    
    public void UpdateVenueType(VenueType type)
    {
        Type = type;
    }
    
    public void UpdateAddress(string address)
    {
        Address = address;
    }
    
    public void UpdatePhoneNumber(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
    }

    public void UpdateEmailAddress(string emailAddress)
    {
        EmailAddress = emailAddress;
    }

    public void UpdateWebsite(string website)
    {
        Website = website;
    }

    public void UpdateInstagram(string instagram)
    {
        Instagram = instagram;
    }

    public void UpdateFacebook(string facebook)
    {
        Facebook = facebook;
    }
}