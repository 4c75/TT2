using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TT2_Gala_darbs.Models;

namespace TT2_Gala_darbs.Controllers
{
    public class AddNewEntityController : Controller
    {
        //
        // GET: /AddNewEntity/
        public ActionResult Index()
        {
            return View("AddNewEntity");
        }
        public ActionResult Add()
        {
            StoryModel added = new StoryModel();
            added.currentUser = User.Identity.Name;
            added.title = Request["title"];
            added.text = Request["text"];
            added.likes = 0;
            Cords c = new Cords();
            string temp = Request["cords"];
            string[] i = temp.Split(' ');
            bool n;
            try
            {
                Convert.ToDecimal(i[1]);
                Convert.ToDecimal(i[2]);
                n = true;
            }
            catch { n = false; }
            if (n)
            {
                c.x = Convert.ToDecimal(i[1]);
                c.y = Convert.ToDecimal(i[2]);
                added.cord.Add(c);
            }
            database send = new database();
            send.addStory(added);
            return View("Sandbox", i);
        }
	}
}