using AutoMapper;
using PropertyInventorySystem.API.Dto;
using PropertyInventorySystem.API.Services;
using PropertyInventorySystem.Entities;
using PropertyInventorySystem.Infrastructure.Repos;

namespace PropertyInventorySystem.API.Services
{
    public class ContactService : IContactService
    {
        private IContactRepo _repo;
        //private IContactPriceAuditRepo _priceAuditRepo;
        private IMapper _mapper;
        private IPropertyRepo _repoProp;

        public ContactService(IContactRepo repo, IMapper mapper, IPropertyRepo repoProp)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _repoProp = repoProp ?? throw new ArgumentNullException(nameof(repoProp));
            //_priceAuditRepo = priceAuditRepo ?? throw new ArgumentNullException(nameof(priceAuditRepo));
        }
        
        public async Task<Guid> CreateContactAsync(ContactCreateDto contactCreateDto)
        {
            var contact = _mapper.Map<Contact>(contactCreateDto);
            var result = await _repo.Add(contact);
            
            return result.Id;
        }
        
        public async Task<List<ContactGetDto>> BatchCreateContactAsync(List<ContactCreateDto> contactCreateDtos)
        {
            var contacts = _mapper.Map<List<Contact>>(contactCreateDtos);
            var result = await _repo.AddRange(contacts);
            
            return _mapper.Map<List<ContactGetDto>>(result);
        }
        
        public async Task<ContactGetDto> CreateContactPropertyAsync(Guid id, ContactPropertyCreateDto contactUpdateDto)
        {
            var contactProperty = _mapper.Map<ContactProperty>(contactUpdateDto);
            await _repo.AddContactToPropertyAsync(contactUpdateDto.PropertyId, id, contactProperty);
            
            var result = await _repo.GetByIdWithIncludes(p => p.Id == id, p => p.Properties, p => p.ContactsProperties);
            var resultDto = _mapper.Map<ContactGetDto>(result);
            resultDto.ContactProperties = _mapper.Map<List<ContactPropertyGetDto>>(result.ContactsProperties);
            return resultDto;
        }

        
        

        public async Task<ContactGetDto> UpdateContactAsync(Guid id, ContactUpdateDto contactUpdateDto)
        {
            var contact = await _repo.GetByIdWithIncludes(p => p.Id == id, 
                p => p.ContactsProperties);
            if (contact is null) throw new NullReferenceException("Contact not found");
            var updateContact = _mapper.Map<Contact>(contactUpdateDto);
            updateContact.Id = contact.Id;
            // updateContact.ContactPriceAudit = Contact.ContactPriceAudit;
            // if (Contact.Price != ContactUpdateDto.Price)
            // {
            //     var priceAudit = new ContactPriceAudit()
            //     {
            //         OldPrice = Contact.Price,
            //         NewPrice = ContactUpdateDto.Price,
            //         EffectedDateTime = DateTime.Now,
            //         LastModifiedDateTime = DateTime.Now,
            //         CreatedDateTime = DateTime.Now
            //     };
            //     if(Contact.ContactPriceAudit is null)
            //         updateContact.ContactPriceAudit = new List<ContactPriceAudit>(){ priceAudit };
            //     else updateContact.ContactPriceAudit.Add(priceAudit);
            //     //await _priceAuditRepo.Add(priceAudit);
            // }

            var result = await _repo.Update(updateContact);
            var x = _mapper.Map<ContactGetDto>(result);
            return _mapper.Map<ContactGetDto>(result);
        }

        public async Task<PagedResult<ContactGetDto>> GetAllContacts(int pageNum, int pageSize)
        {
            var properties = await _repo.GetAllWithIncludesAndPaging(pageNum, pageSize);
            var result = _mapper.Map<PagedResult<ContactGetDto>>(properties);
            return result;
        }
        
        public async Task<ContactGetDto> GetContactById(Guid id)
        {
            var Contact = await _repo.GetByIdWithIncludes(p => p.Id == id);
            
            if (Contact is null) throw new NullReferenceException("Contact not found");
            
            return _mapper.Map<ContactGetDto>(Contact);
        }
        
        public async Task DeleteContact(Guid id)
        {
            var contact = await _repo.GetE(p => p.Id == id);
            
            if (contact is null) throw new NullReferenceException("Contact not found");

            var result = await _repo.Delete(contact);
            
            if(result <= 0)
                throw new Exception("Contact could not be deleted");

        }
    }
}
