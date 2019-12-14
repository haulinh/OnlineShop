using Model.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Admin/Invoice
        public ActionResult Index()
        {
            var model = new OrderDao().GetListInvoice();
            return View(model);
        }

        public ActionResult Detail(long ID)
        {
            var model = new OrderDao().ViewDetail(ID);
          
            return View(model);
        }
    }
}