using Microsoft.EntityFrameworkCore;
using PropertyInventorySystem.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PropertyInventorySystem.Infrastructure.Context
{
    public class PropertyInventoryDbContext : DbContext
    {
        public PropertyInventoryDbContext(DbContextOptions<PropertyInventoryDbContext> option) : base(option) 
        {

        }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<PropertyPriceAudit> PropertyPriceAudits { get; set; }
        public DbSet<ContactProperty> ContactProperty { get; set; }
    }
}
