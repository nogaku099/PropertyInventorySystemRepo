namespace PropertyInventorySystem.API.Dto
{
    public class ContactPropertyGetDto : BaseDto
    {
        public Guid ContactsId { get; set; }
        public Guid PropertiesId { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime EffectiveTill { get; set; }
        public double PriceOfAcquisition { get; set; }
        public string FullName { get; set; }
    }
}
