using MovieAndCustomerManager.Models;
using System;

namespace MovieAndCustomerManager.Dtos
{
    public class RentalItemDto
    {

        public int Id { get; set; }

        public string CustomerName { get; set; }

        public string MovieName { get; set; }

        public string DateRented { get; set; }
        public string DateReturned { get; set; }
    }
}