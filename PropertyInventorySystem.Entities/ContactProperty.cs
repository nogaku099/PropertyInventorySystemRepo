using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyInventorySystem.Entities
{
    public class ContactProperty : BaseEntity
    {
        public Guid ContactsId { get; set; }
        public Guid PropertiesId { get; set; }
        public virtual Contact Contact { get; set; }
        public virtual Property Property { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime EffectiveTill { get; set; }
        public double PriceOfAcquisition { get; set; }
    }
}
