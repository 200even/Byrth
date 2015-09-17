using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Humanizer;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Byrth.Core
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DueDate { get; set; }

        public string DaysTilDue => DueDate.Humanize();

        public virtual Hospital Hospital { get; set; }
        public virtual List<Contraction> Contractions { get; set; }
        public virtual List<Contact> Contacts { get; set; }
        public virtual List<SMS> Messages { get; set; }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager,
            string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Hospital> Hospitals { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Contraction> Contractions { get; set; }

        public DbSet<SMS> Messages { get; set; }

    }
}