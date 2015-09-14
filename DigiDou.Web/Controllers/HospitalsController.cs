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
    [RoutePrefix("hospitals")]
    public class HospitalsController : BaseController
    {
        // GET: api/Hospitals
        public Hospital GetHospitals()
        {
            var hospital = CurrentUser.Hospital;
            return hospital;
        }

        // GET: api/Hospitals/5
        [ResponseType(typeof(Hospital))]
        public IHttpActionResult GetHospital(int id)
        {
            Hospital hospital = db.Hospitals.Find(id);
            if (hospital == null)
            {
                return NotFound();
            }

            return Ok(hospital);
        }

        // PUT: api/Hospitals/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHospital(int id, Hospital hospital)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hospital.Id || id != CurrentUser.Hospital.Id)
            {
                return BadRequest();
            }


            CurrentUser.Hospital.Address = hospital.Address;
            CurrentUser.Hospital.City = hospital.City;
            CurrentUser.Hospital.Name = hospital.Name;
            CurrentUser.Hospital.Phone = hospital.Phone;
            CurrentUser.Hospital.State = hospital.State;
            CurrentUser.Hospital.Zipcode = hospital.Zipcode;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HospitalExists(id))
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

        // POST: api/Hospitals
        [ResponseType(typeof(Hospital))]
        public IHttpActionResult PostHospital(Hospital hospital)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (CurrentUser.Hospital == null)
            {
                CurrentUser.Hospital = hospital;
            }
            else
            {
                return BadRequest("User already has a hospital");
            }
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hospital.Id }, hospital);
        }

        // DELETE: api/Hospitals/5
        [ResponseType(typeof(Hospital))]
        public IHttpActionResult DeleteHospital(int id)
        {
            Hospital hospital = CurrentUser.Hospital;
            if (CurrentUser.Hospital.Id == id)
            {
                db.Hospitals.Remove(hospital);
                db.SaveChanges();
                return Ok(hospital);
            }
            else
            {
                return NotFound();
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HospitalExists(int id)
        {
            return db.Hospitals.Count(e => e.Id == id) > 0;
        }
    }
}