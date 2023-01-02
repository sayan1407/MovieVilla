using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using MovieVilla.Models;

namespace MovieVilla.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDTO>();
            //Mapper.CreateMap<Customer, CustomerDTO>().ForMember(m=>m.Id,opt=>opt.Ignore());
            Mapper.CreateMap<CustomerDTO, Customer>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<Customer, Customer>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<Movie,MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<Movie, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}