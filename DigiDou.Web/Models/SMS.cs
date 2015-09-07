using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DigiDou.Web.Models
{
    [JsonObject(Title = "sms")]
    public class SMS
    {
        public int Id { get; set; }
        public Contact Recipient { get; set; }

        [MaxLength(140)]
        public string Body { get; set; }

        public bool IsSent { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser User { get; set; }


    }
}