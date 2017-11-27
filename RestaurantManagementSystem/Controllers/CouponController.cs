using System;
using System.Linq;
using System.Web.Mvc;
using System.Net;
using System.Net.Mail;
using System.Data.Entity;
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

        [Authorize]
        public ActionResult DisplayCouponList()
        {
            return View(couponEntities.Coupons.ToList());
        }

        [HttpGet]
        public ActionResult DisplayCouponList(string searchString)
        {
            var coupon = from m in couponEntities.Coupons
                       select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                coupon = coupon.Where(s => s.CouponNumber.Contains(searchString));
            }

            return View(coupon);
        }

        [Authorize]
        public ActionResult CouponDetails(int id = 0)
        {
            Coupon coupon = couponEntities.Coupons.Find(id);
            if (coupon == null)
            {
                return HttpNotFound();
            }
            return View(coupon);
        }

        [Authorize]
        public ActionResult EditCoupon(int id = 0)
        {
            Coupon coupon = couponEntities.Coupons.Find(id);
            if (coupon == null)
            {
                return HttpNotFound();
            }
            return View(coupon);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCoupon(Coupon coupon)
        {
            if (ModelState.IsValid)
            {
                couponEntities.Entry(coupon).State = EntityState.Modified;
                couponEntities.SaveChanges();
                ViewBag.Message = "Coupon " + coupon.CouponNumber + " edited successfully";
                return RedirectToAction("DisplayCouponList");
            }
            return View(coupon);
        }

        [Authorize]
        public ActionResult DeleteCoupon(int id = 0)
        {
            Coupon coupon = couponEntities.Coupons.Find(id);
            if (coupon == null)
            {
                return HttpNotFound();
            }

            return View(coupon);
        }

        [HttpPost, ActionName("DeleteCoupon")]
        [Authorize]
        public ActionResult DeleteConfirmed(int id = 0)
        {
            Coupon coupon = couponEntities.Coupons.Find(id);
            couponEntities.Coupons.Remove(coupon);
            couponEntities.SaveChanges();
            ViewBag.Message = "Coupon " +coupon.CouponNumber+ " deleted successfully";
            return RedirectToAction("DisplayCouponList");
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

                Message = "Sent coupon Successfully";
                ViewBag.Message = Message;

                SendEmail(coupon.Email,coupon.CouponNumber,coupon.DiscountPercent.ToString(),coupon.ExpiryDate.ToString());

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

        [NonAction]
        public void SendEmail(string emailID, string CouponId, String discount, String expiryDate)
        {
            var fromEmail = new MailAddress("horizonsmart.contact@gmail.com", "Resturant Management System");
            var toEmail = new MailAddress(emailID);
            var fromEmailPassword = "Horizon123"; 
            string subject = "Offers from our restaurant";

            string body = "<br/><br/>We are excited to tell you that you have recieved" +
                " a coupon from our restaurant." +
                " <br/><br/>" +
                "<strong>Coupon Number: " + CouponId + "</strong>"+
                "<br/>" +
                "<strong>Discount % : " + discount +" %" +"</strong>"+
                "<br/>"+
                "<strong>Valid through: " + expiryDate.Substring(0,11) + "</strong>"+
                "<br/><br/>" + "Please feel free to apply this coupon in your next purchase." +
                "<br/><br/>Enjoy !!!";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, fromEmailPassword)
            };

            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            })
                smtp.Send(message);
        }

    }
}