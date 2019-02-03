using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Farmazon.Controllers
{
    [Authorize]
    public class FarmerProfileController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
