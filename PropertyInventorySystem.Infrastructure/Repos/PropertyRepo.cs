using PropertyInventorySystem.Entities;
using PropertyInventorySystem.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyInventorySystem.Infrastructure.Repos
{
    public class PropertyRepo : BaseRepo<Property>, IPropertyRepo
    {
        private PropertyInventoryDbContext _context;
        public PropertyRepo(PropertyInventoryDbContext context) : base(context)
        {
            context = _context;
        }
    }
}
