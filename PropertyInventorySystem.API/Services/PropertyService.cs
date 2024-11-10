using AutoMapper;
using PropertyInventorySystem.API.Dto;
using PropertyInventorySystem.Entities;
using PropertyInventorySystem.Infrastructure.Repos;

namespace PropertyInventorySystem.API.Services
{
    public class PropertyService : IPropertyService
    {
        private IPropertyRepo _repo;
        private IMapper _mapper;

        public PropertyService(IPropertyRepo repo, IMapper mapper)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        
        public async Task<Guid> CreatePropertyAsync(PropertyCreateDto propertyCreateDto)
        {
            var property = _mapper.Map<Property>(propertyCreateDto);
            //property.Id = Guid.NewGuid();
            //property.PropertyPriceAudit = new List<PropertyPriceAudit>();
            // if (property.ContactProperties is not null)
            //     property.ContactProperties = _mapper.Map<List<ContactProperty>>(propertyCreateDto.)
            //property.ContactProperties = new List<ContactProperty>();

            var result = await _repo.Add(property);
            
            return result.Id;
        }
        
        public Task<List<PropertyGetDto>> GetAllProperties()
        {
            throw new NotImplementedException();
        }

        public async Task<PropertyGetDto> GetPropertyById(Guid id)
        {
            var property = await _repo.Get(p => p.Id == id);
            
            return _mapper.Map<PropertyGetDto>(property);
        }
    }
}
