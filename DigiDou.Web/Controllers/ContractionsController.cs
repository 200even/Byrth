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
        private static ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUser CurrentUser = db.Users.FirstOrDefault();
        //CurrentUser= db.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
        // GET: api/Contractions
        public List<Contraction> GetContractions()
        {
            DateTime endTime = CurrentUser.Contractions.FirstOrDefault().StartTime;
            foreach(Contraction c in CurrentUser.Contractions)
            {
                c.TimeSinceLast = c.StartTime - endTime;
                endTime = c.EndTime;
            }
            var contractions = CurrentUser.Contractions.ToList();
            return contractions;
        }

        // GET: api/Contractions/5
        [ResponseType(typeof(Contraction))]
        public IHttpActionResult GetContraction(int id)
        {
            Contraction contraction = CurrentUser.Contractions.Find(c => c.Id == id);
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contraction.Id || CurrentUser.Contractions.Any(c => c.Id != id))
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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CurrentUser.Contractions.Add(contraction);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contraction.Id }, contraction);
        }

        // DELETE: api/Contractions/5
        [ResponseType(typeof(Contraction))]
        public IHttpActionResult DeleteContraction(int id)
        {
            Contraction contraction = CurrentUser.Contractions.FirstOrDefault(c => c.Id == id);
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