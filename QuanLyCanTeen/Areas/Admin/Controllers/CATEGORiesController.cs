using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuanLyCanTeen.Models;
using QuanLyCanTeen.Areas.Common;

namespace QuanLyCanTeen.Areas.Admin.Controllers
{
    public class CATEGORiesController : CheckSessionsController
    {
        private DBEntities db = new DBEntities();

        // GET: Admin/CATEGORies
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            dbCommon db = new dbCommon();
            var model = db.ListCategorys(searchString, page, pageSize);
            //var fOODs = db.FOODs.Include(f => f.CATEGORY);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        // GET: Admin/CATEGORies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/CATEGORies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CATEGORY_CODE,CATEGORY_NAME,IMAGE_URL,STATUS")] CATEGORY cATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.CATEGORies.Add(cATEGORY);
                db.SaveChanges();
                SetAlert("Create Category successfully", "success");
                return RedirectToAction("Index");
            }
            SetAlert("Create Category was failed", "error");
            return View(cATEGORY);
        }

        // GET: Admin/CATEGORies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORY cATEGORY = db.CATEGORies.Find(id);
            if (cATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORY);
        }

        // POST: Admin/CATEGORies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CATEGORY_CODE,CATEGORY_NAME,IMAGE_URL,STATUS")] CATEGORY cATEGORY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cATEGORY).State = EntityState.Modified;
                db.SaveChanges();
                SetAlert("Edit Category successfully", "success");
                return RedirectToAction("Index");
            }
            SetAlert("Edit Category was failed", "error");
            return View(cATEGORY);
        }

        // GET: Admin/CATEGORies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CATEGORY cATEGORY = db.CATEGORies.Find(id);
            if (cATEGORY == null)
            {
                return HttpNotFound();
            }
            return View(cATEGORY);
        }

        // POST: Admin/CATEGORies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                CATEGORY cATEGORY = db.CATEGORies.Find(id);
                db.CATEGORies.Remove(cATEGORY);
                db.SaveChanges();
                SetAlert("Delete Category successfully", "success");
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                SetAlert("Delete Category was failed, maybe there some reference on it", "error");
                return RedirectToAction("Delete", "CATEGORies");
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
