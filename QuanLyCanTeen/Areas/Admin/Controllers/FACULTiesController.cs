using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyCanTeen.Models;

namespace QuanLyCanTeen.Areas.Admin.Controllers
{
    public class FACULTiesController : Controller
    {
        private DBEntities db = new DBEntities();

        // GET: Admin/FACULTies
        public ActionResult Index()
        {
            return View(db.FACULTies.ToList());
        }

        // GET: Admin/FACULTies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACULTY fACULTY = db.FACULTies.Find(id);
            if (fACULTY == null)
            {
                return HttpNotFound();
            }
            return View(fACULTY);
        }

        // GET: Admin/FACULTies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/FACULTies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FACULTY_CODE,FACULTY_NAME,STATUS")] FACULTY fACULTY)
        {
            if (ModelState.IsValid)
            {
                db.FACULTies.Add(fACULTY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fACULTY);
        }

        // GET: Admin/FACULTies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACULTY fACULTY = db.FACULTies.Find(id);
            if (fACULTY == null)
            {
                return HttpNotFound();
            }
            return View(fACULTY);
        }

        // POST: Admin/FACULTies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FACULTY_CODE,FACULTY_NAME,STATUS")] FACULTY fACULTY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fACULTY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fACULTY);
        }

        // GET: Admin/FACULTies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FACULTY fACULTY = db.FACULTies.Find(id);
            if (fACULTY == null)
            {
                return HttpNotFound();
            }
            return View(fACULTY);
        }

        // POST: Admin/FACULTies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FACULTY fACULTY = db.FACULTies.Find(id);
            db.FACULTies.Remove(fACULTY);
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
