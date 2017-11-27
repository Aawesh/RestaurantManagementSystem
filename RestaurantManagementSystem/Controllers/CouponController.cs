using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantManagementSystem.Models;

namespace RestaurantManagementSystem.Controllers
{
    public class CouponController : Controller
    {
        CouponEntities couponEntities = new CouponEntities();

        // GET: Coupon
        public ActionResult Index()
        {
            return View();
        }
        

        [HttpGet]
        [Authorize]
        public ActionResult SendCoupon()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult SendCoupon(Coupon coupon)
        {
            string Message = "";

            if (ModelState.IsValid)
            {
                #region //Email already Exist 
                var isExist = IsEmailExist(coupon.Email);
                if (isExist)
                {
                    Console.WriteLine("reached here in email exists");
                    ModelState.AddModelError("EmailE", "Email already exists");
                    return View(coupon);
                }
                #endregion

                Random random = new Random();
                int length = 6;
                const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
                coupon.CouponNumber = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
                couponEntities.Coupons.Add(coupon);
                couponEntities.SaveChanges();

                Message = "Successful Coupon entry";
                ViewBag.Message = Message;

                return View();

            }
            return View(coupon);
        }


        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            using (CouponEntities couponEntities = new CouponEntities())
            {
                var v = couponEntities.Coupons.Where(a => a.Email == emailID).FirstOrDefault();
                return v != null;
            }
        }

    }
}