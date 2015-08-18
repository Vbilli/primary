using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class ReviewController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();
        public ActionResult Index(int RestaurantId)
        {
            var restaurant = _db.Restaurants.Find(RestaurantId);
            if(restaurant  != null)
            {
                return View(restaurant);
            }
            return HttpNotFound();
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
       }   
   }  

    

