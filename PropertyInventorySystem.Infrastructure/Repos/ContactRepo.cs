using PropertyInventorySystem.Entities;
using PropertyInventorySystem.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyInventorySystem.Infrastructure.Repos
{
    public class ContactRepo : BaseRepo<Contact>, IContactRepo
    {
        private PropertyInventoryDbContext _context;
        public ContactRepo(PropertyInventoryDbContext context) : base(context)
        {
            context = _context;
        }
    }
}
