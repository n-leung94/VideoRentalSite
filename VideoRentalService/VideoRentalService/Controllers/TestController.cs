using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoRentalService.Controllers
{
    public class TestController : Controller
    {
        // The moment you make a test controller class, it will handle for the URL /Test , Each ActionResult will find a view based on the Variable Name assigned from the view to return to the client
        // GET: Test
        public ActionResult Test()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }
    }
}