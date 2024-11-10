using PropertyInventorySystem.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PropertyInventorySystem.Infrastructure.Repos
{
    public interface IContactRepo : IBaseRepo<Contact>
    {
    }
}