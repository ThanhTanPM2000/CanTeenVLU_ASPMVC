using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyCanTeen.Areas.Admin.Data
{
    public class UserLogin
    {
        public int ID { set; get; }

        public string EMAIL { set; get; }
        public string FULL_NAME { set; get; }
        public string PASSWORD { set; get; }
        public bool STATUS { set; get; }
        public int ROLE { set; get; }
    }
}