using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Farmazon.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        public async Task<ActionResult> Index()
        {
            var userId = HttpContext.GetOwinContext().Authentication.User.Identity.GetUserId();

            using (var context = new Farmazon_dbEntities())
            {
                var myItems = await context.Set<Inventory>().Where(x => x.SellerId.Equals(userId)).ToListAsync();

                if (myItems != null)
                {
                    return View();
                }
                return View(myItems);
            }
        }

        public async Task<ActionResult> GetInventory()
        {
            var userId = HttpContext.GetOwinContext().Authentication.User.Identity.GetUserId();

            using (var context = new Farmazon_dbEntities())
            {
                var myItems = await context.Set<Inventory>().Where(x => x.SellerId.Equals(userId)).ToListAsync();

                if (myItems == null)
                {
                    return View();
                }

                return View(myItems);
            }
        }


        [HttpPost]
        public async Task<ActionResult> FillInventory(Inventory inventory)
        {
            using (var context = new Farmazon_dbEntities())
                {
                    var userId = HttpContext.GetOwinContext().Authentication.User.Identity.GetUserId();

                    context.CreateInventoryItem(userId, inventory.Quantity, inventory.Price, inventory.ProductName, inventory.PhotoLocation, inventory.Description, inventory.ReviewCount, inventory.ReviewStars);
                    await context.SaveChangesAsync();

                    return new HttpStatusCodeResult((int)HttpStatusCode.OK);
                }
        }
    }
}
