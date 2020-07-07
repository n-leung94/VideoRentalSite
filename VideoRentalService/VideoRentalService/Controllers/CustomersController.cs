using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalService.Models;
using VideoRentalService.ViewModels;
using System.Data.Entity;

namespace VideoRentalService.Controllers
{
    [Authorize(Roles = RoleName.CanManageMovies)]
    public class CustomersController : Controller
    {
        // To initialise Database Object
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();

        }

        // Destructor for DB object
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public ActionResult New()
        {
            // Retrieve membership types from DB to pass to form for membershiptype selection
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            // While we could pass membership types to return View() it won't work when editing a customer later as we also need to reference customer object
            // We need to make a View Model that encapsulate both properties.

            return View("CustomerForm", viewModel); // By default C# would look for a View called new, the string arg is to override what to look for.
        }

        
        [HttpPost]  // Ensure this action can only be done from HttpPost instead of get
        [ValidateAntiForgeryToken] // Prevents Cross Site Attacks, Enable it on respective forms using @Html.AntiForgeryToken()
        public ActionResult Save(Customer customer) // customer as an argument that will be passed to this action once a user keys in a new customer for processing, C# knows how to process the parameters from the form to single customer class rather than the view model.
        {
            // If user input on the form is invalid, throw back form with existing details filled in
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            // Since this action can either be called from New Customer or Edit Customer as they are using same Form View, we need to differentiate.
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        // GET: Customers
        public ActionResult Index()
        {
            // var customers = _context.Customers.Include(c => c.MembershipType).ToList();  // Fetches all customers in DB as list , Include Statement is needed as Membership Type is a different data object "Eager Loading", DEPRECATED
            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);  // Search for customer based on ID in database

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }

    }
}