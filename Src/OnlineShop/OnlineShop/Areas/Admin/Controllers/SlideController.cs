using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class SlideController : Controller
    {
        // GET: Admin/Slide
        public ActionResult Index()
        {
            var dao = new SlideDao().ListAll();
            return View(dao);
        }
    }
}