using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoRentalService.Controllers
{
    public class EnquiryController : Controller
    {       
        // Returns a new Enquiry Form
        [AllowAnonymous]
        public ActionResult New()
        {
            return View();
        }

    }
}
