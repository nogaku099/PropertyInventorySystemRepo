using System.ComponentModel.DataAnnotations;

namespace PropertyInventorySystem.API.Dto;

public class ContactUpdateDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    [EmailAddress]
    public string? EmailAddress { get; set; }

    public List<ContactPropertyGetDto>? ContactProperties { get; set; }
    public DateTime LastModifiedDateTime { get; set; } = DateTime.UtcNow;
}