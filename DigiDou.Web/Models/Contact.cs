using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DigiDou.Web.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        public string Phone { get; set; }

        [JsonIgnore]
        public virtual List<SMS> Messages { get; set; }
        [JsonIgnore]
        public virtual ApplicationUser User { get; set; }
    }
}