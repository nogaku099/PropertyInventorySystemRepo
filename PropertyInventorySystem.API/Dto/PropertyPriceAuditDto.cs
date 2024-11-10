namespace PropertyInventorySystem.API.Dto
{
    public class PropertyPriceAuditDto : BaseDto
    {
        public DateTime EffectedDateTime { get; set; }
        public double OldPrice { get; set; }
        public double NewPrice { get; set; }
    }
}
