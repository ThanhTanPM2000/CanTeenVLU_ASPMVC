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
    public class FOODsController : CheckSessionsController
    {
        private DBEntities db = new DBEntities();

        // GET: Admin/FOODs
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            dbCommon db = new dbCommon();
            var model = db.ListFoods(searchString, page, pageSize);
            //var fOODs = db.FOODs.Include(f => f.CATEGORY);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        // GET: Admin/FOODs/Create
        public ActionResult Create()
        {
            ViewBag.CATEGORY_ID = new SelectList(db.CATEGORies, "ID", "CATEGORY_CODE");
            return View();
        }

        // POST: Admin/FOODs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FOOD_CODE,FOOD_NAME,CATEGORY_ID,DESCRIPTION,PRICE,IMAGE_URL,STATUS")] FOOD fOOD)
        {
            if (ModelState.IsValid)
            {
                db.FOODs.Add(fOOD);
                db.SaveChanges();
                SetAlert("Create Food successfully", "success");
                return RedirectToAction("Index");
            }
            SetAlert("Create Food was failed", "error");
            ViewBag.CATEGORY_ID = new SelectList(db.CATEGORies, "ID", "CATEGORY_CODE", fOOD.CATEGORY_ID);
            return View(fOOD);
        }

        // GET: Admin/FOODs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FOOD fOOD = db.FOODs.Find(id);
            if (fOOD == null)
            {
                return HttpNotFound();
            }
            ViewBag.CATEGORY_ID = new SelectList(db.CATEGORies, "ID", "CATEGORY_CODE", fOOD.CATEGORY_ID);
            return View(fOOD);
        }

        // POST: Admin/FOODs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FOOD_CODE,FOOD_NAME,CATEGORY_ID,DESCRIPTION,PRICE,IMAGE_URL,STATUS")] FOOD fOOD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fOOD).State = EntityState.Modified;
                db.SaveChanges();
                SetAlert("Edit Food successfully", "success");
                return RedirectToAction("Index");
            }
            SetAlert("Edit Food was failed", "error");
            ViewBag.CATEGORY_ID = new SelectList(db.CATEGORies, "ID", "CATEGORY_CODE", fOOD.CATEGORY_ID);
            return View(fOOD);
        }

        // GET: Admin/FOODs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FOOD fOOD = db.FOODs.Find(id);
            if (fOOD == null)
            {
                return HttpNotFound();
            }
            return View(fOOD);
        }

        // POST: Admin/FOODs/Delete/5
        [HttpPost, ActionName("Delete"),ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                FOOD fOOD = db.FOODs.Find(id);
                db.FOODs.Remove(fOOD);
                db.SaveChanges();
                SetAlert("Delete Food successfully", "success");
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                SetAlert("Delete Food was failed, maybe there some reference on it", "error");
                return RedirectToAction("Delete", "FOODs");
                
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
