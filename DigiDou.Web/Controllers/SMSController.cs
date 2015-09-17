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
using Byrth.Core;
using DigiDou.Web.Models;

namespace DigiDou.Web.Controllers
{
    //[Authorize]
    public class SMSController : BaseController
    {

        // GET: api/SMS
        public List<SMS> GetMessages()
        {
            var messages = db.Messages.Where(x => x.User.Id == CurrentUser.Id && x.Recipient.Phone != null)
                                      .Include(m => m.Recipient).ToList();
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

            if (id != sMS.Id || CurrentUser.Messages.Any(m => m.Id != id))
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
        public IHttpActionResult PostSMS(SMS sMS)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SMS newMessage = new SMS { Recipient = db.Contacts.Find(sMS.Recipient.Id), Body = sMS.Body, User = CurrentUser };
            db.Contacts.FirstOrDefault(m => m.Id == newMessage.Recipient.Id).Messages.Add(newMessage);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = newMessage.Id }, sMS);
        }

        // DELETE: api/SMS/5
        [ResponseType(typeof(SMS))]
        public IHttpActionResult DeleteSMS(int id)
        {
            SMS sMS = CurrentUser.Messages.FirstOrDefault(m => m.Id == id);
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