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
    //[Authorize]
    public class SMSController : ApiController
    {
        private static ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUser CurrentUser = db.Users.FirstOrDefault();
        //CurrentUser= db.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
        
        // GET: api/SMS
        public List<SMS> GetMessages()
        {
            //var currentUser = db.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault();
            //TEST CODE
            var messages = db.Messages
                                      .Where(x => x.User.Id == CurrentUser.Id && x.Recipient.Phone != null).ToList();
            return messages;
        }

        // GET: api/SMS/5
        [ResponseType(typeof(SMS))]
        public IHttpActionResult GetSMS(int id)
        {
            SMS sMS = db.Messages.Find(id);
            if (sMS == null)
            {
                return NotFound();
            }

            return Ok(sMS);
        }

        // PUT: api/SMS/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSMS(int id, SMS sMS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sMS.Id)
            {
                return BadRequest();
            }

            db.Entry(sMS).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SMSExists(id))
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

        // POST: api/SMS
        [ResponseType(typeof(SMS))]
        public IHttpActionResult PostSMS(SMS sMs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //db.Users.Where(x => x.UserName == User.Identity.Name).FirstOrDefault().Messages.Add(sMs);
            //TEST CODE
            db.Users.FirstOrDefault().Messages.Add(sMs);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sMs.Id }, sMs);
        }

        // DELETE: api/SMS/5
        [ResponseType(typeof(SMS))]
        public IHttpActionResult DeleteSMS(int id)
        {
            SMS sMS = db.Messages.Find(id);
            if (sMS == null)
            {
                return NotFound();
            }

            db.Messages.Remove(sMS);
            db.SaveChanges();

            return Ok(sMS);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SMSExists(int id)
        {
            return db.Messages.Count(e => e.Id == id) > 0;
        }
    }
}