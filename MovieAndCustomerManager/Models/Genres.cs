using System.ComponentModel.DataAnnotations;


namespace MovieAndCustomerManager.Models
{
    public class Genres
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}