using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieAndCustomerManager.Models;

namespace MovieAndCustomerManager.Controllers
{
    public class MoviesController : Controller
    {

        public List<Movie> Movies { get; private set; } = new List<Movie> {
            new Movie {Name = "Jungle Giants" },
            new Movie {Name = "Chasring the Dragon"}
        };
        // GET: Movie

        //public ActionResult Random()
        //{

            
        //    var customers = new List<Customer>
        //    {
        //        new Customer {Name = "Customer 1"},
        //        new Customer {Name = "Customer 2"},
        //        new Customer {Name = "Customer 3"},
        //        new Customer {Name = "Customer 4"},
        //        new Customer {Name = "Customer 5"},
        //        new Customer {Name = "Customer 6"}
        //    };

        //    var viewModel = new RandomMovieViewModels
        //    {
        //        Movie = Movies,
        //        Customers = customers
        //    };

        //    return View(viewModel);
        //    //return Content("hello");
        //    //return HttpNotFound();
        //    //return new EmptyResult();
        //    //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        //}

        [Route("movies/released/{year:regex(\\d{4}):range(1900, 2100)}}/{month:regex(\\d{2}):range(1, 12)}")]

        public ActionResult ByReleaseDate(int year, byte month)
        {
            return Content($"{year}/{month}");
        }

        public ActionResult Edit(int id)
        {
            return Content($"Content: id = {id.ToString()}");
        }

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;

        //    if (string.IsNullOrWhiteSpace(sortBy))
        //        sortBy = "name";

        //    return Content($"pageIndex = {pageIndex} & sortBy = {sortBy}.");
        //}

        public ActionResult Index()
        {
            return View("Index", Movies);
        }

        public ActionResult Test(int id)
        {
            if (id == 1)
                return Content("this is the page for customers");
            if (id == 2)
                return Content("this is the page for movies");
            return HttpNotFound();
        }
    }
}