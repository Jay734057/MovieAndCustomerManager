using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieAndCustomerManager.Models;
using MovieAndCustomerManager.ViewModels;
using System.Data.Entity;

namespace MovieAndCustomerManager.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        public ActionResult Index()
        {
            if (User.IsInRole(Constants.CanManageMovies))
                return View("List");
            return View("ReadOnlyList");
        }

        [Authorize(Roles = Constants.CanManageMovies)]
        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList(),
                Title = "Edit Movie"
            };
            return View("MovieForm", viewModel);
        }

        [Authorize(Roles = Constants.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var movieFormViewModel = new MovieFormViewModel
            {
                Genres = genres,
                Title = "New Movie"
                //Movie = new Movie()
            };
            return View("MovieForm", movieFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Constants.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var movieFormViewModel = new MovieFormViewModel
                {
                    Genres = _context.Genres.ToList(),
                    Movie = movie,
                    Title = "New Movie"
                };

                return View("MovieForm", movieFormViewModel);
            }

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Genre = movie.Genre;
                movieInDb.NumberInStock = movie.NumberInStock;

            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }
}




//public List<Movie> Movies { get; private set; } = new List<Movie> {
//    new Movie {Name = "Jungle Giants" },
//    new Movie {Name = "Chasring the Dragon"}
//};
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

//[Route("movies/released/{year:regex(\\d{4}):range(1900, 2100)}}/{month:regex(\\d{2}):range(1, 12)}")]

//public ActionResult ByReleaseDate(int year, byte month)
//{
//    return Content($"{year}/{month}");
//}

//public ActionResult Edit(int id)
//{
//    return Content($"Content: id = {id.ToString()}");
//}

//public ActionResult Index(int? pageIndex, string sortBy)
//{
//    if (!pageIndex.HasValue)
//        pageIndex = 1;

//    if (string.IsNullOrWhiteSpace(sortBy))
//        sortBy = "name";

//    return Content($"pageIndex = {pageIndex} & sortBy = {sortBy}.");
//}


//public ActionResult Details(string name)
//{
//    var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Name == name);

//    if (movie == null)
//        return new HttpNotFoundResult();
//    else
//    {
//        return View(movie);
//    }
//}