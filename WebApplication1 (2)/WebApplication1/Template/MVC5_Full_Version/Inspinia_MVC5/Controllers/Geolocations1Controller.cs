using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inspinia_MVC5.Models;

namespace Inspinia_MVC5.Controllers
{
    public class Geolocations1Controller : Controller
    {
        private ScaffoldingContext db = new ScaffoldingContext();

        // GET: /Geolocations1/
        public ActionResult Index()
        {
            return View(db.Geolocations.ToList());
        }

        // GET: /Geolocations1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Geolocation geolocation = db.Geolocations.Find(id);
            if (geolocation == null)
            {
                return HttpNotFound();
            }
            return View(geolocation);
        }

        // GET: /Geolocations1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Geolocations1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="GeolocationID,Name,Latitude,Longitude,Altitude,Description,Application_Id,Parent_Geo_Id,Range,DownloadTime,ContinentID,CityID,CountryID,StateID")] Geolocation geolocation)
        {
            if (ModelState.IsValid)
            {
                db.Geolocations.Add(geolocation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(geolocation);
        }

        // GET: /Geolocations1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Geolocation geolocation = db.Geolocations.Find(id);
            if (geolocation == null)
            {
                return HttpNotFound();
            }
            return View(geolocation);
        }

        // POST: /Geolocations1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="GeolocationID,Name,Latitude,Longitude,Altitude,Description,Application_Id,Parent_Geo_Id,Range,DownloadTime,ContinentID,CityID,CountryID,StateID")] Geolocation geolocation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(geolocation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(geolocation);
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
             Geolocation geolocation1 = db.Geolocations.Find(id); // find the geolocation with the corresponding id
             geolocation1.Name = value;
            
             db.SaveChanges();
             return new EmptyResult();
            

             
               
        }




        // GET: /Geolocations1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Geolocation geolocation = db.Geolocations.Find(id);
            if (geolocation == null)
            {
                return HttpNotFound();
            }
            return View(geolocation);
        }

        // POST: /Geolocations1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Geolocation geolocation = db.Geolocations.Find(id);
            db.Geolocations.Remove(geolocation);
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
