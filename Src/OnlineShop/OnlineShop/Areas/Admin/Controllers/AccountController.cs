using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
using Model.EntityFramework;
using System.Threading.Tasks;
using OnlineShop.Common;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {

        // GET: Admin/Account
        [HaveCredential(RoleID ="VIEW_USER")]
        public ActionResult Index(string userName, string name, string sdt, string email,string userGroup, bool? status)
        {
            SetUserGroupViewBag();
            SetStatusViewBag();
            var dao = new UserDao();

            ViewBag.UserName = userName;
            ViewBag.Name = name;
            ViewBag.SDT = sdt;
            ViewBag.Emai = email;

            var listUser = dao.GetListUsers(userName, name, sdt, email, status, userGroup);
            return View(listUser);
        }

        [HaveCredential(RoleID = "EDIT_USER")]
        void SetStatusViewBag()
        {
                            ViewBag.Status = new SelectList(new[]
                    {
                                    new { ID="true", Status="Đã kích hoạt" },
                                    new { ID="false", Status="Khóa" },
                                }, "ID", "Status", true);

        }
        [HaveCredential(RoleID = "EDIT_USER")]
        void SetUserGroupViewBag()
        {
            var dao = new UserGroupDao();
            ViewBag.UserGroups = dao.GetUserGroups().ToList();
        }



        [HttpGet]
        [HaveCredential(RoleID = "DEL_USER")]
        public ActionResult Delete(int id)
        {
            new UserDao().Delete(id);
            return RedirectToAction("index");
        }


        [HttpGet]
        [HaveCredential(RoleID = "ADD_USER")]
        public ActionResult Create()
        {

            return View();
        }

        [HttpGet]
        [HaveCredential(RoleID = "VIEW_USER")]
        public ActionResult ViewDetail(long id)
        {

            var account = new UserDao().ViewDetail(id);
            return View(account);
        }

        [HttpPost]
        [HaveCredential(RoleID = "ADD_USER")]
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
                        ModelState.AddModelError("", "Thêm User không thành công");
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
        [HaveCredential(RoleID = "EDIT_USER")]
        public ActionResult Edit(long id)
        {
            var account = new UserDao().ViewDetail(id);
            return View(account);
        }


        [HttpPost]
        [HaveCredential(RoleID = "EDIT_USER")]
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
        [HaveCredential(RoleID = "ACTIVE_USER")]
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