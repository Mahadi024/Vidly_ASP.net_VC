using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MembershipTypes, MembershipTypeDto>();
            Mapper.CreateMap<Genres, GenreDto>();

            Mapper.CreateMap<CustomerDto, Customer>().ForMember(c=>c.Id,opt=>opt.Ignore());;
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m=>m.Id,opt => opt.Ignore());

        }
    }
}