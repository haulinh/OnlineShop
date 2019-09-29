using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Models
{
    public class LoginModel
    {

        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Vui lòng nhập mật khẩu đăng nhập")]
        public string PassWord { set; get; }

        public bool RemerberMe { set; get; }
    }
}