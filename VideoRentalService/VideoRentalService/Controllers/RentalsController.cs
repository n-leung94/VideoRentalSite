using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalService.Models;

namespace VideoRentalService.Controllers
{
    public class RentalsController : Controller
    {
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            return View();
        }
    }
}