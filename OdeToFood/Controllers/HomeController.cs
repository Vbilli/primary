﻿using OdeToFood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        OdeToFoodDb _db = new OdeToFoodDb();
        public ActionResult Index(string SearchTerm =null)
        {
            //var model = from r in _db.Restaurants
            //            orderby r.Reviews.Average(review => review.Rating) descending
            //            select new RestaurantListViewModel
            //                {
            //                    Id = r.Id,
            //                    Name = r.Name,
            //                    City = r.City,
            //                    Country = r.Country,
            //                    CountOfReviews = r.Reviews.Count()
            //                };
            //above is unnecessary
            

            var model = _db.Restaurants.OrderByDescending(r => r.Reviews.Average(review => review.Rating))
                .Where(r=>SearchTerm ==null || r.Name.StartsWith(SearchTerm))
                .Take(10)
                            .Select(r => new RestaurantListViewModel
                            {
                                Id = r.Id,
                                Name = r.Name,
                                City = r.City,
                                Country = r.Country,
                                CountOfReviews = r.Reviews.Count()
                            });
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Restaurant", model);
            }

            return View(model);
        }

        public ActionResult AutoComplete(string term)
        {
            var model = _db.Restaurants.Where(r => r.Name.StartsWith(term))
                .Take(10)
                .Select(r => new 
                { 
                    label = r.Name
                });
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        public ActionResult About()
        {
            var model = new AboutModel();
            model.Name = "scott allan";
            model.Location = "Maryland USA";
            return View(model);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (_db != null)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
