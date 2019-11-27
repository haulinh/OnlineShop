using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EntityFramework;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        public ActionResult Index()
        {
            SetUserGroupViewBag();
            SetViewBag();
            SetStatusViewBag();
            var dao = new CategoriesDao();
            var listCategory = dao.ListAll();
            return View(listCategory);
        }

        [ValidateInput(false)]
        [HttpGet]
        public ActionResult Create()
        {
            SetViewBag();
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(Category tag)
        {
            SetViewBag();
            var dao = new CategoriesDao();
            var result = dao.ListAll();
            if (ModelState.IsValid)
            {

                long id = dao.Insert(tag);
                if (id > 0)
                {

                    // chuyển hướng trang về admin/User/index

                    return RedirectToAction("Index", "Category", result);
                }
                else
                {
                    ModelState.AddModelError("", "Thêm danh muc không thành công");
                }
            }
            return View("Create");

        }

        public void SetViewBag(int? selectedid = null)
        {
            var dao1 = new CategoriesDao();
            ViewBag.ParentID = new SelectList(dao1.ListAll(), "ID", "Name", selectedid);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var account = new CategoriesDao().CategoryDetail(id);
            SetViewBag();
            return View(account);
        }


        [HttpPost]
        public ActionResult Edit(Category tag)
        {
            SetViewBag();
            var dao = new CategoriesDao();
            var model = dao.ListAll();
            if (ModelState.IsValid)
            {

                var result = dao.Update(tag);

                if (result)
                {
                    return RedirectToAction("Index", "Category", model);
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View("Edit");
        }
        void SetStatusViewBag()
        {
            ViewBag.Status = new SelectList(new[]
             {
                     new { ID="true", Status="Đã kích hoạt" },
                     new { ID="false", Status="Khóa" },
             }, "ID", "Status", true);

        }
        void SetUserGroupViewBag()
        {
            var dao = new UserGroupDao();
            ViewBag.UserGroups = dao.GetUserGroups().ToList();
        }

    }
}