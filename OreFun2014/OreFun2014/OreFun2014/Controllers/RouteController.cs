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
    public class RouteController : Controller
    {
        private OreFunContext db = new OreFunContext();

        // GET: Route
        public ActionResult Index()
        {
            var routes = db.Routes.Include(r => r.Station).Include(r => r.Train);
            return View(routes.ToList());
        }

        // GET: Route/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        // GET: Route/RouteReport/5
        public ActionResult RouteReport(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }

            return View(route);
        }

        // GET: Route/Create
        public ActionResult Create()
        {
            ViewBag.StationID = new SelectList(db.Stations, "StationID", "StationName");
            ViewBag.TrainID = new SelectList(db.Trains, "TrainID", "TrainName");
            return View();
        }

        // POST: Route/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RouteID,StationID,ArrivalTime,DepartTime,TrainID")] Route route)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Routes.Add(route);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }


            ViewBag.StationID = new SelectList(db.Stations, "StationID", "StationName", route.StationID);
            ViewBag.TrainID = new SelectList(db.Trains, "TrainID", "TrainName", route.TrainID);
            return View(route);
        }

        // GET: Route/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Route route = db.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            ViewBag.StationID = new SelectList(db.Stations, "StationID", "StationName", route.StationID);
            ViewBag.TrainID = new SelectList(db.Trains, "TrainID", "TrainName", route.TrainID);
            return View(route);
        }

        // POST: Route/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RouteID,StationID,ArrivalTime,DepartTime,TrainID")] Route route)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(route).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.StationID = new SelectList(db.Stations, "StationID", "StationName", route.StationID);
                ViewBag.TrainID = new SelectList(db.Trains, "TrainID", "TrainName", route.TrainID);
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(route);
        }

        // GET: Route/Delete/5
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
            Route route = db.Routes.Find(id);
            if (route == null)
            {
                return HttpNotFound();
            }
            return View(route);
        }

        // POST: Route/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Route route = db.Routes.Find(id);
                db.Routes.Remove(route);
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
