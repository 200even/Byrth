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

        public DbSet<Contraction> Contractions { get; set; }
    }
}