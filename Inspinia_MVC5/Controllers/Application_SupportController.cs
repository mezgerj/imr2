using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inspinia_MVC5.Models;
using System.Collections;

namespace Inspinia_MVC5.Controllers
{
    public class Application_SupportController : Controller
    {
        private ScaffoldingContext db = new ScaffoldingContext();

        // GET: /Application_Support/
        public ActionResult Index()
        {
            return View(db.Application_Support.ToList());
        }

        // GET: /Application_Support/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application_Support application_Support = db.Application_Support.Find(id);
            if (application_Support == null)
            {
                return HttpNotFound();
            }
            return View(application_Support);
        }

        // GET: /Application_Support/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Application_Support/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Application_Id,Supporter_Id")] Application_Support application_Support)
        {
            if (ModelState.IsValid)
            {
                db.Application_Support.Add(application_Support);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(application_Support);
        }

        // GET: /Application_Support/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application_Support application_Support = db.Application_Support.Find(id);
            if (application_Support == null)
            {
                return HttpNotFound();
            }
            return View(application_Support);
        }

        // POST: /Application_Support/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Application_Id,Supporter_Id")] Application_Support application_Support)
        {
            if (ModelState.IsValid)
            {
                db.Entry(application_Support).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(application_Support);
        }

        // GET: /Application_Support/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application_Support application_Support = db.Application_Support.Find(id);
            if (application_Support == null)
            {
                return HttpNotFound();
            }
            return View(application_Support);
        }

        // POST: /Application_Support/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Application_Support application_Support = db.Application_Support.Find(id);
            db.Application_Support.Remove(application_Support);
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

        private void Print(string user, string pension, string lifeAssurance)
        {
            Console.WriteLine(String.Format("User: '{0}', Pension: '{1}', Life Assurance: '{2}'", user, pension, lifeAssurance));
        }

        // GET: /Application_Support/Details/5
        public ActionResult Join(int? id)
        {
            /*
            if (id == null)
            {
                Console.Write("failed");
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             * */
            
            var users = (from app in db.Applications
                         join mid in db.Application_Support 
                            on app.Application_Id equals mid.Application_Id 
                                join user in db.Supporters
                                    on mid.Supporter_Id equals user.Supporter_Id
                          select new {
                              app.Name,
                              user.FirstName,
                              user.LastName
                          });

            foreach (var result in users)
                Print(result.Name, result.FirstName, result.LastName);


            return View(db.Application_Support.ToList());

            /*Application_Support application_Support = db.Application_Support.Where(i => i.Application_Id == id);
            if (application_Support == null)
            {
                return HttpNotFound();
            }
            return View(application_Support);*/
        }
    }
}
