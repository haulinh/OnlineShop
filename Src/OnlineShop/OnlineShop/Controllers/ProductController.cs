using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class ProductController : Controller
    {
        // GET: Produce
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Detail(long id)
        {
            var product = new ProductDao().ViewDetail(id);
            ViewBag.Category = new ProductCategoryDao().ViewDetail(product.CategoryID);
            return View(product);
        }
            
        public ActionResult Category(long cateId, int page = 1, int pageSize = 15, int orderby=-1)
        {
            var category = new ProductCategoryDao().Detail(cateId);
            ViewBag.Category = category;

            ViewBag.Option = orderby;



            int totalRecord = 0;
            var model = new ProductDao().ListByCategoryId(cateId, ref totalRecord, page, pageSize, orderby);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            int a = totalRecord % pageSize;
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            if (a!=0)
            {
                totalPage++;
            }
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            ViewBag.PageSize = pageSize;
            return View(model);
        }


        public JsonResult ListName(string q)
        {
            var data = new ProductDao().ListName(q);
            return Json(new
            {
                data = data,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Search(string keyWord="", int page = 1, int pageSize = 15, int orderby = -1)
        {



         
            ViewBag.Option = orderby;
            ViewBag.KeyWord = keyWord;
            var category = new ProductCategoryDao().Detail(1);
            ViewBag.Category = category;



            int totalRecord = 0;
            var model = new ProductDao().Search(keyWord, ref totalRecord, page, pageSize, orderby);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;

            int a = totalRecord % pageSize;
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            if (a != 0)
            {
                totalPage++;
            }
            ViewBag.TotalPage = totalPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            ViewBag.PageSize = pageSize;
            return View(model);
        }

    }
}