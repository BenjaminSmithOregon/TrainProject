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
    public class TicketController : Controller
    {
        private OreFunContext db = new OreFunContext();

        //// GET: Ticket
        //public ActionResult Index()
        //{
        //    var tickets = db.Tickets.Include(t => t.Passenger).Include(t => t.Route);
        //    return View(tickets.ToList());
        //}

        public ActionResult Index(int? id, int? RouteID)
        {
            var viewModel = new TicketIndexData();
            viewModel.Tickets = db.Tickets
                //.Include(i => i.Routes)
                //.Include(i => i.Trains)
                //.Include(i => i.Routes)
                .OrderBy(i => i.RouteDate);


            if (id != null)
            {
                ViewBag.TicketID = id.Value;
            }

            if (RouteID != null)
            {
                ViewBag.RouteID = RouteID.Value;
                //viewModel.Enrollments = viewModel.Courses.Where(
                //    x => x.CourseID == courseID).Single().Enrollments;
            }

            return View(viewModel);
        }

        // GET: Ticket/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Ticket/TicketReport/5
        public ActionResult TicketReport(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }

            return View(ticket);
        }

        // GET: Ticket/Create
        public ActionResult Create()
        {
            ViewBag.PassengerID = new SelectList(db.Passengers, "PassengerID", "FullName");
            ViewBag.RouteID = new SelectList(db.Routes, "RouteID", "RouteNumber");
            return View();
        }

        // POST: Ticket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RouteDate,RouteID,PassengerID,SeatAssignment")] Ticket ticket)
        {
            rValidateDate(ticket.RouteDate);
            try
            {
                if (ModelState.IsValid)
                {
                    db.Tickets.Add(ticket);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            ViewBag.PassengerID = new SelectList(db.Passengers, "PassengerID", "FullName", ticket.PassengerID);
            ViewBag.RouteID = new SelectList(db.Routes, "RouteID", "RouteNumber", ticket.RouteID);
            return View(ticket);
        }

        // GET: Ticket/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.PassengerID = new SelectList(db.Passengers, "PassengerID", "FullName", ticket.PassengerID);
            ViewBag.RouteID = new SelectList(db.Routes, "RouteID", "RouteNumber", ticket.RouteID);
            return View(ticket);
        }

        // POST: Ticket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketID,RouteID,RouteDate,PassengerID,SeatAssignment")] Ticket ticket)
        {
            rValidateDate(ticket.RouteDate);
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(ticket).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                ViewBag.PassengerID = new SelectList(db.Passengers, "PassengerID", "FullName", ticket.PassengerID);
                ViewBag.RouteID = new SelectList(db.Routes, "RouteID", "RouteNumber", ticket.RouteID);
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(ticket);
        }

        // GET: Ticket/Delete/5
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
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime? id)
        {
            try
            {
                Ticket ticket = db.Tickets.Find(id);
                db.Tickets.Remove(ticket);
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

        void rValidateDate(global::System.Nullable<global::System.DateTime> value)
        {
            DateTime dt = (DateTime)value;
            if (dt.CompareTo(DateTime.Now) < 0)
                ModelState.AddModelError("", "Date entered has already passed.");
        }
    }
}
