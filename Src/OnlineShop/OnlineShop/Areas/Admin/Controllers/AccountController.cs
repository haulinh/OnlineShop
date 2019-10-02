using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model.Dao;
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
    }
}