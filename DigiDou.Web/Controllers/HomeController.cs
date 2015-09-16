using DigiDou.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigiDou.Web.Controllers
{
    //[Authorize]
    public class HomeController : MVCBaseController
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            var dayCount = CurrentUser.DaysTilDue;
            dayCount = dayCount.Replace("from now", "to go");
            return View((object)dayCount);
        }
    }
}
