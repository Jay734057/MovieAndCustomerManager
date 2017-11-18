using System.ComponentModel.DataAnnotations;

namespace MovieAndCustomerManager.Dtos
{
    public class GenreDto
    {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}