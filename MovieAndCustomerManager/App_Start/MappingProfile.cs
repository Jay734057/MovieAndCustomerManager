using AutoMapper;
using MovieAndCustomerManager.Models;
using MovieAndCustomerManager.Dtos;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieAndCustomerManager.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, opt => opt.Ignore());

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            Mapper.CreateMap<Genres, GenreDto>();

            Mapper.CreateMap<Rental, RentalItemDto>()
                .ForMember("CustomerName", opt => opt.MapFrom(m => m.Customer.Name))
                .ForMember("MovieName", opt => opt.MapFrom(m => m.Movie.Name))
                .ForMember("DateRented", opt => opt.MapFrom(m => String.Format("{0:f}", m.DateRented)))
                .ForMember("DateReturned", opt => opt.MapFrom(m => (m.DateReturned != null )? String.Format("{0:f}", m.DateReturned) : null));
        }
    }
}