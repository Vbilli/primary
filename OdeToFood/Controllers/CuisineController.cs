using OdeToFood.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.Controllers
{
    public class CuisineController : Controller
    {
        //
        // GET: /Cuisine/
        [HttpGet]
        [Log]
        public ActionResult Search(string name ="french")
        {
            //throw new Exception("something terrible was happen(kidding)");
            
            return Content(name);

        }

    }
}
