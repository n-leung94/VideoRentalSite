using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRentalService.Models;

namespace VideoRentalService.Dtos
{
    public class EnquiryManagerDto
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public byte EnquiryTypeId { get; set; }
        public EnquiryTypeDto EnquiryType { get; set; }

        public string MessageField { get; set; }

        public DateTime DateSubmitted { get; set; }

    }
}