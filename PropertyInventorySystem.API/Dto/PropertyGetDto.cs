﻿using PropertyInventorySystem.Entities;
using System.ComponentModel.DataAnnotations;

namespace PropertyInventorySystem.API.Dto
{
    public class PropertyGetDto : BaseDto
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public double Price { get; set; }
        [EmailAddress]
        public string EmailAddress { get; set; }
        //Default Currency To Euro

        public List<PropertyPriceAuditDto>? PropertyPriceAudit { get; set; }

        public List<ContactPropertyGetDto>? ContactProperties { get; set; }
    }
}
