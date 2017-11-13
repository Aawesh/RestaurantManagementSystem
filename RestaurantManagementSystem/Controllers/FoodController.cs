using RestaurantManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantManagementSystem.Controllers
{
    public class FoodController : Controller
    {
        FoodEntities foodEntities = new FoodEntities();
        // GET: Food
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult InsertFood()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult InsertFood(Food food)
        {
            string Message = "";

            if (ModelState.IsValid)
            {
                foodEntities.Foods.Add(food);
                foodEntities.SaveChanges();

                Message = "Successful food entry";
                ViewBag.Message = Message;

                return RedirectToAction("InsertFood");
               
            }
            return View(food);
        }

        [Authorize]
        public ActionResult DisplayFoodList()
        {
            return View(foodEntities.Foods.ToList());
        }

        [Authorize]
        public ActionResult DeleteFood(int id=0)
        {
            Food food = foodEntities.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }

            return View(food);
        }

        [HttpPost, ActionName("DeleteFood")]
        [Authorize]
        public ActionResult DeleteConfirmed(int id=0)
        {
            Food food = foodEntities.Foods.Find(id);
            foodEntities.Foods.Remove(food);
            foodEntities.SaveChanges();
            return RedirectToAction("DisplayFoodList");
        }

        [Authorize]
        public ActionResult FoodDetails(int id = 0)
        {
            Food food = foodEntities.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }

        [Authorize]
        public ActionResult EditFood(int id = 0)
        {
            Food food = foodEntities.Foods.Find(id);
            if (food == null)
            {
                return HttpNotFound();
            }
            return View(food);
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFood(Food food)
        {
            if (ModelState.IsValid)
            {
                foodEntities.Entry(food).State = EntityState.Modified;
                foodEntities.SaveChanges();
                return RedirectToAction("DisplayFoodList");
            }
            return View(food);
        }


    }
}