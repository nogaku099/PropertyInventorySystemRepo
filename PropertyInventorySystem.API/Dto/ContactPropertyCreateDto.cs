namespace PropertyInventorySystem.API.Dto;

public class ContactPropertyCreateDto
{
    public Guid PropertyId { get; set; }
    public DateTime EffectiveFrom { get; set; }
    public DateTime EffectiveTill { get; set; }
    public double PriceOfAcquisition { get; set; }
    public DateTime LastModifiedDateTime { get; set; } = DateTime.UtcNow;
}