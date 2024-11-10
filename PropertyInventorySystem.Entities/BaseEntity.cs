using System.ComponentModel.DataAnnotations;

namespace PropertyInventorySystem.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
    }
}
