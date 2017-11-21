using System.Web.Mvc;
using MovieAndCustomerManager.Models;
using System.Linq;
using System.Data.Entity;
using MovieAndCustomerManager.ViewModels;

namespace MovieAndCustomerManager.Controllers
{
    [Authorize]
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
            if (User.IsInRole(Constants.CanManageMovies))
                return View("List");
            return (View("ReadOnlyList"));
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customer.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id + 1);

            if (customer == null)
                return new HttpNotFoundResult();
            else
            {
                return View(customer);
                
            }
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customer.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
               _context.Customer.Add(customer);
            else
            {
                var customerInDb = _context.Customer.Single(c => c.Id == customer.Id);


                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.isSubcribedToNewsletter = customer.isSubcribedToNewsletter;
                //update all properties of the customer!!!
                //TryUpdateModel(customerInDb);
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

    }
}