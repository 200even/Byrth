using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Byrth.Web.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            if (CurrentUser != null)
            {
                ViewBag.Title = "Home Page";
                var dayCount = CurrentUser.DaysTilDue;
                dayCount = dayCount.Replace("from now", "to go");
                return View((object) dayCount);
            }
            else
            {
                return RedirectToAction("login", "Account");
            }

        }

        [Authorize]
        public ActionResult CompleteProfile()
        {
            return View();
        }
    }
}