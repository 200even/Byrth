using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Byrth.Core
{
    [JsonObject(Title = "sms")]
    public class SMS
    {
        public int Id { get; set; }
        public virtual Contact Recipient { get; set; }

        [MaxLength(140)]
        public string Body { get; set; }

        public bool IsSent { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser User { get; set; }


    }
}