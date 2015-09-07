using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DigiDou.Web.Models;

namespace DigiDou.Web.Controllers
{
    public class ContractionsMvcController : BaseController
    {
        // GET: ContractionsMvc
        public ActionResult Index()
        {
            return View(CurrentUser.Contractions.ToList());
        }

        // GET: ContractionsMvc/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contraction contraction = CurrentUser.Contractions.Find(c => c.Id == id);
            if (contraction == null)
            {
                return HttpNotFound();
            }
            return View(contraction);
        }

        // GET: ContractionsMvc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContractionsMvc/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartTime,EndTime")] Contraction contraction)
        {
            if (ModelState.IsValid)
            {
                CurrentUser.Contractions.Add(contraction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contraction);
        }

        // GET: ContractionsMvc/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null || CurrentUser.Contractions.Any(c => c.Id != id))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contraction contraction = db.Contractions.Find(id);
            if (contraction == null)
            {
                return HttpNotFound();
            }
            return View(contraction);
        }

        // POST: ContractionsMvc/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartTime,EndTime")] Contraction contraction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contraction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contraction);
        }

        // GET: ContractionsMvc/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contraction contraction = CurrentUser.Contractions.Find(c => c.Id == id);
            if (contraction == null)
            {
                return HttpNotFound();
            }
            return View(contraction);
        }

        // POST: ContractionsMvc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contraction contraction = db.Contractions.Find(id);
            CurrentUser.Contractions.Remove(contraction);
            db.Contractions.Remove(contraction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
