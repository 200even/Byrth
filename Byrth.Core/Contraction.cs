using System;
using Humanizer;
using Newtonsoft.Json;

namespace Byrth.Core
{
    public class Contraction
    {
        public int Id { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public TimeSpan Length => EndTime - StartTime;

        public string LengthHuman => Length.Humanize(1);

        [JsonIgnore]
        public TimeSpan TimeSinceLast { get; set; }

        public int TimeSinceLastMS => (int)TimeSinceLast.TotalMilliseconds;

        public string TimeSinceLastHuman => TimeSinceLast.Humanize(1);

        [JsonIgnore]
        public virtual ApplicationUser User { get; set; }

    }
}