using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class UserRoleByGroupModel
    {
        public UserGroup userGroup { set; get; }
        public Role role { set; get; }

    }
}
