using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DigiDou.Web.Models
{
    public class SMSCreateVM
    {
        public SelectList MyContacts { get; set; }
        [Required]
        public int SelectContactId { get; set; }

        [MaxLength(140)]
        [Required]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
    }
}