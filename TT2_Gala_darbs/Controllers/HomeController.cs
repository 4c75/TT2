using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TT2_Gala_darbs.Models;

namespace TT2_Gala_darbs.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            database getData = new database();
            string currentUser = User.Identity.Name;
            List<StoryModel> result = getData.getStory(currentUser);
            
            if (User.Identity.IsAuthenticated) return View("Index", result);
            else return View("NotLoggedIn");
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