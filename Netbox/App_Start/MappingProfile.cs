using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Netbox.Dtos;
using Netbox.Models;

namespace Netbox.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Mapper, : source:Customer / target: CustomerDto
            Mapper.CreateMap<Customer, CustomerDto>();
        

            //Mapper, : source:Movie / target: MovieDto
            Mapper.CreateMap<Movie, MovieDto>();


            // Dto to Domain
            Mapper.CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            Mapper.CreateMap<MovieDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());


        }
    }
}