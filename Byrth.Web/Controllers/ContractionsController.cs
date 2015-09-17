using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Byrth.Core;
using Byrth.Web.Controllers;

namespace Byrth.Web.Controllers
{
    [Authorize]
    public class ContractionsController : BaseController
    {
        // GET: Contractions
        public ActionResult Index()
        {
            DateTime endTime = DateTime.Now.AddDays(-1);

            if (CurrentUser.Contractions.OrderBy(c => c.StartTime).FirstOrDefault().StartTime != null)
            {
                endTime = CurrentUser.Contractions.OrderBy(c => c.StartTime).FirstOrDefault().StartTime;
            }
            foreach (Contraction c in CurrentUser.Contractions)
                {
                    c.TimeSinceLast = c.StartTime - endTime;
                    endTime = c.EndTime;
                }
                var contractions = CurrentUser.Contractions.ToList();
                return View(contractions);
        }

        // GET: Contractions/Details/5
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

        // GET: Contractions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contractions/Create
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

        // GET: Contractions/Edit/5
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

        // POST: Contractions/Edit/5
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

        // GET: Contractions/Delete/5
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

        // POST: Contractions/Delete/5
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

        public void StartTime()
        {
            CurrentUser.Contractions.Add(new Contraction { StartTime = DateTime.Now, EndTime = DateTime.Now.AddMinutes(5) });
            db.SaveChanges();
        }

        public void EndTime()
        {
            CurrentUser.Contractions.OrderBy(c => c.StartTime).LastOrDefault().EndTime = DateTime.Now;
            db.SaveChanges();
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
