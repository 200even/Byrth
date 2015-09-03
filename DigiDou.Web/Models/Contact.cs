﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DigiDou.Web.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}