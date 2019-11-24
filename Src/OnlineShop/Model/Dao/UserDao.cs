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
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.Phone = entity.Phone;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }
        public IEnumerable<UserViewModel> GetListUsers(string userName = null, string name = null, string sdt = null, string email = null, bool? status = null)
        {

            List<User> users = db.Users.ToList();
            List<Role> roles = db.Roles.ToList();
            var userViewModel = from u in users
                                select new UserViewModel
                                {
                                    user = u,
                                    userRole = null,
                                };
            if (!string.IsNullOrEmpty(userName))
            {
                userViewModel = userViewModel.Where(x => x.user.UserName.Contains(userName)).OrderByDescending(x => x.user.CreatedDate);
            }
            if (!string.IsNullOrEmpty(name))
            {
                userViewModel = userViewModel.Where(x => x.user.Name.Contains(name)).OrderByDescending(x => x.user.CreatedDate);
            }

            if (!string.IsNullOrEmpty(sdt))
            {
                userViewModel = userViewModel.Where(x => x.user.Phone.Contains(sdt)).OrderByDescending(x => x.user.CreatedDate);
            }

            if (!string.IsNullOrEmpty(email))
            {
                userViewModel = userViewModel.Where(x => x.user.Email.Contains(email)).OrderByDescending(x => x.user.CreatedDate);
            }

            if (status!=null)
            {
                userViewModel = userViewModel.Where(x => x.user.Status==status).OrderByDescending(x => x.user.CreatedDate);
            }


            return userViewModel;
        }

        public User ViewDetail(long id)
        {
            return db.Users.Find(id);
        }


        public User GetByName(string userName)
        {
            // return db.Users.FirstOrDefault(x => x.UserName == userName);
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        public bool Login(string userName, string passWord)
        {
            // careful for sql injection with this code below
            var result = db.Users.Count(x => x.UserName == userName
             && x.Password == passWord);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool ChangeStatus(long id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool CheckUserName(string userName)
        {
            return db.Users.Count(x => x.UserName == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }
    }
}
