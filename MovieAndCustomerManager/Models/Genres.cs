using System.ComponentModel.DataAnnotations;


namespace MovieAndCustomerManager.Models
{
    public class Genres
    {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}