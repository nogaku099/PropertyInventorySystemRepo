using AutoMapper;
using PropertyInventorySystem.API.Dto;
using PropertyInventorySystem.Entities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace PropertyInventorySystem.API.Mapper
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Property, PropertyGetDto>().ReverseMap();
            CreateMap<Property, PropertyCreateDto>().ReverseMap();
            CreateMap<Property, PropertyUpdateDto>().ReverseMap();
            CreateMap<PropertyPriceAudit, PropertyPriceAuditDto>().ReverseMap();
            CreateMap<PagedResult<Property>, PagedResult<PropertyGetDto>>().ReverseMap();
            
            CreateMap<Contact, ContactGetDto>().ReverseMap();
            CreateMap<Contact, ContactCreateDto>().ReverseMap();
            CreateMap<Contact, ContactUpdateDto>().ReverseMap();
            //CreateMap<PropertyPriceAudit, PropertyPriceAuditDto>().ReverseMap();
            CreateMap<PagedResult<Contact>, PagedResult<ContactGetDto>>().ReverseMap();
            
            CreateMap<Contact, ContactPropertyCreateDto>().ReverseMap();
            CreateMap<ContactProperty, ContactPropertyCreateDto>().ReverseMap();
            CreateMap<ContactProperty, ContactPropertyGetDto>().ReverseMap();


        }
    }
}
