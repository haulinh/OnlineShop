using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EntityFramework;
using System.Threading.Tasks;
namespace OnlineShop.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {

        // GET: Admin/Account
        public ActionResult Index(string userName, string name, string sdt, string email, bool? status)
        {

            SetStatusViewBag();
            var dao = new UserDao();
            var listUser = dao.GetListUsers(userName, name, sdt, email, status);
            return View(listUser);
        }


        void SetStatusViewBag()
        {
                            ViewBag.Status = new SelectList(new[]
                    {
                                    new { ID="true", Status="Đã kích hoạt" },
                                    new { ID="false", Status="Khóa" },
                                }, "ID", "Status", true);

        }






        [HttpGet]
        public ActionResult Create()
        {

            return View();
        }

        [HttpGet]
        public ActionResult ViewDetail(long id)
        {

            var account = new UserDao().ViewDetail(id);
            return View(account);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            SetStatusViewBag();
            var dao = new UserDao();

            if (ModelState.IsValid)
            {
                if (!dao.CheckUserName(user.UserName))
                {
                    long id = dao.Insert(user);
                    if (id > 0)
                    {

                        // chuyển hướng trang về admin/User/index
                        var result = dao.GetListUsers();
                        return RedirectToAction("Index", "Account", result);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm Tag không thành công");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản bị trùng");
                }

            }

            return View("Create");
        }



        [HttpGet]
        public ActionResult Edit(long id)
        {
            var account = new UserDao().ViewDetail(id);
            return View(account);
        }


        [HttpPost]
        public ActionResult Edit(User user)
        {
            SetStatusViewBag();
            var dao = new UserDao();
            var model = dao.GetListUsers();
            if (ModelState.IsValid)
            {

                var result = dao.Update(user);

                if (result)
                {
                    return RedirectToAction("Index", "Account", model);
                }
                else
                {
                    ModelState.AddModelError("", "Cập nhật không thành công");
                }
            }
            return View("Edit");
        }



        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            var result = new UserDao().ChangeStatus(id);
            return Json(new
            {
                status = result
            });
        }


    }
}