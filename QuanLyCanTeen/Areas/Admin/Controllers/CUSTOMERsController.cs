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
    public class CUSTOMERsController : CheckSessionsController
    {
        private DBEntities db = new DBEntities();

        // GET: Admin/CUSTOMERs
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            dbCommon db = new dbCommon();
            var model = db.ListCus(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        // GET: Admin/CUSTOMERs/Create
        public ActionResult Create()
        {
            ViewBag.FACULTY_ID = new SelectList(db.FACULTies, "ID", "FACULTY_CODE");
            return View();
        }

        // POST: Admin/CUSTOMERs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Email,PasswordHash,UserName,PhoneNumber,STATUS,CUSTOMER_TYPE,FACULTY_ID")] AspNetUser cUSTOMER)
        {
            if (ModelState.IsValid)
            {
                db.AspNetUsers.Add(cUSTOMER);
                db.SaveChanges();
                SetAlert("Create Customer successfully", "success");
                return RedirectToAction("Index");
            }
            SetAlert("Create Customer failed", "error");
            ViewBag.FACULTY_ID = new SelectList(db.FACULTies, "ID", "FACULTY_CODE", cUSTOMER.FACULTY_ID);
            return View(cUSTOMER);
        }

        // GET: Admin/CUSTOMERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser cUSTOMER = db.AspNetUsers.Find(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            ViewBag.FACULTY_ID = new SelectList(db.FACULTies, "ID", "FACULTY_CODE", cUSTOMER.FACULTY_ID);
            return View(cUSTOMER);
        }

        // POST: Admin/CUSTOMERs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Email,PasswordHash,UserName,PhoneNumber,STATUS,CUSTOMER_TYPE,FACULTY_ID")] AspNetUser cUSTOMER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUSTOMER).State = EntityState.Modified;
                db.SaveChanges();
                SetAlert("Edit Customer successfully", "success");
                return RedirectToAction("Index");
            }
            SetAlert("Edit Customer was failed", "error");
            ViewBag.FACULTY_ID = new SelectList(db.FACULTies, "ID", "FACULTY_CODE", cUSTOMER.FACULTY_ID);
            return View(cUSTOMER);
        }

        // GET: Admin/CUSTOMERs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AspNetUser cUSTOMER = db.AspNetUsers.Find(id);
            if (cUSTOMER == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMER);
        }

        // POST: Admin/CUSTOMERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            try
            {
                AspNetUser cUSTOMER = db.AspNetUsers.Find(id);
                db.AspNetUsers.Remove(cUSTOMER);
                db.SaveChanges();
                SetAlert("Delete Customer successfully", "success");
                return RedirectToAction("Index");
            }catch(Exception e)
            {
                SetAlert("Delete Customer was failed, maybe there some reference on it", "error");
                return RedirectToAction("Delete", "CUSTOMERs");
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
