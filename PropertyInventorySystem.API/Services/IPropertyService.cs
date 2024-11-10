using PropertyInventorySystem.API.Dto;
using PropertyInventorySystem.Entities;

namespace PropertyInventorySystem.API.Services
{
    public interface IPropertyService
    {
        Task<PagedResult<PropertyGetDto>> GetAllProperties(int pageNumber, int pageSize);
        Task<PropertyGetDto> GetPropertyById(Guid id);
        Task<Guid> CreatePropertyAsync(PropertyCreateDto propertyCreateDto);
        Task<List<PropertyGetDto>> BatchCreatePropertyAsync(List<PropertyCreateDto> propertyCreateDtos);
        Task<PropertyGetDto> UpdatePropertyAsync(Guid id, PropertyUpdateDto propertyUpdateDto);
    }
}
