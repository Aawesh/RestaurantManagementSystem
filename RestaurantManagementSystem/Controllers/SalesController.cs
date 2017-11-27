using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantManagementSystem.Models;
using System.Data.Entity;

namespace RestaurantManagementSystem.Controllers
{
    public class SalesController : Controller
    {
        SalesEntities salesEntities = new SalesEntities();
        // GET: Sales
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult DisplaySalesList()
        {
            return View(salesEntities.Sales.ToList());
        }

        [Authorize]
        public ActionResult SalesDetails(int id = 0)
        {
            Sale sale = salesEntities.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }

        [Authorize]
        public ActionResult EditSales(int id = 0)
        {
            Sale sale= salesEntities.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }
            return View(sale);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditSales(Sale sale)
        {
            if (ModelState.IsValid)
            {
                salesEntities.Entry(sale).State = EntityState.Modified;
                salesEntities.SaveChanges();
                ViewBag.Message = "Sales " + sale.SalesId + " edited successfully";
                return RedirectToAction("DisplaySalesList");
            }
            return View(sale);
        }

        [Authorize]
        public ActionResult DeleteSales(int id = 0)
        {
            Sale sale = salesEntities.Sales.Find(id);
            if (sale == null)
            {
                return HttpNotFound();
            }

            return View(sale);
        }

        [HttpPost, ActionName("DeleteSales")]
        [Authorize]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            Sale sale = salesEntities.Sales.Find(id);
            salesEntities.Sales.Remove(sale);
            salesEntities.SaveChanges();
            ViewBag.Message = "Sales dated" + sale.Date.ToString().Substring(0,11) + " deleted successfully";
            return RedirectToAction("DisplaySalesList");
        }
    }
}