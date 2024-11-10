using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyInventorySystem.Entities
{
    public class PropertyPriceAudit : BaseEntity
    {
        public DateTime EffectedDateTime { get; set; } = DateTime.Now;
        public double OldPrice { get; set; }
        public double NewPrice { get; set; }
    }
}
