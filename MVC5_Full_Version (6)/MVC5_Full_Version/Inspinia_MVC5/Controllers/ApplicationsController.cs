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
    public class ApplicationsController : Controller
    {
        private ScaffoldingContext db = new ScaffoldingContext();

        // GET: /Applications/
        public ActionResult Index()
        {
            return View(db.Applications.ToList());
        }

        // GET: /Applications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }

            //Finds all the users with same company id as the application. 
            IEnumerable<SelectListItem> users = from user in db.Supporters.ToList()
                                                where user.Company_Id.Equals(application.Company_Id)
                                                select new SelectListItem
                                                {
                                                    Text = user.FirstName + " " + user.LastName,
                                                    Value = user.Supporter_Id.ToString()
                                                };
            ViewData["Supporter_Id"] = users;
           
            return View(application);
        }

        // GET: /Applications/Create
        public ActionResult Create()
        {
            ViewBag.Company_Id = new SelectList(db.Companies, "Company_Id", "Name");
            return View();
        }

        // POST: /Applications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Application_Id,Name,Description,Company_Id,ApplicationToken")] Application application)
        {
            if (ModelState.IsValid)
            {
                //Error checking
                bool valid = true;

                //Error checking for nulls
                if (application.Name == null)
                {
                    TempData["msg"] = "Please put in a name.";
                    ViewBag.nameError = TempData["msg"];
                    valid = false;
                }
                if (application.Company_Id == null)
                {
                    TempData["msg"] = "Pleae select a company.";
                    ViewBag.companyError = TempData["msg"];
                    valid = false;
                }

                if (valid) { 
                    db.Applications.Add(application);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Company_Id = new SelectList(db.Companies, "Company_Id", "Name", application.Company_Id);
            return View(application);
        }

        // GET: /Applications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            ViewBag.Company_Id = new SelectList(db.Companies, "Company_Id", "Name", application.Company_Id);
            return View(application);
        }

        // POST: /Applications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Application_Id,Name,Description,Company_Id,ApplicationToken")] Application application)
        {
            if (ModelState.IsValid)
            {
                //Error checking
                bool valid = true;

                //Error checking for nulls
                if (application.Name == null)
                {
                    TempData["msg"] = "Please put in a name.";
                    ViewBag.nameError = TempData["msg"];
                    valid = false;
                }

                if (valid) { 
                    db.Entry(application).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Company_Id = new SelectList(db.Companies, "Company_Id", "Name", application.Company_Id);
            return View(application);
        }

        // GET: /Applications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Application application = db.Applications.Find(id);
            if (application == null)
            {
                return HttpNotFound();
            }
            return View(application);
        }

        // POST: /Applications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Application application = db.Applications.Find(id);
            db.Applications.Remove(application);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AssignUser([Bind(Include = "Application_Id,Supporter_Id")] Application_Supporters model)
        {
            
            //Supporter currentSupporter = db.Supporters.Find(WebSecurity.CurrentUserId);

            //if (application.Company_Id == currentSupporter.Company_Id || currentSupporter.Role_Id == 1)
            //{

            //Error checking
            bool valid = true;

            //Error checking for duplicates
            foreach (Inspinia_MVC5.Models.Application_Supporters entry in db.Application_Supporters)
            {
                if (entry.Application_Id == model.Application_Id && entry.Supporter_Id == model.Supporter_Id)
                {
                    TempData["msg"] = "This user is already a supporter of this application.";
                    ViewBag.assignError = TempData["msg"];
                    valid = false;
                } 
            }

            if (valid)
            {
                db.Application_Supporters.Add(model);

                //application.Supporters.Add(db.Supporters.Find(model.Supporter_Id));
                db.SaveChanges();
                
            }
            return RedirectToAction("Details", new { id = model.Application_Id });
            /*
            }
            else
            {
                //TODO error page
                return View();
            } */
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RemoveUser([Bind(Include = "Application_Id,Supporter_Id")] Application_Supporters model)
        {
        
            //Error checking
            bool valid = false;
            TempData["msg"] = "This user is already not a supporter of this application.";
            ViewBag.removeError = TempData["msg"];

            //Error checking for duplicates
            foreach (Inspinia_MVC5.Models.Application_Supporters entry in db.Application_Supporters)
            {
                if (entry.Application_Id == model.Application_Id && entry.Supporter_Id == model.Supporter_Id)
                {
                    TempData["msg"] = "";
                    ViewBag.removeError = TempData["msg"];
                    valid = true;
                } 
            }

            if (valid)
            {
                Application_Supporters removeEntry = db.Application_Supporters.Find(model.Application_Id, model.Supporter_Id);
                db.Application_Supporters.Remove(removeEntry);
                db.SaveChanges();
               
            }
            return RedirectToAction("Details", new { id = model.Application_Id });
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
