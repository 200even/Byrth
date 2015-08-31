using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DigiDou.Web.Models
{
    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }

        public string FullAddress => Address + "," + City + "," + State + " " + Zipcode;

        public string Phone { get; set; }

        public DbSet<Hospital> Hospitals { get; set; }
    }
}