using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [Authorize]
        public ActionResult Inventory()
        {
            ViewBag.Message = "Inventory management page";

            return View();
        }

        [Authorize]
        public ActionResult Reservation()
        {
            ViewBag.Message = "Reservation page";

            return View();
        }

        [Authorize]
        public ActionResult Sales()
        {
            ViewBag.Message = "Sales page";

            return View();
        }

    }
}