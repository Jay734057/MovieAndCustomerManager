using System;
using System.ComponentModel.DataAnnotations;

namespace MovieAndCustomerManager.Models
{
    public class Movie
    {

        public int Id  { get; set; }

        [Required]
        public string Name { get; set; }

        
        public Genres Genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Required]
        [Range(1,20)]
        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }

        
    }

    
}