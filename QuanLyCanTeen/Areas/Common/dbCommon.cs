using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QuanLyCanTeen.Models;
using PagedList;

namespace QuanLyCanTeen.Areas.Common
{
    public class dbCommon
    {
        readonly DBEntities db;

        public dbCommon()
        {
            db = new DBEntities();
        }



        #region (Login) login with email and password
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
        #endregion


        #region (GetById) get specified person with email
        public ACCOUNT GetById(string email)
        {
            return db.ACCOUNTs.SingleOrDefault(x => x.EMAIL == email);
        }
        #endregion


        #region (ListFoods) get list of Foods
        public IEnumerable<FOOD> ListFoods(string searchString, int page, int pageSize)
        {
            IQueryable<FOOD> model = db.FOODs.OrderByDescending(x => x.ID);
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.FOOD_NAME.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToList().ToPagedList(page, pageSize);
        }
        #endregion


        #region (ListFoods) get list of Categorys
        public IEnumerable<CATEGORY> ListCategorys(string searchString, int page, int pageSize)
        {
            IQueryable<CATEGORY> model = db.CATEGORies.OrderByDescending(x => x.ID);
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.CATEGORY_NAME.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToList().ToPagedList(page, pageSize);
        }
        #endregion


        #region (ListFoods) get list of Accounts
        public IEnumerable<ACCOUNT> ListAccounts(string searchString, int page, int pageSize)
        {
            IQueryable<ACCOUNT> model = db.ACCOUNTs.OrderByDescending(x => x.ID);
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.FULL_NAME.Contains(searchString));
            }
            return model.OrderByDescending(x => x.ID).ToList().ToPagedList(page, pageSize);
        }
        #endregion

    }
}