using System;
using QuanLyCanTeen.Models;
using System.Collections.Generic;
using QuanLyCanTeen.Areas.Admin.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLyCanTeen.Areas.Common;

namespace QuanLyCanTeen.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("index", "Login");
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                dbCommon db = new dbCommon(); // <-- declare object from class dbCommon (using directory path)
                var result = db.Login(model.Email, model.PassWord);
                if (result == 0)
                {
                    var user = db.GetById(model.Email);
                    var userSession = new UserLogin();
                    userSession.FULL_NAME = user.FULL_NAME;
                    userSession.ID = user.ID;
                    userSession.EMAIL = user.EMAIL;
                    userSession.STATUS = user.STATUS;
                    userSession.PASSWORD = user.PASSWORD;
                    userSession.ROLE = user.ROLE;

                    //string roles = "";
                    //user.Roles.ToList().ForEach(temp => { roles += temp.Name + ", "; });
                    //roles = roles.Substring(0, roles.Length > 2 ? roles.Length - 2 : roles.Length); // admin, editor
                    //roles = roles.Length > 0 ? roles : "don't have any roles";
                    //userSession.Roles = roles;

                    Session.Add("USER_SECTION", userSession);

                    ViewBag.Message = "Something went wrong";
                    return RedirectToAction("Index", "FOODs");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("PassWord", "mật khẩu nhập không đúng");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("Email", "Email nhập không tồn tại");
                }
                else
                {
                    ModelState.AddModelError("", "đăng nhập không đúng");
                }
            }
            return View("index");
        }

        

       
    }
}