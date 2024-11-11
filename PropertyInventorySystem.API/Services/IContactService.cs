using PropertyInventorySystem.API.Dto;
using PropertyInventorySystem.Entities;

namespace PropertyInventorySystem.API.Services
{
    public interface IContactService
    {
        Task<PagedResult<ContactGetDto>> GetAllContacts(int pageNumber, int pageSize);
        Task<ContactGetDto> GetContactById(Guid id);
        Task<Guid> CreateContactAsync(ContactCreateDto contactCreateDto);
        Task<List<ContactGetDto>> BatchCreateContactAsync(List<ContactCreateDto> contactCreateDtos);
        Task<ContactGetDto> UpdateContactAsync(Guid id, ContactUpdateDto ContactUpdateDto);
        Task DeleteContact(Guid id);
        Task<ContactGetDto> CreateContactPropertyAsync(Guid id, ContactPropertyCreateDto contactCreateDto);
    }
}
