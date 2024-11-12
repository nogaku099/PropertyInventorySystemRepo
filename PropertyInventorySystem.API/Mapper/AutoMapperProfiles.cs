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
            CreateMap<Property, PropertyGetDto>().ReverseMap()
                .ForMember(dest => dest.PropertyPriceAudit, opt => opt.MapFrom(src => src.PropertyPriceAudit))
                .ForMember(dest => dest.ContactsProperties, 
                    opt => opt.MapFrom(c => c.ContactProperties.OrderByDescending(x => x.EffectiveFrom).ToList())).ReverseMap();
            CreateMap<Property, PropertyCreateDto>().ReverseMap();
            CreateMap<Property, PropertyUpdateDto>().ReverseMap();
            CreateMap<PropertyPriceAudit, PropertyPriceAuditDto>().ReverseMap();
            CreateMap<PagedResult<Property>, PagedResult<PropertyGetDto>>().ReverseMap();
            
            CreateMap<Contact, ContactGetDto>().ReverseMap();
            CreateMap<Contact, ContactCreateDto>().ReverseMap();
            CreateMap<Contact, ContactUpdateDto>().ReverseMap();
            //CreateMap<PropertyPriceAudit, PropertyPriceAuditDto>().ReverseMap();
            CreateMap<PagedResult<Contact>, PagedResult<ContactGetDto>>().ReverseMap();
            
            //CreateMap<Contact, ContactPropertyCreateDto>().ReverseMap();
            CreateMap<ContactProperty, ContactPropertyCreateDto>().ReverseMap();
            CreateMap<ContactPropertyGetDto, ContactProperty>();
            
            CreateMap<ContactProperty, ContactPropertyGetDto>()
                .ForMember(dest => dest.FullName, 
                    opt => opt.MapFrom(src => $"{src.Contact.FirstName} {src.Contact.LastName}"));

            // Other mappings can go here
            CreateMap<Property, PropertyGetDto>()
                .ForMember(dest => dest.PropertyPriceAudit, opt => opt.MapFrom(src => src.PropertyPriceAudit))
                .ForMember(dest => dest.ContactProperties, 
                    opt => opt.MapFrom(src => src.ContactsProperties.OrderByDescending(x => x.EffectiveFrom).ToList()));

        }
    }
}
