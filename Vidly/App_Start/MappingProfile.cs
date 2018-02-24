using AutoMapper;
using Vidly.Dto;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //Domain to DTO
            CreateMap<Customer, CustomerDto>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MembershipType, MembershipTypeDto>();
            CreateMap<Genre, GenreDto>();


            //DTO to Domain
            CreateMap<CustomerDto, Customer>().ForMember(c=>c.Id, opt => opt.Ignore());
            CreateMap<MovieDto, Movie>().ForMember(m=>m.Id, opt => opt.Ignore());
        }

    }
}