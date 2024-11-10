using PropertyInventorySystem.Entities;
using PropertyInventorySystem.Infrastructure.Context;

namespace PropertyInventorySystem.Infrastructure.Repos;

public class PropertyPriceAuditRepo : BaseRepo<PropertyPriceAudit>, IPropertyPriceAuditRepo
{
    private PropertyInventoryDbContext _context;
    public PropertyPriceAuditRepo(PropertyInventoryDbContext context) : base(context)
    {
        context = _context;
    }
}