using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inspinia_MVC5.Models;
using System.Diagnostics;

namespace Inspinia_MVC5.Controllers
{
    public class EventsController : Controller
    {
        private ScaffoldingContext db = new ScaffoldingContext();
        // GET: Events
        public ActionResult Index()
        {
            return View(db.Events.OrderByDescending(model => model.Start_Date).ToList());
        }

        // GET: /Events/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Description,Category,Application_Id,Start_Date,End_Date,Longitude,Latitude")] Event events)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(events);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(events);
        }

        // GET: /Events/Edit/5
        public ActionResult Event(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event Event = db.Events.Find(id);
            if (Event == null)
            {
                return HttpNotFound();
            }
            return View(Event);
        }

        // POST: /Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Event([Bind(Include = "ID,Title,Description,Category,Application_Id,Start_Date,End_Date,Longitude,Latitude")] Event Event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(Event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(Event);
        }

        // GET: /Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event Event = db.Events.Find(id);
            if (Event == null)
            {
                return HttpNotFound();
            }
            return View(Event);
        }

        // POST: /Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event Event = db.Events.Find(id);
            db.Events.Remove(Event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: /Geolocations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult EditDescription(int? id, [Bind(Prefix = "summernote")] String value)
        {
            Event events = db.Events.Find(id);
            if (ModelState.IsValid)
            {
                //db.Entry(events).State = EntityState.Modified;
                // db.SaveChanges();
                //return RedirectToAction("Index");
            }
            return View(events);
        }

        // POST: /Geolocations1/EditField
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //This method takes in a value passed through the editable table interface and sets the name to that value, saving the result
        [HttpPost]

        public ActionResult EditField(int? id, String value)
        {
            //Test code, write the passed id to the local console
            Console.Write(id);
            Event currentEvent = db.Events.Find(id); // find the geolocation with the corresponding id
            currentEvent.Title = value;

            db.SaveChanges();
            return new EmptyResult();

        }

        public String formatDate(int id, String type, String desiredValue)
        {
            Event currentEvent = db.Events.Find(id);
            DateTime date;
            String result;
            if (type == "start") {
                 date = currentEvent.Start_Date;
            } else {
                date = currentEvent.End_Date;
            }
            
            if (desiredValue == "dayOfWeek") {
                if (currentEvent.Start_Date.DayOfYear == currentEvent.End_Date.DayOfYear)
                {
                    result = date.DayOfWeek.ToString();
                }
                else
                {
                    result = currentEvent.Start_Date.DayOfWeek.ToString() + " to  " + currentEvent.End_Date.DayOfWeek.ToString();
                }
                

            } else if (desiredValue == "daysSince") {
                TimeSpan resultSpan = DateTime.Today.Subtract(date);
                result = resultSpan.Days.ToString();

            }
            else if (desiredValue == "dateNoYear")
            {
                if (currentEvent.Start_Date.DayOfYear == currentEvent.End_Date.DayOfYear)
                {
                    result = date.ToString("MMMM dd");
                }
                else
                {
                    result = currentEvent.Start_Date.ToString("MMMM dd") + " to " + currentEvent.End_Date.ToString("MMMM dd");
                }
            }
            else
            {
                result = "Incorrect String Parameter";
            }

            return result;
        }
    }
}