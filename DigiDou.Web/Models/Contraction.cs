using Newtonsoft.Json;
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

        [JsonIgnore]
        public TimeSpan TimeSinceLast { get; set; }

        public int TimeSinceLastMS => (int)TimeSinceLast.TotalMilliseconds;
       
        [JsonIgnore]
        public virtual ApplicationUser User { get; set; }

    }
}