using Model.Dao;
using Model.EntityFramework;
using Model.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ProductCategoryController : Controller
    {
        // GET: Admin/ProductCategory
        [HttpGet]
        public ActionResult Index(string name="",long? parrentId=null,bool? status=null)
        {
            SetViewBagAllCategory();


            ViewBag.Name = name;

            var dao = new ProductCategoryDao();
            var listProductCategory = dao.ListAllForManager(name,parrentId,status);
            return View(listProductCategory);
        }



        [HttpGet]
        public ActionResult TreeMode(string parentName, string childName)
        {
            List<TreeViewNode> nodes = new List<TreeViewNode>();
            var dao = new ProductCategoryDao();
            var entities = dao.GetListProductCategory(parentName, childName);


            //Loop and add the Parent Nodes.
            foreach (ProductCategory type in entities)
            {
                if (type.ParentID == null)
                {
                    nodes.Add(new TreeViewNode { id = type.ID.ToString(), parent = "#", text = type.Name });
                }
            }

            //Loop and add the Child Nodes.
            foreach (ProductCategory subType in entities)
            {
                if (subType.ParentID != null)
                {
                    nodes.Add(new TreeViewNode { id = subType.ParentID.ToString() + "-" + subType.ID.ToString(), parent = subType.ParentID.ToString(), text = subType.Name });
                }

            }

            //Serialize to JSON string.
            ViewBag.Json = (new JavaScriptSerializer()).Serialize(nodes);
            return View();
        }
        void SetViewBagAllCategory()
        {
            var dao = new ProductCategoryDao();
            ViewBag.AllCategory = dao.ListParentCategorys();
            ViewBag.Status = new SelectList(new[]
           {
                                    new { ID="true", Status="Đã kích hoạt" },
                                    new { ID="false", Status="Khóa" },
                                }, "ID", "Status", true);



        }


        [HttpGet]
        public ActionResult Create()
        {
            ViewBagCategory();
            ProductCategory productCategory = new ProductCategory();
            productCategory.Status = false;
            productCategory.ShowOnHome = true;
            return View(productCategory);
        }

        public ActionResult Create(ProductCategory user)
        {
            var dao = new ProductCategoryDao();
            user.Status = true;
            ViewBagCategory();
            if (ModelState.IsValid)
            {

                long id = dao.Insert(user);
                if (id > 0)
                {

                    // chuyển hướng trang về admin/User/index
                    var result = dao.ListAll();
                    return RedirectToAction("Index", "ProductCategory", result);
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


        public ActionResult Edit(long id)
        {
            ViewBagCategory();
            var product = new ProductCategoryDao().ViewDetail(id);
            return View(product);
        }


        [HttpPost]
        public ActionResult Edit(ProductCategory product)
        {
            ViewBagCategory();
            var dao = new ProductCategoryDao();
          
            if (ModelState.IsValid)
            {

                var result = dao.Update(product);

                if (result)
                {
                    var model = dao.ListAll();
                    return RedirectToAction("Index", "Product", model);
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View("Edit");
        }




        void ViewBagCategory()
        {

            var dao = new ProductCategoryDao();
            SelectList a = new SelectList(dao.ListParentCategorys(), "ID", "Name", null);
            ViewBag.CategoryID = new SelectList(dao.ListParentCategorys(), "ID", "Name", null);

        }

    }
}