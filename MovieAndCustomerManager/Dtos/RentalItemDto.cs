using MovieAndCustomerManager.Models;
using System;

namespace MovieAndCustomerManager.Dtos
{
    public class RentalItemDto
    {

        public int Id { get; set; }

        public Customer Customer { get; set; }

        public Movie Movie { get; set; }

        public DateTime DateRented { get; set; }
        public DateTime DateReturned { get; set; }
    }
}