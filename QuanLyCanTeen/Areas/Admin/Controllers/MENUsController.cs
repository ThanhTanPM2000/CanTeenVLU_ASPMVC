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
    public class MENUsController : Controller
    {
        private DBEntities db = new DBEntities();

        // GET: Admin/MENUs
        public ActionResult Index()
        {
            var mENUs = db.MENUs.Include(m => m.ACCOUNT).Include(m => m.FOOD);
            return View(mENUs.ToList());
        }

        // GET: Admin/MENUs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MENU mENU = db.MENUs.Find(id);
            if (mENU == null)
            {
                return HttpNotFound();
            }
            return View(mENU);
        }

        // GET: Admin/MENUs/Create
        public ActionResult Create()
        {
            ViewBag.ACCOUNT_ID = new SelectList(db.ACCOUNTs, "ID", "EMAIL");
            ViewBag.FOOD_ID = new SelectList(db.FOODs, "ID", "FOOD_CODE");
            return View();
        }

        // POST: Admin/MENUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FOOD_ID,ACCOUNT_ID,DATE,QUANTITY,PRICE,STATUS")] MENU mENU)
        {
            if (ModelState.IsValid)
            {
                db.MENUs.Add(mENU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ACCOUNT_ID = new SelectList(db.ACCOUNTs, "ID", "EMAIL", mENU.ACCOUNT_ID);
            ViewBag.FOOD_ID = new SelectList(db.FOODs, "ID", "FOOD_CODE", mENU.FOOD_ID);
            return View(mENU);
        }

        // GET: Admin/MENUs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MENU mENU = db.MENUs.Find(id);
            if (mENU == null)
            {
                return HttpNotFound();
            }
            ViewBag.ACCOUNT_ID = new SelectList(db.ACCOUNTs, "ID", "EMAIL", mENU.ACCOUNT_ID);
            ViewBag.FOOD_ID = new SelectList(db.FOODs, "ID", "FOOD_CODE", mENU.FOOD_ID);
            return View(mENU);
        }

        // POST: Admin/MENUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FOOD_ID,ACCOUNT_ID,DATE,QUANTITY,PRICE,STATUS")] MENU mENU)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mENU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ACCOUNT_ID = new SelectList(db.ACCOUNTs, "ID", "EMAIL", mENU.ACCOUNT_ID);
            ViewBag.FOOD_ID = new SelectList(db.FOODs, "ID", "FOOD_CODE", mENU.FOOD_ID);
            return View(mENU);
        }

        // GET: Admin/MENUs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MENU mENU = db.MENUs.Find(id);
            if (mENU == null)
            {
                return HttpNotFound();
            }
            return View(mENU);
        }

        // POST: Admin/MENUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MENU mENU = db.MENUs.Find(id);
            db.MENUs.Remove(mENU);
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
