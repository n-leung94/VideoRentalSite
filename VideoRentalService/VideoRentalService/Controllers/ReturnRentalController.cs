using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalService.Models;

namespace VideoRentalService.Controllers
{
    public class ReturnRentalController : Controller
    {
        // GET: ReturnRental
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult List()
        {
            return View();
        }

    }
}