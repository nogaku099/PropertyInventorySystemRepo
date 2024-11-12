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
            var properties = await _repo.GetAllWithIncludesAndPaging(pageNum, pageSize, 
                p => p.PropertyPriceAudit, p => p.Contacts, p => p.ContactsProperties);
            var lstProp = properties.Items;
            var propertyDtos = lstProp.Select(x => new PropertyGetDto()
            {
                Id = x.Id,
                CreatedDateTime = x.CreatedDateTime,
                LastModifiedDateTime = x.LastModifiedDateTime,
                PropertyPriceAudit = _mapper.Map<List<PropertyPriceAuditDto>>(x.PropertyPriceAudit),
                ContactProperties = _mapper.Map<List<ContactPropertyGetDto>>(x.ContactsProperties),
                Price = x.Price,
                Address = x.Address,
                EmailAddress = x.EmailAddress,
                Name = x.Name,
                DateOfRegistration = x.DateOfRegistration
            }).ToList();

            foreach (var propertyDto in propertyDtos)
            {
                var contacts = lstProp.FirstOrDefault(p => p.Id == propertyDto.Id).Contacts.ToList();
                foreach (var contactProperty in propertyDto.ContactProperties)
                {
                    var contact = contacts.FirstOrDefault(x => x.Id == contactProperty.ContactsId);
                    contactProperty.FullName = contact.FirstName + " " + contact.LastName;
                }
            }

            var result = new PagedResult<PropertyGetDto>()
            {
                Items = propertyDtos,
                TotalCount = properties.TotalCount,
                TotalPages = properties.TotalPages,
                PageNumber = properties.PageNumber,
                PageSize = properties.PageSize
            };
            
            return result;
        }

        public async Task<PropertyGetDto> GetPropertyById(Guid id)
        {
            var property = await _repo.GetByIdWithIncludes(p => p.Id == id, 
                p => p.PropertyPriceAudit, 
                p => p.Contacts,
                p => p.ContactsProperties);
            
            if (property is null) throw new NullReferenceException("Property not found");
            
            var propGetDto = _mapper.Map<PropertyGetDto>(property);
            propGetDto.PropertyPriceAudit = _mapper.Map<List<PropertyPriceAuditDto>>(property.PropertyPriceAudit);
            propGetDto.ContactProperties = _mapper.Map<List<ContactPropertyGetDto>>(property.ContactsProperties)
                                                    .OrderByDescending(x => x.EffectiveFrom).ToList();
            if (propGetDto.ContactProperties is not null)
            {
                foreach (var contactProperty in propGetDto.ContactProperties)
                {
                    var contact = property.Contacts.FirstOrDefault(x => x.Id == contactProperty.ContactsId);
                    contactProperty.FullName = contact.FirstName + " " + contact.LastName;
                }
            }

            return propGetDto;
        }
        
        public async Task DeleteProperty(Guid id)
        {
            var property = await _repo.GetE(p => p.Id == id, p => p.PropertyPriceAudit);
            
            if (property is null) throw new NullReferenceException("Property not found");

            var result = await _repo.Delete(property);
            
            if(result <= 0)
                throw new Exception("Property could not be deleted");

        }
    }
}
