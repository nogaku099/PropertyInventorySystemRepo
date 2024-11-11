using Microsoft.AspNetCore.Mvc;
using PropertyInventorySystem.API.Dto;
using PropertyInventorySystem.API.Services;
using PropertyInventorySystem.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PropertyInventorySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        
        // GET: api/<ContactController>
        [HttpGet]
        public async Task<PagedResult<ContactGetDto>> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = -1)
        {
            if (pageNumber < 1)
                throw new ArgumentException($"{nameof(pageNumber)} should be greater than 0");
            if (pageSize <= 0 && pageSize != -1)
                throw new ArgumentException($"{nameof(pageSize)} should be greater than 0");
            
            var result = await _contactService.GetAllContacts(pageNumber, pageSize);
            return result;
        }

        // GET api/<ContactController>/5
        [HttpGet("{id}")]
        public async Task<ContactGetDto> Get(Guid id)
        {
            var result = await _contactService.GetContactById(id);
            return result;
        }

        // POST api/<ContactController>
        [HttpPost]
        public async Task<string> Post([FromBody] ContactCreateDto contactCreateDto)
        {
            var result = await _contactService.CreateContactAsync(contactCreateDto);
            return result.ToString();
        }
        
        [HttpPost]
        [Route("addPropertyContact/{id}")]
        public async Task<ContactGetDto> CreateContactProperty(Guid id, [FromBody] ContactPropertyCreateDto contactCreateDto)
        {
            var result = await _contactService.CreateContactPropertyAsync(id, contactCreateDto);
            return result;
        }

        
        [HttpPost]
        [Route("batchCreate")]
        public async Task<List<ContactGetDto>> PostBatch([FromBody] List<ContactCreateDto> contactCreateDtos)
        {
            var result = await _contactService.BatchCreateContactAsync(contactCreateDtos);
            return result;
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public async Task<ContactGetDto> Put(Guid id, [FromBody] ContactUpdateDto contactUpdateDto)
        {
            var result = await _contactService.UpdateContactAsync(id, contactUpdateDto);
            return result;
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _contactService.DeleteContact(id);
        }
    }
}
