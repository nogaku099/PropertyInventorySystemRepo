using AutoMapper;
using PropertyInventorySystem.API.Dto;
using PropertyInventorySystem.Entities;
using PropertyInventorySystem.Infrastructure.Repos;

namespace PropertyInventorySystem.API.Services
{
    public class PropertyService : IPropertyService
    {
        private IPropertyRepo _repo;
        //private IPropertyPriceAuditRepo _priceAuditRepo;
        private IMapper _mapper;

        public PropertyService(IPropertyRepo repo, IMapper mapper)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            //_priceAuditRepo = priceAuditRepo ?? throw new ArgumentNullException(nameof(priceAuditRepo));
        }
        
        public async Task<Guid> CreatePropertyAsync(PropertyCreateDto propertyCreateDto)
        {
            var property = _mapper.Map<Property>(propertyCreateDto);
            var result = await _repo.Add(property);
            
            return result.Id;
        }
        
        public async Task<List<PropertyGetDto>> BatchCreatePropertyAsync(List<PropertyCreateDto> propertyCreateDtos)
        {
            var properties = _mapper.Map<List<Property>>(propertyCreateDtos);
            var result = await _repo.AddRange(properties);
            
            return _mapper.Map<List<PropertyGetDto>>(result);
        }

        public async Task<PropertyGetDto> UpdatePropertyAsync(Guid id, PropertyUpdateDto propertyUpdateDto)
        {
            var property = await _repo.GetByIdWithIncludes(p => p.Id == id, p => p.PropertyPriceAudit);
            if (property is null) throw new NullReferenceException("Property not found");
            var updateProperty = _mapper.Map<Property>(propertyUpdateDto);
            updateProperty.Id = property.Id;
            updateProperty.PropertyPriceAudit = property.PropertyPriceAudit;
            if (property.Price != propertyUpdateDto.Price)
            {
                var priceAudit = new PropertyPriceAudit()
                {
                    OldPrice = property.Price,
                    NewPrice = propertyUpdateDto.Price,
                    EffectedDateTime = DateTime.Now,
                    LastModifiedDateTime = DateTime.Now,
                    CreatedDateTime = DateTime.Now
                };
                if(property.PropertyPriceAudit is null)
                    updateProperty.PropertyPriceAudit = new List<PropertyPriceAudit>(){ priceAudit };
                else updateProperty.PropertyPriceAudit.Add(priceAudit);
                //await _priceAuditRepo.Add(priceAudit);
            }

            var result = await _repo.Update(updateProperty);
            var x = _mapper.Map<PropertyGetDto>(result);
            return _mapper.Map<PropertyGetDto>(result);
        }

        public async Task<PagedResult<PropertyGetDto>> GetAllProperties(int pageNum, int pageSize)
        {
            var properties = await _repo.GetAllWithIncludesAndPaging(pageNum, pageSize, p => p.PropertyPriceAudit);
            var result = _mapper.Map<PagedResult<PropertyGetDto>>(properties);
            return result;
        }

        public async Task<PropertyGetDto> GetPropertyById(Guid id)
        {
            var property = await _repo.GetByIdWithIncludes(p => p.Id == id, p => p.PropertyPriceAudit);
            
            return _mapper.Map<PropertyGetDto>(property);
        }
    }
}
