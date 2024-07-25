using BrightonVibe.Domain.Enums;

namespace BrightonVibe.Domain.Entities;

public class Venue
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public VenueType Type { get; set; }
    public List<string> ImagePaths { get; set; }
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
        ImagePaths = new List<string>();
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

    public void AddImage(string imageUrl)
    {
        // Ensure ImagePaths is initialized
        if (ImagePaths is null)
        {
            ImagePaths = new List<string>();
        }

        // Add the image URL to the list
        ImagePaths.Add(imageUrl);
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