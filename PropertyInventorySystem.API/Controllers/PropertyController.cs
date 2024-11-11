using Microsoft.AspNetCore.Mvc;
using PropertyInventorySystem.API.Dto;
using PropertyInventorySystem.API.Services;
using PropertyInventorySystem.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PropertyInventorySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }
        
        // GET: api/<PropertyController>
        [HttpGet]
        public async Task<PagedResult<PropertyGetDto>> GetAll([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = -1)
        {
            if (pageNumber < 1)
                throw new ArgumentException($"{nameof(pageNumber)} should be greater than 0");
            if (pageSize <= 0 && pageSize != -1)
                throw new ArgumentException($"{nameof(pageSize)} should be greater than 0");
            
            var result = await _propertyService.GetAllProperties(pageNumber, pageSize);
            return result;
        }

        // GET api/<PropertyController>/5
        [HttpGet("{id}")]
        public async Task<PropertyGetDto> Get(Guid id)
        {
            var result = await _propertyService.GetPropertyById(id);
            return result;
        }

        // POST api/<PropertyController>
        [HttpPost]
        public async Task<string> Post([FromBody] PropertyCreateDto propertyCreateDto)
        {
            var result = await _propertyService.CreatePropertyAsync(propertyCreateDto);
            return result.ToString();
        }
        
        [HttpPost]
        [Route("batchCreate")]
        public async Task<List<PropertyGetDto>> PostBatch([FromBody] List<PropertyCreateDto> propertyCreateDtos)
        {
            var result = await _propertyService.BatchCreatePropertyAsync(propertyCreateDtos);
            return result;
        }

        // PUT api/<PropertyController>/5
        [HttpPut("{id}")]
        public async Task<PropertyGetDto> Put(Guid id, [FromBody] PropertyUpdateDto propertyUpdateDto)
        {
            var result = await _propertyService.UpdatePropertyAsync(id, propertyUpdateDto);
            return result;
        }

        // DELETE api/<PropertyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
