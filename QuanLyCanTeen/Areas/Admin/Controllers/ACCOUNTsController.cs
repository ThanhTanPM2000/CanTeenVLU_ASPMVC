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
    public class ACCOUNTsController : CheckSessionsController
    {
        private DBEntities db = new DBEntities();

        // GET: Admin/ACCOUNTs
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            dbCommon db = new dbCommon();
            var model = db.ListAccounts(searchString, page, pageSize);
            //var fOODs = db.FOODs.Include(f => f.CATEGORY);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        // GET: Admin/ACCOUNTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACCOUNT aCCOUNT = db.ACCOUNTs.Find(id);
            if (aCCOUNT == null)
            {
                return HttpNotFound();
            }
            return View(aCCOUNT);
        }

        // GET: Admin/ACCOUNTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ACCOUNTs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EMAIL,PASSWORD,FULL_NAME,STATUS,ROLE")] ACCOUNT aCCOUNT)
        {
            if (ModelState.IsValid)
            {
                db.ACCOUNTs.Add(aCCOUNT);
                db.SaveChanges();
                SetAlert("Thêm thành công", "success");
                return RedirectToAction("Index");
            }
            SetAlert("Thêm không thành công", "error");
            return View(aCCOUNT);
        }

        // GET: Admin/ACCOUNTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACCOUNT aCCOUNT = db.ACCOUNTs.Find(id);
            if (aCCOUNT == null)
            {
                return HttpNotFound();
            }
            return View(aCCOUNT);
        }

        // POST: Admin/ACCOUNTs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EMAIL,PASSWORD,FULL_NAME,STATUS,ROLE")] ACCOUNT aCCOUNT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aCCOUNT).State = EntityState.Modified;
                db.SaveChanges();
                SetAlert("Chỉnh sửa thành công", "success");
                return RedirectToAction("Index");
            }
            SetAlert("Chỉnh sửa không thành công", "error");
            return View(aCCOUNT);
        }

        // GET: Admin/ACCOUNTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ACCOUNT aCCOUNT = db.ACCOUNTs.Find(id);
            if (aCCOUNT == null)
            {
                return HttpNotFound();
            }
            return View(aCCOUNT);
        }

        // POST: Admin/ACCOUNTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                ACCOUNT aCCOUNT = db.ACCOUNTs.Find(id);
                db.ACCOUNTs.Remove(aCCOUNT);
                db.SaveChanges();
                SetAlert("Xóa thành công", "success");
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                SetAlert("Xóa không thành công", "error");
                return RedirectToAction("Delete","ACCOUNTs");
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
