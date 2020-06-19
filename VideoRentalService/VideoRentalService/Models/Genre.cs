using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace VideoRentalService.Models
{
    public class Genre
    {
        public byte Id { get; set; }
        [StringLength(255)]
        public string Name { get; set; }
    }
}