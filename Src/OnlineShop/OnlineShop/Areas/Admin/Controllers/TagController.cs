using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EntityFramework;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class TagController : Controller
    {
        // GET: Admin/Tag
        public ActionResult Index()
        {
            var dao = new TagDao();
            var listTag = dao.ListAllPaging(1,10);
            return View(listTag);
        }

        [ValidateInput(false)]
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Tag tag)
        {
            var dao = new TagDao();
            var result = dao.ListAllPaging(1, 10);
            if (ModelState.IsValid)
            {

                string id = dao.Insert(tag);
                if (int.Parse(id) > 0)
                {

                    // chuyển hướng trang về admin/User/index
                    
                    return RedirectToAction("Index", "Tag", result);
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Tag không thành công");
                }
            }
            return View("Create");

        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            var account = new TagDao().TagDetail(id);
            return View(account);
        }


        [HttpPost]
        public ActionResult Edit(Tag tag)
        {
            var dao = new TagDao();
            var model = dao.ListAllPaging(1, 10);
            if (ModelState.IsValid)
            {

                var result = dao.Update(tag);

                if (result)
                {
                    return RedirectToAction("Index", "Tag", model);
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View("Edit");
        }

    }
}