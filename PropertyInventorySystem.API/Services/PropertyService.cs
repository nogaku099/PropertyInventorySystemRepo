using PropertyInventorySystem.API.Dto;

namespace PropertyInventorySystem.API.Services
{
    public class PropertyService : IPropertyService
    {
        public Task<List<PropertyGetDto>> GetAllProperties()
        {
            throw new NotImplementedException();
        }

        public Task<PropertyGetDto> GetPropertyById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
