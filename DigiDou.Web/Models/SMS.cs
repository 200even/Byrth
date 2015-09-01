using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigiDou.Web.Models
{
    public class SMS
    {
        public int Id { get; set; }
        public string Recipient { get; set; }

        [MaxLength(140)]
        public string Body { get; set; }

        public virtual ApplicationUser User { get; set; }


    }
}