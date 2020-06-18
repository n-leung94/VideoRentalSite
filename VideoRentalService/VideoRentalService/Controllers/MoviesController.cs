using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalService.Models;
using VideoRentalService.ViewModels;

namespace VideoRentalService.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random in URL
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek !" };

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers

            };

            return View(viewModel); // Must add Random.cshtml under Movies folder in Views
            // return Content("Hello World");
            // return HttpNotFound();
            // return new EmptyResult();
            // return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name"});
        }

        //                             Constraint to 4 digits, between num range of 1 and 12
        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1, 12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }


        // GET: Movies/edit/id arg
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        // Movies
        // ? means nullable
        public ActionResult Index(int? pageIndex, string sortBy)
        {

            // Handling default values if none are specified
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }
    }
}