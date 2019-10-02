using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EntityFramework;
using Model.ViewModel;

namespace Model.Dao
{
   public class UserDao
    {
        OnlineShopDbContext db = null;
        public UserDao()
        {
            db = new OnlineShopDbContext();
        }
        public async Task<long> Insert(User entity)
        {
            db.Users.Add(entity);
            await db.SaveChangesAsync();
            return entity.Id;
        }

        public IEnumerable<UserViewModel> GetListUsers()
        {

            List<User> users = db.Users.ToList();
            List<Role> roles = db.Roles.ToList();
            List<UserRole> userRoles = db.UserRoles.ToList();
            var userViewModel = from u in users
                                join ur in userRoles
                                on u.Id equals ur.UserId
                                join r in roles
                                on ur.UserRoleID equals r.Id
                                select new UserViewModel
                                {
                                    user = u,
                                    userRole = r,
                                };

            return userViewModel;
        }


        public User GetByName(string userName)
        {
           // return db.Users.FirstOrDefault(x => x.UserName == userName);
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        public bool Login(string userName,string passWord)
        {
            // careful for sql injection with this code below
            var result = db.Users.Count(x => x.UserName == userName
             && x.Password == passWord);
            if (result>0)
            {
                return true;
            }
            else
            {
                return false;   
            }
        }
    }
}
