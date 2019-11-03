using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class TagController : Controller
    {
        // GET: Admin/Tag
        public ActionResult Index()
        {
            var dao = new TagDao();
            var listTag = dao.ListAll();
            return View(listTag);
        }
    }
}