using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoRentalService.Models;
using VideoRentalService.Dtos;
using AutoMapper;
using System.Data.Entity;

namespace VideoRentalService.Controllers.Api
{
    public class ReturnRentalController : ApiController
    {
        private ApplicationDbContext _context;

        public ReturnRentalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetRented ()
        {
            var rentalQuery = _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Movie);

            rentalQuery = rentalQuery.Where(r => r.DateReturned == null);

            var rentedDto = rentalQuery
                .ToList()
                .Select(Mapper.Map<Rental, ReturnRentalDto>);

            return Ok(rentedDto);
        }

        [HttpPut]
        public IHttpActionResult Return (int id)
        {
            var rentalInDb = _context.Rentals.Include(r => r.Movie).Single(r => r.Id == id);

            var movieReturned = _context.Movies.Single(m => m.Id == rentalInDb.Movie.Id);

            movieReturned.NumberAvailable += 1;
            rentalInDb.DateReturned = DateTime.Now;

            _context.SaveChanges();

            return Ok();
            
        }
    }
}
