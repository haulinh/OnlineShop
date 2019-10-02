using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class UserViewModel
    {
        public User user { set; get; }
        public Role userRole { set; get; }
    }
}
