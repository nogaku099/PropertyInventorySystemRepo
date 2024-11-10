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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Property>()
                .Property(b => b.Id)
                .HasDefaultValueSql("NEWID()");
        
            modelBuilder.Entity<ContactProperty>()
                .Property(b => b.Id)
                .HasDefaultValueSql("NEWID()");
            
            modelBuilder.Entity<Contact>()
                .Property(b => b.Id)
                .HasDefaultValueSql("NEWID()");
            
            modelBuilder.Entity<PropertyPriceAudit>()
                .Property(b => b.Id)
                .HasDefaultValueSql("NEWID()");
        
        }
    }
}
