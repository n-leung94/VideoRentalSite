using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using VideoRentalService.Dtos;
using VideoRentalService.Models;
using AutoMapper;

namespace VideoRentalService.Controllers.Api
{
    public class EnquiryController : ApiController
    {
        private ApplicationDbContext _context;

        public EnquiryController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult GetEnquiryTypes()
        {
            var enquiryTypes = _context.EnquiryTypes
                .ToList()
                .Select(Mapper.Map<EnquiryType, EnquiryTypeDto>);

            return Ok(enquiryTypes);


        }

        [HttpPost]
        public IHttpActionResult SubmitEnquiryForm(EnquiryDto enquiryDto)
        {
            Enquiry newEnquiry = new Enquiry
            {
                Email = enquiryDto.Email,
                Name = enquiryDto.Name,
                EnquiryTypeId = enquiryDto.EnquiryTypeId,
                MessageField = enquiryDto.MessageField,
                DateSubmitted = DateTime.Now
            };

            _context.Enquiries.Add(newEnquiry);
            _context.SaveChanges();



            return Ok();
        }
    }
}
