using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VideoRentalService.Dtos
{
    public class EnquiryDto
    {
        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public byte EnquiryTypeId { get; set; }


        [Required]
        [MinLength(50)]
        public string MessageField { get; set; }

    }
}