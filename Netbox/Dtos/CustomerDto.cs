using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Netbox.Models;
using System.ComponentModel.DataAnnotations;

namespace Netbox.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        public byte MembershipTypeId { get; set; }

        [MemberMinAgeRequirement]
        public DateTime? Birthdate { get; set; }
    }
}