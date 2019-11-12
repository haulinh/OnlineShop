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
    public class TagDao
    {
        OnlineShopDbContext db = null;
        public TagDao()
        {
            db = new OnlineShopDbContext();
        }
        public string Insert(Tag entity)
        {
            db.Tags.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public IEnumerable<Tag> ListAllPaging(int page, int pageSize)
        {
            IOrderedQueryable<Tag> tags = db.Tags;
            return tags.OrderByDescending(x => x.Id).ToPagedList(page, pageSize);
        }

        public Tag TagDetail(string ID)
        {
            return db.Tags.Find(ID);
        }

        public bool Update(Tag entity)
        {
            try
            {
                var account = db.Tags.Find(entity.Id);
                account.Name = entity.Name;
             
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
