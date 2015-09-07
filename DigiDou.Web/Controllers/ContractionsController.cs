using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DigiDou.Web.Models;

namespace DigiDou.Web.Controllers
{
    public class ContractionsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //CurrentUser= db.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
        // GET: api/Contractions
        public List<Contraction> GetContractions()
        {
            ApplicationUser currentUser = db.Users.FirstOrDefault();
            DateTime endTime = currentUser.Contractions.FirstOrDefault().StartTime;
            foreach(Contraction c in currentUser.Contractions)
            {
                c.TimeSinceLast = c.StartTime - endTime;
                endTime = c.EndTime;
            }
            var contractions = currentUser.Contractions.ToList();
            return contractions;
        }

        // GET: api/Contractions/5
        [ResponseType(typeof(Contraction))]
        public IHttpActionResult GetContraction(int id)
        {
            ApplicationUser currentUser = db.Users.FirstOrDefault();
            Contraction contraction = currentUser.Contractions.Find(c => c.Id == id);
            if (contraction == null)
            {
                return NotFound();
            }

            return Ok(contraction);
        }

        // PUT: api/Contractions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContraction(int id, Contraction contraction)
        {
            ApplicationUser currentUser = db.Users.FirstOrDefault();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contraction.Id || currentUser.Contractions.Any(c => c.Id != id))
            {
                return BadRequest();
            }

            db.Entry(contraction).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContractionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Contractions
        [ResponseType(typeof(Contraction))]
        public IHttpActionResult PostContraction(Contraction contraction)
        {
            ApplicationUser currentUser = db.Users.FirstOrDefault();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            currentUser.Contractions.Add(contraction);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contraction.Id }, contraction);
        }

        // DELETE: api/Contractions/5
        [ResponseType(typeof(Contraction))]
        public IHttpActionResult DeleteContraction(int id)
        {
            ApplicationUser currentUser = db.Users.FirstOrDefault();
            Contraction contraction = currentUser.Contractions.FirstOrDefault(c => c.Id == id);
            if (contraction == null)
            {
                return NotFound();
            }

            db.Contractions.Remove(contraction);
            db.SaveChanges();

            return Ok(contraction);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContractionExists(int id)
        {
            return db.Contractions.Count(e => e.Id == id) > 0;
        }
    }
}