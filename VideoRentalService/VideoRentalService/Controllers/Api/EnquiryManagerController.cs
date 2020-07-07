using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoRentalService.Models;
using VideoRentalService.Dtos;
using VideoRentalService.ViewModels;
using System.Data.Entity;
using AutoMapper;

namespace VideoRentalService.Controllers.Api
{
    [Authorize(Roles = RoleName.CanManageMovies)]
    public class EnquiryManagerController : ApiController
    {
        private ApplicationDbContext _context;


        public EnquiryManagerController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/EnquiryManager
        // Returns all unresolved enquiries by filtering DB based on enquiries with no resolved dates.
        public IHttpActionResult GetEnquiries()
        {
            var enquiries = _context.Enquiries
                .Include(e => e.EnquiryType);

            enquiries = enquiries.Where(e => e.DateResolved == null);

            var EnquiryManagerDto = enquiries
                .ToList()
                .Select(Mapper.Map<Enquiry, EnquiryManagerDto>);

            return Ok(EnquiryManagerDto);
        }

        // GET /api/EnquiryManager/{id}
        // Returns a query entry based on id provided.
        public IHttpActionResult GetEnquiries(int id)
        {
            var enquiry = _context.Enquiries.SingleOrDefault(e => e.Id == id);

            if (enquiry == null)
                return NotFound();

            return Ok(Mapper.Map<Enquiry, EnquiryManagerDto>(enquiry));
        }

        // PUT /api/EnquiryManager/{id}
        // Marks a specific enquiry based on ID as resolved by adding a timestamp.
        [HttpPut]
        public IHttpActionResult ResolveEnquiry(int id)
        {
            var enquiryInDb = _context.Enquiries.Include(e => e.EnquiryType).Single(e => e.Id == id);

            if (enquiryInDb == null)
                return BadRequest();

            enquiryInDb.DateResolved = DateTime.Now;

            _context.SaveChanges();

            return Ok();
        }
    }
}
