using System.Web.Mvc;
using MovieAndCustomerManager.Models;
using System.Linq;
using System.Data.Entity;

namespace MovieAndCustomerManager.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _context.Dispose();
        }

        //public List<Customer> customers { get; private set; } = new List<Customer>
        //    {
        //        new Customer {Name = "Jay Zhu"},
        //        new Customer {Name = "Mosh H"}
        //    };

        // GET: Customer
        public ActionResult Index()
        {
            return View(_context.Customer.Include(c => c.MenbershipType).ToList());
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customer.Include(c => c.MenbershipType).SingleOrDefault(c => c.Id == id + 1);

            if (customer == null)
                return new HttpNotFoundResult();
            else
            {
                return View(customer);
                
            }
        }

    }
}