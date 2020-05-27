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
            Mapper.CreateMap<CustomerDto, Customer>();
        }
    }
}