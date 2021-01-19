using QuanLyCanTeen.Areas.Common;
using QuanLyCanTeen.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyCanTeen.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DBEntities db = new DBEntities();
            ViewData["Categories"] = db.CATEGORies.ToArray();
            ViewData["Foods"] = db.FOODs.ToArray();
            ViewData["Menus"] = db.MENUs.ToArray();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}