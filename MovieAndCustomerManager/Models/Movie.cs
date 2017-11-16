using System;
using System.ComponentModel.DataAnnotations;

namespace MovieAndCustomerManager.Models
{
    public class Movie
    {

        public int Id  { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Genres Genre { get; set; }
        [Required]
        public int NumberInStock { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public DateTime DateAdded { get; set; }
    }
}