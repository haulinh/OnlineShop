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
        public ActionResult Index()
        {
            var dao= new UserDao();
            var listUser = dao.GetListUsers();
            return View(listUser);
        }




        [HttpGet]
        public ActionResult Create()
        {
  
            return View();
        }


 
        [HttpPost]
        public ActionResult Create(User user)
        {
            var dao = new UserDao();
            var result = dao.GetListUsers();
            if (ModelState.IsValid)
            {

                long id = dao.Insert(user);
                if (id > 0)
                {

                    // chuyển hướng trang về admin/User/index
                 
                    return RedirectToAction("Index", "Account", result);
                }
                else
                {
                    ModelState.AddModelError("", "Thêm Tag không thành công");
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




    }
}