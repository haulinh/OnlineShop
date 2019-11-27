using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EntityFramework;
using Model.ViewModel;

namespace Model.Dao
{
    public class CategoriesDao
    {
        OnlineShopDbContext db = null;
        public CategoriesDao()
        {
            db = new OnlineShopDbContext();
        }

        public long Insert(Category entity)
        {
            entity.CreatedDate = DateTime.Now;
            db.Categories.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public List<Category> ListAll()
        {
            return db.Categories.OrderBy(x => x.ID).ToList();
        }
        public Category CategoryDetail(int ID)
        {
            return db.Categories.Find(ID);
        }

        public bool Update(Category entity)
        {
            try
            {
                var account = db.Categories.Find(entity.ID);
                account.Name = entity.Name;
                account.Language = entity.Language;
                account.ShowOnHome = entity.ShowOnHome;
                account.ParentID = entity.ParentID;
                account.Status = entity.Status;
                account.SeoTitle = entity.SeoTitle;
                account.MetaKeywords = entity.MetaKeywords;
                account.MetaDescriptions = entity.MetaDescriptions;
                account.MetaTitle = entity.MetaTitle;
                account.DisplayOrder = entity.DisplayOrder;
                account.ModifiedDate = DateTime.Now;
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
