using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyCanTeen.Areas.Common;
using QuanLyCanTeen.Models;

namespace QuanLyCanTeen.Areas.Admin.Controllers
{
    public class MENUsController : CheckSessionsController
    {
        private DBEntities db = new DBEntities();

        // GET: Admin/MENUs
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            dbCommon db = new dbCommon();
            var model = db.ListMenus(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
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
                SetAlert("Create Menu successfully", "success");
                return RedirectToAction("Index");
            }
            SetAlert("Create Menu was failed", "error");
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
                SetAlert("Edit Menu successfully", "success");
                return RedirectToAction("Index");
            }
            SetAlert("Edit Menu was failed", "error");
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
            try
            {
                MENU mENU = db.MENUs.Find(id);
                db.MENUs.Remove(mENU);
                db.SaveChanges();
                SetAlert("Delete Menu successfully", "success");
                return RedirectToAction("Index");

            }
            catch(Exception e)
            {
                SetAlert("Delete Menu was failed, maybe there some reference on it", "error");
                return RedirectToAction("Delete", "MENUs");
            }
            
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
