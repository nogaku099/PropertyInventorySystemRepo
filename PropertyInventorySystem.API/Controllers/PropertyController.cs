using Microsoft.AspNetCore.Mvc;
using PropertyInventorySystem.API.Dto;
using PropertyInventorySystem.API.Services;

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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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

        // PUT api/<PropertyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PropertyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
