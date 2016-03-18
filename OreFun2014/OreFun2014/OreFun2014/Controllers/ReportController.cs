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

//namespace OreFun2014.Controllers
//{
//    public class ReportController : Controller
//    {
//        private OreFunContext db = new OreFunContext();
//        public ActionResult Routes()
//        {
//            //IQueryable<RoutesGroup> data = from StationName in db.Routes
//            //                                   //join Crew in db.Pirates on Pirate equals Crew.PirateID
//            //                                   group StationName by StationName.Station.StationName into RoutesGroup
//            //                                   select new RoutesGroup()
//            //                                   {
//            //                                       StationName = RoutesGroup.Key
//            //                                   };

//            return View(tickets);
//        }

//        public ActionResult Tickets(int? id)
//        {
//            var tickets = db.Tickets.Include(t => t.Passenger).Include(t => t.Route);

//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            Ticket ticket = db.Tickets.Find(id);
//            if (ticket == null)
//            {
//                return HttpNotFound();
//            }
//            return View(tickets);

//            //return View(tickets.ToList());
//        }

//        public ActionResult RouteMap()
//        {
//            ViewBag.Message = "Your route map page.";

//            return View();
//        }
//    }
//}
