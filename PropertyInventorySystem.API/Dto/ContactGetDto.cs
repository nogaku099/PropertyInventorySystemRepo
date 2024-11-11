using PropertyInventorySystem.Entities;
using System.ComponentModel.DataAnnotations;

namespace PropertyInventorySystem.API.Dto
{
    public class ContactGetDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string? EmailAddress { get; set; }

        public List<ContactPropertyGetDto> ContactProperties { get; set; }
    }
}
