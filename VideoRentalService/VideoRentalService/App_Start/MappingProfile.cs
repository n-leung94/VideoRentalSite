﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using VideoRentalService.Models;
using VideoRentalService.Dtos;

namespace VideoRentalService.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();
            Mapper.CreateMap<Rental, ReturnRentalDto>();
            Mapper.CreateMap<EnquiryType, EnquiryTypeDto>();
            Mapper.CreateMap<Enquiry, EnquiryManagerDto>();
        }
    }
}