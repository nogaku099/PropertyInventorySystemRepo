using PropertyInventorySystem.Entities;
using PropertyInventorySystem.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace PropertyInventorySystem.Infrastructure.Repos
{
    public class ContactRepo : BaseRepo<Contact>, IContactRepo
    {
        private PropertyInventoryDbContext _context;
        public ContactRepo(PropertyInventoryDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddContactToPropertyAsync(Guid propertyId, Guid contactId, ContactProperty contactPropertyCreate)
        {
            var contact = await _context.Set<Contact>()
                .AsNoTracking().Include(p => p.ContactsProperties)
                .FirstOrDefaultAsync(c => c.Id == contactId);

            if (contact == null)
                throw new InvalidOperationException("Contact not found.");
            
            var property = await _context.Set<Property>()
                .AsNoTracking().FirstOrDefaultAsync(p => p.Id == propertyId);

            if (property == null)
                throw new InvalidOperationException("Property not found.");

            // Check if the link already exists
            var existingLink = contact.ContactsProperties
                .Any(cp => cp.PropertiesId == propertyId);
        
            if (existingLink)
                return; // The link already exists, no need to add
            contactPropertyCreate.ContactsId = contactId;
            contactPropertyCreate.PropertiesId = propertyId;
            // contactPropertyCreate.Property = property;
            // contactPropertyCreate.Contact = contact;
           
            await _context.Set<ContactProperty>().AddAsync(contactPropertyCreate);
            await _context.SaveChangesAsync();
        }

        // Another custom method for removing a link between Property and Contact
        public async Task RemoveContactFromPropertyAsync(Guid propertyId, Guid contactId)
        {
            var contactProperty = await _context.Set<ContactProperty>()
                .FirstOrDefaultAsync(cp => cp.PropertiesId == propertyId && cp.ContactsId == contactId);

            if (contactProperty == null)
                throw new InvalidOperationException("Link not found.");

            _context.Set<ContactProperty>().Remove(contactProperty);
            await _context.SaveChangesAsync();
        }
    }
}
