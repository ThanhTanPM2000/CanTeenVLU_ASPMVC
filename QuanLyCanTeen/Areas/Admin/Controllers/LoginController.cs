using System;
using QuanLyCanTeen.Models;
using System.Collections.Generic;
using QuanLyCanTeen.Areas.Admin.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyCanTeen.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        DBEntities db = new DBEntities();
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
                var result = Login(model.Email, model.PassWord);
                if (result == 0)
                {
                    var user = GetById(model.Email);
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
                    return RedirectToAction("Index", "SanPham");
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

        public int Login(string email, string passWord)
        {
            var result = db.ACCOUNTs.SingleOrDefault(x => x.EMAIL == email);
            if (result == null)
                return -1;
            else
            {
                if (result.PASSWORD == passWord)
                    return 0;
                else
                    return -2;
            }
        }

        public ACCOUNT GetById(string email)
        {
            return db.ACCOUNTs.SingleOrDefault(x => x.EMAIL == email);
        }
    }
}