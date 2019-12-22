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


        void SetStatusViewBag()
        {
            ViewBag.Status = new SelectList(new[]
    {
                                    new { ID="1", Status="Chờ duyệt" },
                                    new { ID="2", Status="Đã duyệt" },
                                    new { ID="3", Status="Vận chuyển " },
                                    new { ID="4", Status="Thành công" },
                                    new { ID="5", Status="Hủy đơn" },
                                }, "ID", "Status", true);

        }


    }
}