using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VideoRentalService.Models
{
    public class Enquiry
    {
        public byte Id { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public byte EnquiryTypeId { get; set; }
        public EnquiryType EnquiryType { get; set; }


        [Required]
        [MinLength(50)]
        public string MessageField { get; set; }


        public DateTime DateSubmitted { get; set; }

        public DateTime? DateResolved { get; set; }


        
    }
}