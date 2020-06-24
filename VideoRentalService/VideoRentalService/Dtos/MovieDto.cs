using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRentalService.Models;
using System.ComponentModel.DataAnnotations;

namespace VideoRentalService.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public byte GenreId { get; set; }

        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }

        [Range(1, 20)]
        public int Stock { get; set; }

    }
}