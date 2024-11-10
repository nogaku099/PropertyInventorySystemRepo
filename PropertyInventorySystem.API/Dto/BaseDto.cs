namespace PropertyInventorySystem.API.Dto
{
    public class BaseDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
    }
}
