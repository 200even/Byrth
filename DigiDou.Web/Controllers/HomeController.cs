using DigiDou.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigiDou.Web.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            var dayCount = db.Users.FirstOrDefault().DaysTilDue;
            dayCount = dayCount.Replace("from now", "to go");
            return View((object)dayCount);
        }
    }
}
