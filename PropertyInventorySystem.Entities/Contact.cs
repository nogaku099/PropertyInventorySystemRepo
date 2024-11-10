using System.ComponentModel.DataAnnotations;

namespace PropertyInventorySystem.Entities
{
    public class Contact : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string? EmailAddress { get; set; }

        public virtual ICollection<ContactProperty> ContactProperties { get; set; }
    }
}
