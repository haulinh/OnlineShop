using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoConfig;
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
        public IEnumerable<UserViewModel> GetListUsers(string userName = null, string name = null, string sdt = null, string email = null, bool? status = null, string userGroup = null)
        {

            List<User> users = db.Users.ToList();
            List<UserGroup> groups = db.UserGroups.ToList();
            var userViewModel = from u in users
                                join g in groups
                                on u.GroupID equals g.ID into sr
                                from x in sr.DefaultIfEmpty()
                                select new UserViewModel
                                {
                                    user = u,
                                    userGroup = x,
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
                userViewModel = userViewModel.Where(x => x.user.Email != null && x.user.Email.Contains(email)).OrderByDescending(x => x.user.CreatedDate);
            }

            if (status != null)
            {
                userViewModel = userViewModel.Where(x => x.user.Status == status).OrderByDescending(x => x.user.CreatedDate);
            }

            if (!string.IsNullOrEmpty(userGroup))
            {
                userViewModel = userViewModel.Where(x => x.userGroup != null && x.userGroup.ID.Contains(userGroup)).OrderByDescending(x => x.user.CreatedDate);
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
        public int Login(string userName, string passWord, bool isAdminLogin = false)
        {
            // careful for sql injection with this code below
            var result = db.Users.FirstOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isAdminLogin == true)
                {
                    if (result.GroupID == Define.ADMIN_GROUP
                        || result.GroupID == Define.MOD_GROUP)
                    {
                        if (result.Status == false)
                        {
                            return -1;
                        }
                        else
                        {
                            if (result.Password == passWord)
                            {
                                return 1;

                            }
                            else
                            {
                                return -2;
                            }
                        }
                    }
                    else
                    {
                        return -3;
                    }
                }
                else
                {

                    if (result.Password == passWord)
                    {
                        return 1;

                    }
                    else
                    {
                        return -2;
                    }
                }
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

        public List<string> GetListCredential(string userName)
        {
            var user = db.Users.Single(x => x.UserName == userName);
            var data = (from a in db.Credentials
                       join b in db.UserGroups on a.UserGroupID equals b.ID
                       join c in db.Roles on a.RoleID equals c.ID
                       where b.ID == user.GroupID
                       select new
                       {
                           RoleID = a.RoleID,
                           UserGroupID = a.UserGroupID
                       }).AsEnumerable().Select(x=>new Credential()
                       {
                           RoleID = x.RoleID,
                           UserGroupID = x.UserGroupID
                       });
            return data.Select(x=>x.RoleID).ToList();
        }

    }
}
