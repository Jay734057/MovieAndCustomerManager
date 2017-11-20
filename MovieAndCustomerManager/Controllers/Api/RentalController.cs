﻿using MovieAndCustomerManager.Dtos;
using MovieAndCustomerManager.Models;
using System;
using System.Linq;
using System.Web.Http;

namespace MovieAndCustomerManager.Controllers.Api
{
    public class RentalController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult Rental(RentalDto rentalDto)
        {
            //if (rentalDto.MovieIds.Count == 0)
            //    return BadRequest("No movie ID is provided!");

            var customer = _context.Customer.Single(c => c.Id == rentalDto.CustomerId);

            //if (customer == null)
            //    return BadRequest("Customer is not in the database!");

            var movies = _context.Movies.Where(c => rentalDto.MovieIds.Contains(c.Id)).ToList();

            //if (movies.Count != rentalDto.MovieIds.Count)
            //    return BadRequest("One or more movie IDs are invalid!");

            
            foreach(var movie in movies)
            {
                if (movie.NumberOfAvailability == 0)
                    return BadRequest(movie.Name + "is not available.");

                movie.NumberOfAvailability--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}