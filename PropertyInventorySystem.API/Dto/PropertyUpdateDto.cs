using System.ComponentModel.DataAnnotations;

namespace PropertyInventorySystem.API.Dto;

public class PropertyUpdateDto
{
    public DateTime LastModifiedDateTime { get; set; } = DateTime.UtcNow;
    public string? Name { get; set; }
    public string? Address { get; set; }
    public DateTime? DateOfRegistration { get; set; }
    public double Price { get; set; }
    [EmailAddress]
    public string? EmailAddress { get; set; }
    //public List<PropertyPriceAuditDto>? PropertyPriceAudits { get; set; }
}