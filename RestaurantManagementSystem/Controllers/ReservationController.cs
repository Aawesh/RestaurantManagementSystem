using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantManagementSystem.Models;


namespace RestaurantManagementSystem.Controllers
{
    public class ReservationController : Controller
    {

        ReservationEntities reservationEntities = new ReservationEntities();
        // GET: Reservation
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult InsertReservation()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult InsertReservation(Reservation reservation)
        {
            string Message = "";

            if (ModelState.IsValid)
            {

                string person = reservation.Persons.ToString();
                string date = reservation.Date.ToString().Substring(0, 10);
                string fromTime = reservation.FromTime.ToString();
                string toTime = reservation.ToTime.ToString();
                Decimal total = 0;

                String details = "";
                if (reservation.Menu1 != "0") // price = 8 //menuname
                {
                    total += (8 * Convert.ToInt32(reservation.Menu1));
                    details += "Chicken Sandwich : $"+ (8 * Convert.ToInt32(reservation.Menu1)) + "\n";
                }
                if (reservation.Menu2 != "0") // price = 4
                {
                    total += (4 * Convert.ToInt32(reservation.Menu2));
                    details += "Chicken Nuggets : $"+ (4 * Convert.ToInt32(reservation.Menu2)) + "\n";
                }
                if (reservation.Menu3 != "0") // price = 5
                {
                    total += (5 * Convert.ToInt32(reservation.Menu3));
                    details += "Cheese Pizza : $"+ (5 * Convert.ToInt32(reservation.Menu3)) + "\n"; 
                }
                if (reservation.Menu4 != "0") // price = 10
                {
                    total += (10 * Convert.ToInt32(reservation.Menu4));
                    details += "Boneless Chicken : $" + (10 * Convert.ToInt32(reservation.Menu4)) + "\n";
                }
                if (reservation.Menu5 != "0") // price = 6
                {
                    total += (6 * Convert.ToInt32(reservation.Menu5));
                    details += "Ham Burger : $"+ (6 * Convert.ToInt32(reservation.Menu5));
                }

                if (details.Equals("")) {
                    Message = "Select at leat one item from the menu";
                    ViewBag.Message = Message;
                    return View(reservation);
                }

                total += + total * (Decimal)(0.075);

                reservation.Details = details;
                reservation.Total = total;
                reservation.Email = TempData["email"].ToString();

                reservationEntities.Reservations.Add(reservation);
                reservationEntities.SaveChanges();

                Message = "Successful reservation";
                ViewBag.Message = Message;

                TempData["details"] = details;
                TempData["price"] = total.ToString();
                TempData["person"] = person;
                TempData["date"] = date;
                TempData["fromTime"] = fromTime;
                TempData["toTime"] = toTime;

                //return View(reservation);
                return RedirectToAction("ReservationDetails");

            }
            return View(reservation);
        }

        [HttpGet]
        [Authorize]
        public ActionResult ReservationDetails()
        {
            return View();
        }

        public ActionResult ReservationSuccessful() {
            return View();
        }
    }
}