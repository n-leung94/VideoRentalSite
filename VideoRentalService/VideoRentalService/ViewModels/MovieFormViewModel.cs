using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoRentalService.Models;

namespace VideoRentalService.ViewModels
{
    public class MovieFormViewModel
    {
        public int? Id { get; set; }
        public IEnumerable<Genre> Genres { get; set; }

        public Movie Movie { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Movie" : "New Movie";
            }
        }
    }
}