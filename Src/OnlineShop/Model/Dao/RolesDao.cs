using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{

    public class RolesDao
    {
        OnlineShopDbContext db = null;
        public RolesDao()
        {
            db = new OnlineShopDbContext();
        }

        public async Task<List<Role>> GetListRoles()
        {
            var myTask = Task.Run(() => db.Roles.ToList());
            List<Role> roles = await myTask;
            return roles;
        }


    }
}
