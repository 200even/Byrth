using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Byrth.Core;

namespace Byrth.API.Controllers
{
    

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