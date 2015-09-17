using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Byrth.Core
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