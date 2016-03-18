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
using OreFun2014.ViewModels;

namespace OreFun2014.Controllers
{
    public class PassengerController : Controller
    {
        private OreFunContext db = new OreFunContext();

        // GET: Passenger
        //public ActionResult Index(string sortOrder)
        //{
        //    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    ViewBag.LNameSortParm = String.IsNullOrEmpty(sortOrder) ? "Lname_desc" : "LName";
        //    var passengers = from s in db.Passengers
        //                  select s;
        //    switch (sortOrder)
        //    {
        //        case "name_desc":
        //            passengers = passengers.OrderByDescending(s => s.FirstName);
        //            break;
        //        case "Lname_desc":
        //            passengers = passengers.OrderByDescending(s => s.LastName);
        //            break;
        //        case "LName":
        //            passengers = passengers.OrderBy(s => s.LastName);
        //            break;
        //        default:
        //            passengers = passengers.OrderBy(s => s.FirstName);
        //            break;
        //    }
        //    return View(passengers.ToList());
        //}

        //public ActionResult Index(int? id, int? TicketID, int? RouteID, int? TrainID)
             public ActionResult Index(int? id, int? TicketID)
        {
            var viewModel = new PassengerIndexData();
            viewModel.Passengers = db.Passengers
                .Include(i => i.Tickets)
                //.Include(i => i.Trains)
                //.Include(i => i.Routes)
                .OrderBy(i => i.LastName);
                

            if (id != null)
            {
                ViewBag.PassengerID = id.Value;
                viewModel.Tickets = viewModel.Passengers.Where(
                    i => i.PassengerID == id.Value).Single().Tickets;
            }

            if (TicketID != null)
            {
                ViewBag.TicketID = TicketID.Value;
                //viewModel.Enrollments = viewModel.Courses.Where(
                //    x => x.CourseID == courseID).Single().Enrollments;
            }

            return View(viewModel);
        }

        // GET: Passenger/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger passenger = db.Passengers.Find(id);
            if (passenger == null)
            {
                return HttpNotFound();
            }
            return View(passenger);
        }

        // GET: Passenger/PassReport/5
        public ActionResult PassReport(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger passenger = db.Passengers.Find(id);
            if (passenger == null)
            {
                return HttpNotFound();
            }

            return View(passenger);
        }

        // GET: Passenger/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Passenger/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PassengerID,FirstName,LastName,Baggage")] Passenger passenger)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    db.Passengers.Add(passenger);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(passenger);
        }

        // GET: Passenger/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Passenger passenger = db.Passengers.Find(id);
            if (passenger == null)
            {
                return HttpNotFound();
            }
            return View(passenger);
        }

        // POST: Passenger/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PassengerID,FirstName,LastName,Baggage")] Passenger passenger)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(passenger).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(passenger);
        }

        // GET: Passenger/Delete/5
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
            Passenger passenger = db.Passengers.Find(id);
            if (passenger == null)
            {
                return HttpNotFound();
            }
            return View(passenger);
        }

        // POST: Passenger/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Passenger passenger = db.Passengers.Find(id);
                db.Passengers.Remove(passenger);
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
