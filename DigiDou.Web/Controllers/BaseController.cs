using DigiDou.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace DigiDou.Web.Controllers
{
    public class MVCBaseController : Controller
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
            //   if (Request.IsAuthenticated)
            {
                //CurrentUser= db.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
                CurrentUser = db.Users.FirstOrDefault();

            }
            return base.BeginExecuteCore(callback, state);
        }

    }

    public class BaseController : ApiController
    {
        protected ApplicationUser CurrentUser {
            get
            {
                return db.Users.FirstOrDefault();
            }
        }
        protected ApplicationDbContext db = new ApplicationDbContext();
    }
}