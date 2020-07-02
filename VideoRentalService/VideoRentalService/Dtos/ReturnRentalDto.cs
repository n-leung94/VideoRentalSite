using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRentalService.Models;
using VideoRentalService.Dtos;

namespace VideoRentalService.Dtos
{
    public class ReturnRentalDto
    {
        public int Id { get; set; }

        public byte CustomerId { get; set; }
        public CustomerDto Customer { get; set; }


        public byte MovieId { get; set; }
        public MovieDto Movie { get; set; }

        public DateTime DateRented { get; set; }

    }
}