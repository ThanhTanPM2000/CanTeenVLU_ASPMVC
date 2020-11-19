using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using QuanLyCanTeen.Areas.Admin.Data;

namespace QuanLyCanTeen.Areas.Admin.Controllers
{
    public class CheckSessionsController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var session = Session["USER_SECTION"] as UserLogin;
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { Controller = "Login", action = "index", Area = "Admin" }));
            }
            base.OnActionExecuting(filterContext);
        }

        protected void SetAlert(string message, string type)
        {
            TempData["AlertMessage"] = message.Trim();
            TempData["Type"] = type.Trim();
        }
    }
}