using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inspinia_MVC5.Models;
using Inspinia_MVC5.UtilityFolder;

namespace Inspinia_MVC5.Controllers
{
    public class SupportersController : Controller
    {
        private ScaffoldingContext db = new ScaffoldingContext();

        // GET: /Supporters/
        public ActionResult Index()
        {
            return View(db.Supporters.ToList());
        }

        // GET: /Supporters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supporter supporter = db.Supporters.Find(id);
            if (supporter == null)
            {
                return HttpNotFound();
            }
            return View(supporter);
        }

        // GET: /Supporters/Create
        public ActionResult Create()
        {
            //Used to show the different role options in a drop down menu
            //if (supporter.Role_Id == 1)
            //{
            ViewBag.Role_Id = new SelectList(db.Supporter_Roles, "Role_Id", "Name");
            ViewBag.Company_Id = new SelectList(db.Companies, "Company_Id", "Name");
            //ViewBag.Role = new SelectList(new[] { "SuperAdmin", "Admin", "Manager", "Supporter" });
            /*}
            else
            {
                ViewBag.Role = new SelectList(new[] { "Admin", "Manager", "Supporter" });
            }*/
            return View();
        }

        // POST: /Supporters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Supporter_Id,UserName,Company_Id,FirstName,LastName,Email,Role_Id")] Supporter supporter)
        {
            //Supporter supporter = db.Supporters.Find(WebSecurity.CurrentUserId);

            //if (supporter.Role_Id == 1)
            //{
                //ViewBag.Role = new SelectList(new[] { "SuperAdmin", "Admin", "Manager", "Supporter" });
            /*}
            else
            {
                ViewBag.Role = new SelectList(new[] { "Admin", "Manager", "Supporter" });
            }*/

            if (ModelState.IsValid)
            {

                supporter.FirstTime = true;
                string password = PasswordUtility.GenRandPassword(10);
                supporter.Password = password;

                //Error checking
                bool valid = true;

                //Error checking for nulls
                if (supporter.UserName == null)
                {
                    TempData["msg"] = "Please put in a user name.";
                    ViewBag.usernameError = TempData["msg"];
                    valid = false;
                }
                if (supporter.Email == null)
                {
                    TempData["msg"] = "Pleae put in an email.";
                    ViewBag.emailError = TempData["msg"];
                    valid = false;
                }
                if (supporter.Role_Id == null)
                {
                    TempData["msg"] = "Pleae select a role.";
                    ViewBag.roleError = TempData["msg"];
                    valid = false;
                }

                //Error checking for duplicates
                foreach (Inspinia_MVC5.Models.Supporter sup in db.Supporters)
                {
                    if (sup.UserName == supporter.UserName)
                    {
                        TempData["msg"] = "Another user is already using this user name.";
                        ViewBag.usernameError = TempData["msg"];
                        valid = false;
                    }
                    if (sup.Email == supporter.Email)
                    {
                        TempData["msg"] = "Another user is already using this email.";
                        ViewBag.emailError = TempData["msg"];
                        valid = false;
                    }
                }

                if (valid) 
                {
                    EmailUtility.SendUserCreationEmail(supporter.Email, supporter.LastName, supporter.UserName, password);

                    db.Supporters.Add(supporter);

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }
            ViewBag.Role_Id = new SelectList(db.Supporter_Roles, "Role_Id", "Name", supporter.Role_Id);
            ViewBag.Company_Id = new SelectList(db.Companies, "Company_Id", "Name", supporter.Company_Id);
            return View(supporter);
        }

        // GET: /Supporters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supporter supporter = db.Supporters.Find(id);
            if (supporter == null)
            {
                return HttpNotFound();
            }
            ViewBag.Role_Id = new SelectList(db.Supporter_Roles, "Role_Id", "Name", supporter.Role_Id);
            ViewBag.Company_Id = new SelectList(db.Companies, "Company_Id", "Name", supporter.Company_Id);
            return View(supporter);
        }

        // POST: /Supporters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Supporter_Id,UserName,Company_Id,FirstName,LastName,Email,Phone,Street,City,State,Country,PostalCode,Password,FirstTime,Role_Id")] Supporter supporter)
        {
            if (ModelState.IsValid)
            {
                //Error checking
                bool valid = true;

                
                //Error checking for nulls
                if (supporter.Email == null)
                {
                    TempData["msg"] = "Pleae put in an email.";
                    ViewBag.emailError = TempData["msg"];
                    valid = false;
                }
                /*Checking for duplicates seems to mess something up with db.Entry(supporter).State = EntityState.Modified;
                //Error checking for duplicates
                foreach (Inspinia_MVC5.Models.Supporter sup in db.Supporters)
                {
                    if (sup.Email == supporter.Email && sup.UserName != supporter.UserName)
                    {
                        TempData["msg"] = "Another user is already using this email.";
                        ViewBag.emailError = TempData["msg"];
                        valid = false;
                    }
                }*/              
                  
                if (valid) { 
                    db.Entry(supporter).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Role_Id = new SelectList(db.Supporter_Roles, "Role_Id", "Name", supporter.Role_Id);
            ViewBag.Company_Id = new SelectList(db.Companies, "Company_Id", "Name", supporter.Company_Id);
            return View(supporter);
        }

        // GET: /Supporters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supporter supporter = db.Supporters.Find(id);
            if (supporter == null)
            {
                return HttpNotFound();
            }
            return View(supporter);
        }

        // POST: /Supporters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supporter supporter = db.Supporters.Find(id);
            db.Supporters.Remove(supporter);
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
