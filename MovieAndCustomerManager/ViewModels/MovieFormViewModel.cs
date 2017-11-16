using MovieAndCustomerManager.Models;
using System.Collections.Generic;

namespace MovieAndCustomerManager.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genres> Genres { get; set; }
        public Movie Movie { get; set; }
        public string Title { get; set; }
    }
}