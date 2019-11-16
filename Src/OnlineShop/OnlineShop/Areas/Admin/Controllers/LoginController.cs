using Model.Dao;
using OnlineShop.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShop.Common;
namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, model.PassWord);
                if (result)
                {
                    var user = dao.GetByName(model.UserName);
                    var userSesstion = new UserLogin();
                    userSesstion.UserName = user.UserName;
                    userSesstion.UserID = user.ID;
                    Session.Add(CommonConstants.USER_SESSTION, userSesstion);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng");
                }
            }
            return View("Index");

        }
    }
}