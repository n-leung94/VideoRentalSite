using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VideoRentalService.Models
{
    public class Customer
    {
        public int Id { get; set; }

        // Required marks for the database migration that the name shouldn't be nullable when transforming it to table attributes. requires System.ComponentModel.DataAnnotations
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }


        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; } // Foreign Key to find the correct ID from Membership Type to apply to the customer when needed.


        [Display(Name = "Date Of Birth")]
        public DateTime? Birthdate { get; set; }
    }
}