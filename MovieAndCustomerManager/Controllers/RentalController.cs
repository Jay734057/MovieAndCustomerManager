using MovieAndCustomerManager.Models;
using System.Web.Mvc;

namespace MovieAndCustomerManager.Controllers
{
    [Authorize]
    public class RentalController : Controller
    {
        // GET: Rental
        public ActionResult New()
        {
            return View();
        }


        //Admin GET:
        public ActionResult Index()
        {
            if (User.IsInRole(Constants.CanManageMovies))
                return View("List");
            return View("New");
        }
    }
}