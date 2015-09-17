using System;
using System.Linq;
using System.Web.Mvc;
using Byrth.Core;
using Byrth.Web.Models;

namespace Byrth.Web.Controllers
{
    public class BaseController : Controller
    {

        public void Success(string msg)
        {
            TempData["success"] = msg;
        }


        public void Error(string msg)
        {
            TempData["error"] = msg;
        }
        protected ApplicationUser CurrentUser { get; set; }
        protected ApplicationDbContext db = new ApplicationDbContext();

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            if (Request.IsAuthenticated)
            {
                CurrentUser= db.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
            }
            return base.BeginExecuteCore(callback, state);
        }

    }
}