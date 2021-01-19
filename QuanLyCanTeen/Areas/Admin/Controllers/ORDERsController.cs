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
    public class ORDERsController : CheckSessionsController
    {
        private DBEntities db = new DBEntities();

        // GET: Admin/ORDERs
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            dbCommon db = new dbCommon();
            var model = db.ListOrder(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        public ActionResult Print(int id)
        {
            var printData = db.ORDERs.FirstOrDefault(x => x.ID == id);
            return View(printData);
        }

        // GET: Admin/ORDERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER oRDER = db.ORDERs.Find(id);
            if (oRDER == null)
            {
                return HttpNotFound();
            }
            return View(oRDER);
        }

        // GET: Admin/ORDERs/Create
        public ActionResult Create()
        {
            ViewBag.ACCOUNT_ID = new SelectList(db.ACCOUNTs, "ID", "EMAIL");
            ViewBag.CUSTOMER_ID = new SelectList(db.AspNetUsers, "ID", "EMAIL");
            return View();
        }

        // POST: Admin/ORDERs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ORDER_CODE,DATE,ACCOUNT_ID,CUSTOMER_ID,STATUS,FEEDBACK")] ORDER oRDER)
        {
            if (ModelState.IsValid)
            {
                db.ORDERs.Add(oRDER);
                db.SaveChanges();
                SetAlert("Create Order successfully", "success");
                return RedirectToAction("Index");
            }
            SetAlert("Create Order was failed", "error");
            ViewBag.ACCOUNT_ID = new SelectList(db.ACCOUNTs, "ID", "EMAIL", oRDER.ACCOUNT_ID);
            ViewBag.CUSTOMER_ID = new SelectList(db.AspNetUsers, "ID", "EMAIL", oRDER.CUSTOMER_ID);
            return View(oRDER);
        }

        // GET: Admin/ORDERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER oRDER = db.ORDERs.Find(id);
            if (oRDER == null)
            {
                return HttpNotFound();
            }
            ViewBag.ACCOUNT_ID = new SelectList(db.ACCOUNTs, "ID", "EMAIL", oRDER.ACCOUNT_ID);
            ViewBag.CUSTOMER_ID = new SelectList(db.AspNetUsers, "ID", "EMAIL", oRDER.CUSTOMER_ID);
            return View(oRDER);
        }

        // POST: Admin/ORDERs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ORDER_CODE,DATE,ACCOUNT_ID,CUSTOMER_ID,STATUS,FEEDBACK")] ORDER oRDER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oRDER).State = EntityState.Modified;
                db.SaveChanges();
                SetAlert("Edit Order successfully", "success");
                return RedirectToAction("Index");
            }
            SetAlert("Edit Order was failed", "error");
            ViewBag.ACCOUNT_ID = new SelectList(db.ACCOUNTs, "ID", "EMAIL", oRDER.ACCOUNT_ID);
            ViewBag.CUSTOMER_ID = new SelectList(db.AspNetUsers, "ID", "EMAIL", oRDER.CUSTOMER_ID);
            return View(oRDER);
        }

        // GET: Admin/ORDERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ORDER oRDER = db.ORDERs.Find(id);
            if (oRDER == null)
            {
                return HttpNotFound();
            }
            return View(oRDER);
        }

        // POST: Admin/ORDERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                ORDER oRDER = db.ORDERs.Find(id);
                db.ORDERs.Remove(oRDER);
                db.SaveChanges();
                SetAlert("Delete Order successfully", "success");
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                SetAlert("Delete Order was failed, maybe there some reference on it", "error");
                return RedirectToAction("Delete", "ORDERs");
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
