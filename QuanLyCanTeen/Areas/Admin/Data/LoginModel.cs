using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyCanTeen.Areas.Admin.Data
{
    public class LoginModel
    {
        // GET: Admin/LoginModel
        [Required(ErrorMessage = "Mời nhập Email")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Mời nhập PassWord")]
        public string PassWord { set; get; }
        public bool RememberMe { set; get; }
    }
}