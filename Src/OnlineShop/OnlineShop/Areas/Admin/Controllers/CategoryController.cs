using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            var dao = new CategoriesDao();
            var listTag = dao.ListAll();
            return View(listTag);
        }
    }
}