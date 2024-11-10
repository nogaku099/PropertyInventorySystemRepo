using PropertyInventorySystem.API.Dto;

namespace PropertyInventorySystem.API.Services
{
    public interface IPropertyService
    {
        Task<List<PropertyGetDto>> GetAllProperties();
        Task<PropertyGetDto> GetPropertyById(Guid id);
        Task<Guid> CreatePropertyAsync(PropertyCreateDto propertyCreateDto);
    }
}
