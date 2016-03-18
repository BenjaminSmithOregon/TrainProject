using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OreFun2014.DAL;
using OreFun2014.Models;

namespace OreFun2014.Controllers
{
    public class TrainController : Controller
    {
        private OreFunContext db = new OreFunContext();

        // GET: Train
        public ActionResult Index()
        {
            return View(db.Trains.ToList());
        }

        // GET: Train/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Train train = db.Trains.Find(id);
            if (train == null)
            {
                return HttpNotFound();
            }
            return View(train);
        }

        // GET: Train/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Train/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TrainID,TrainName,TrainModel,NumOfCars")] Train train)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Trains.Add(train);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(train);
        }

        // GET: Train/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Train train = db.Trains.Find(id);
            if (train == null)
            {
                return HttpNotFound();
            }
            return View(train);
        }

        // POST: Train/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TrainID,TrainName,TrainModel,NumOfCars")] Train train)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(train).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(train);
        }

        // GET: Train/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }

            Train train = db.Trains.Find(id);
            if (train == null)
            {
                return HttpNotFound();
            }
            return View(train);
        }

        // POST: Train/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Train train = db.Trains.Find(id);
                db.Trains.Remove(train);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }

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
