using System.ComponentModel.DataAnnotations;

namespace PropertyInventorySystem.API.Dto;

public class ContactCreateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    [EmailAddress]
    public string? EmailAddress { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.UtcNow;
    public DateTime LastModifiedDateTime { get; set; } = DateTime.UtcNow;
}