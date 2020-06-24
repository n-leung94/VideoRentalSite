using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VideoRentalService.Models;
using System.Linq;
using System.Web;

namespace VideoRentalService.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }


        public byte MembershipTypeId { get; set; } 


        // [Min18YearsIfAMember]  - The Model for this custom validation casts (customer) object while this is a customerDto object hence it cannot be applied.
        public DateTime? Birthdate { get; set; }
    }
}