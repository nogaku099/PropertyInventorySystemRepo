using System.ComponentModel.DataAnnotations;

namespace PropertyInventorySystem.Entities
{
    public class Property : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public double Price { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        //Default Currency To Euro

        public virtual ICollection<PropertyPriceAudit>? PropertyPriceAudit { get; set; }

        public virtual ICollection<ContactProperty>? ContactProperties { get; set; }

    }
}
