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
    public class ContentsController : Controller
    {
        private ScaffoldingContext db = new ScaffoldingContext();

        // GET: /Contents/
        public ActionResult Index()
        {
            var contents = db.Contents.Include(c => c.ContentType);
            return View(contents.ToList());
        }

        // GET: /Contents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // GET: /Contents/Create
        public ActionResult Create()
        {
            ViewBag.ContentType_Id = new SelectList(db.ContentTypes, "ContentType_Id", "TypeName");
            ViewBag.Application_Id = new SelectList(db.Applications, "Application_Id", "Name");
            return View();
        }

        // POST: /Contents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Content_Id,Title,Description,Application_Id,ContentType_Id,Path,Url,DownloadTime,Seq,Place")] Content content)
        {
            if (ModelState.IsValid)
            {
                //Error checking
                bool valid = true;

                //Error checking for nulls
                if (content.Title == null)
                {
                    TempData["msg"] = "Please put in a title.";
                    ViewBag.titleError = TempData["msg"];
                    valid = false;
                }

                if (valid)
                {
                    db.Contents.Add(content);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.ContentType_Id = new SelectList(db.ContentTypes, "ContentType_Id", "TypeName", content.ContentType_Id);
            ViewBag.Application_Id = new SelectList(db.Applications, "Application_Id", "Name", content.Application_Id);
            return View(content);
        }

        // GET: /Contents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContentType_Id = new SelectList(db.ContentTypes, "ContentType_Id", "TypeName", content.ContentType_Id);
            ViewBag.Application_Id = new SelectList(db.Applications, "Application_Id", "Name", content.Application_Id);
            return View(content);
        }

        // POST: /Contents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Content_Id,Title,Description,Application_Id,ContentType_Id,Path,Url,DownloadTime,Seq,Place")] Content content)
        {
            if (ModelState.IsValid)
            {
                //Error checking
                bool valid = true;

                //Error checking for nulls
                if (content.Title == null)
                {
                    TempData["msg"] = "Please put in a title.";
                    ViewBag.titleError = TempData["msg"];
                    valid = false;
                }

                if (valid)
                {
                    db.Entry(content).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ContentType_Id = new SelectList(db.ContentTypes, "ContentType_Id", "TypeName", content.ContentType_Id);
            ViewBag.Application_Id = new SelectList(db.Applications, "Application_Id", "Name", content.Application_Id);
            return View(content);
        }

        // GET: /Contents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // POST: /Contents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Content content = db.Contents.Find(id);
            db.Contents.Remove(content);
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
