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
        public ActionResult Index()
        {
            var dao = new ProductDao();
            var listProduct = dao.GetListProduct();
            return View(listProduct);
        }


        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        public ActionResult Create(Product user)
        {
            var dao = new ProductDao();

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

            return View("Create");
        }


    }
}