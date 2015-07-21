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
    public class CompaniesController : Controller
    {
        private ScaffoldingContext db = new ScaffoldingContext();

        // GET: /Companies/
        public ActionResult Index()
        {
            return View(db.Companies.ToList());
        }

        // GET: /Companies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: /Companies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Company_Id,Name,Email,Phone,Street,City,State,Country,PostalCode,Description,Status,Admin_Id,Company_Url")] Company company)
        {
            if (ModelState.IsValid)
            {
                //Error checking
                bool valid = true;

                //Error checking for nulls
                if (company.Name == null)
                {
                    TempData["msg"] = "Please put in a name.";
                    ViewBag.nameError = TempData["msg"];
                    valid = false;
                }
                if (company.Email == null)
                {
                    TempData["msg"] = "Pleae put in an email.";
                    ViewBag.emailError = TempData["msg"];
                    valid = false;
                }
                if (company.Status == null)
                {
                    company.Status = "Pending";
                }

                //Error checking for duplicates
                foreach (Inspinia_MVC5.Models.Company comp in db.Companies)
                {
                    if (comp.Name == company.Name)
                    {
                        TempData["msg"] = "Another company is already using this name.";
                        ViewBag.nameError = TempData["msg"];
                        valid = false;
                    }
                }

                if (valid)
                {
                    db.Companies.Add(company);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(company);
        }

        // GET: /Companies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: /Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Company_Id,Name,Email,Phone,Street,City,State,Country,PostalCode,Description,Status,Admin_Id,Company_Url")] Company company)
        {
            if (ModelState.IsValid)
            {
                //Error checking
                bool valid = true;

                //Error checking for nulls
                if (company.Email == null)
                {
                    TempData["msg"] = "Pleae put in an email.";
                    ViewBag.emailError = TempData["msg"];
                    valid = false;
                }

                if (valid)
                {
                    db.Entry(company).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(company);
        }

        // GET: /Companies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company company = db.Companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: /Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Company company = db.Companies.Find(id);
            db.Companies.Remove(company);
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
