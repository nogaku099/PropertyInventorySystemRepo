using System.ComponentModel.DataAnnotations;

namespace PropertyInventorySystem.API.Dto;

public class ContactCreateDto : BaseDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    [EmailAddress]
    public string? EmailAddress { get; set; }
}