using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EntityFramework;
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

        public async Task<List<User>> GetListUsers()
        {
            var myTask = Task.Run(() => db.Users.ToList());
            List<User> user = await myTask;
            return user;
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
