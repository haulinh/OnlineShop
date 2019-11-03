using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        // GET: Admin/Post
        public ActionResult Index()
        {
            var dao = new PostDao();
            var listTag = dao.ListAll();
            return View(listTag);
        }
    }
}