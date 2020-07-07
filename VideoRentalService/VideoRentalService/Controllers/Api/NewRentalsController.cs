using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoRentalService.Models;
using VideoRentalService.Dtos;
using System.Data.Entity;

namespace VideoRentalService.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateNewRentals(NewRentalDto newRental)
        {

            if (newRental.MovieIds.Count == 0)
                return BadRequest("No Movie Ids have been given.");

            var customer = _context.Customers.Single(c => c.Id == newRental.CustomerId);

            if (customer == null)
                return BadRequest("CustomerId is not Valid.");

            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList(); // SELECT * FROM Movies Where Id IN {1 , 2, 3} etc.

            if (movies.Count != newRental.MovieIds.Count)
                return BadRequest("One or more Movie Ids was invalid.");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable -= 1;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                    

                _context.Rentals.Add(rental);
                

            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
