using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
namespace Farmazon.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /Account/Createfarm
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> CreateFarm(Farm farmModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (var context = new Farmazon_dbEntities())
        //        {
        //            var userId = HttpContext.GetOwinContext().Authentication.User.Identity.GetUserId();

        //            context.CreateInventoryItem(null, userId, null, 5);
        //            await context.SaveChangesAsync();

        //            return RedirectToAction("Createfarm", "Account");
        //        }
        //    }
        //    return View(farmModel);
        //}
    }
}
