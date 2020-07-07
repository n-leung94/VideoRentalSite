using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRentalService.Models;

namespace VideoRentalService.Controllers
{
    [Authorize(Roles = RoleName.CanManageMovies)]
    public class EnquiryManagerController : Controller
    {
        // GET: EnquiryManager
        public ActionResult List()
        {
            return View();
        }

    }
}