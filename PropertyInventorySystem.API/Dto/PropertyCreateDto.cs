using System.ComponentModel.DataAnnotations;

namespace PropertyInventorySystem.API.Dto;

public class PropertyCreateDto
{
    public string Name { get; set; }
    public string Address { get; set; }
    public DateTime DateOfRegistration { get; set; }
    public double Price { get; set; }
    [EmailAddress]
    public string EmailAddress { get; set; }
    public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    public DateTime LastModifiedDateTime { get; set; } = DateTime.Now;
}