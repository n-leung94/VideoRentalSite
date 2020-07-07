using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalService.Models;

namespace VideoRentalService.Controllers
{
    [Authorize(Roles = RoleName.CanManageMovies)]
    public class RentalsController : Controller
    {
        // Returns a New Rental Form
        public ActionResult New()
        {
            return View();
        }
    }
}