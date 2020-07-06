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
    public class EnquiryManagerController : ApiController
    {
        private ApplicationDbContext _context;

        public EnquiryManagerController()
        {
            _context = new ApplicationDbContext();
        }

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

        public IHttpActionResult GetEnquiries(int id)
        {
            var enquiry = _context.Enquiries.SingleOrDefault(e => e.Id == id);

            if (enquiry == null)
                return NotFound();

            return Ok(Mapper.Map<Enquiry, EnquiryManagerDto>(enquiry));
        }

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
