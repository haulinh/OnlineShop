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
                var result = dao.Login(model.UserName, model.PassWord, true);
                if (result == 1)
                {
                    var user = dao.GetByName(model.UserName);
                    var userSesstion = new UserLogin();
                   
                    var listCredential = dao.GetListCredential(model.UserName);

                    userSesstion.UserName = user.UserName;
                    userSesstion.UserID = user.ID;
                    userSesstion.GroupID = user.GroupID;

                    Session.Add(CommonConstants.USER_CREDENTIAL, listCredential);
                    Session.Add(CommonConstants.USER_SESSTION, userSesstion);
                    return RedirectToAction("Index", "Home");
                }
                else if (result==0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại");
                }
                else if(result==-1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else if (result == -3)
                {
                    ModelState.AddModelError("", "Tài khoản của bạn không có quyền đăng nhập");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập lỗi");
                }
            }
            return View("Index");

        }
    }
}