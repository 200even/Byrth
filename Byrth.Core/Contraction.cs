using System;
using Newtonsoft.Json;

namespace Byrth.Core
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