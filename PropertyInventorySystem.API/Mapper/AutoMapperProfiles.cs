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

        }
    }
}
