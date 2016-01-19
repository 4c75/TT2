using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace TT2_Gala_darbs.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string result;
            if (User.Identity.IsAuthenticated) result = "U R Logged in";
            else result = "U R Not Logged in";
            return View("Index", (object)result);
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
    }
}