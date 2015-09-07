using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DigiDou.Web.Models
{
    public class Contraction
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public TimeSpan Length => EndTime - StartTime;
        public TimeSpan TimeSinceLast
        {
            get
            {
                ApplicationDbContext db = new ApplicationDbContext();
                //CurrentUser= db.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
                ApplicationUser CurrentUser = db.Users.FirstOrDefault();
                if (CurrentUser.Contractions.ElementAt(Id) == CurrentUser.Contractions.ElementAt(0))
                {
                    return TimeSpan.Zero;
                }
                else
                {
                    //var calculate = CurrentUser.Contractions.Where()//.EndTime - StartTime
                    return TimeSpan.Zero;
                }
            }
        }
        public virtual ApplicationUser User { get; set; }

    }
}