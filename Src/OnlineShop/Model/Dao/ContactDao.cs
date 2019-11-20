using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EntityFramework;
using Model.ViewModel;
using PagedList;
namespace Model.Dao
{
    public class ContactDao
    {
        OnlineShopDbContext db = null;
        public ContactDao()
        {
            db = new OnlineShopDbContext();
        }
        public IEnumerable<Contact> ListAllPaging(int page, int pageSize)
        {
            IOrderedQueryable<Contact> contacts = db.Contacts;
            return contacts.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }

        public Contact ContactDetail(int ID)
        {
            return db.Contacts.Find(ID);
        }

        public int Insert(Contact entity)
        {
            db.Contacts.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(Contact entity)
        {
            try
            {
                var contact = db.Contacts.Find(entity.ID);
                contact.Content = entity.Content;
                contact.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
