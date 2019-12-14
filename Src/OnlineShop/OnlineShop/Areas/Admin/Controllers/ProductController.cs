using Model.Dao;
using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index(int? CategoryID)
        {
            SetViewBagAllCategory();
            var dao = new ProductDao();
            var listProduct = dao.GetListProduct();
            return View(listProduct);
        }


        [HttpGet]
        public ActionResult Create()
        {
            ViewBagCategory();
            return View();
        }

        public ActionResult Create(Product user)
        {
            var dao = new ProductDao();
            user.Status = true;
            ViewBagCategory();
            if (ModelState.IsValid)
            {
 
                    long id = dao.Insert(user);
                    if (id > 0)
                    {

                        // chuyển hướng trang về admin/User/index
                        var result = dao.GetListProduct();
                        return RedirectToAction("Index", "Product", result);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm không thành công");
                    }



            }
            else
            {
                ModelState.AddModelError("", "Form lỗi");
            }

            return View("Create");
        }

        void ViewBagCategory()
        {
            
            var dao= new ProductCategoryDao();
            SelectList a= new SelectList(dao.ListChildCaterogys(), "ID", "Name", null);
            ViewBag.CategoryID = new SelectList(dao.ListChildCaterogys(), "ID", "Name",null);
       
        }

        void SetViewBagAllCategory()
        {
            var dao = new ProductCategoryDao();
            ViewBag.AllCategory = dao.ListAll();
            ViewBag.Status = new SelectList(new[]
           {
                                    new { ID="true", Status="Đã kích hoạt" },
                                    new { ID="false", Status="Khóa" },
                                }, "ID", "Status", true);



        }

    }
}