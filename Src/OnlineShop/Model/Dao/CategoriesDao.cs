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

        public int Insert(Category entity)
        {
            db.Categories.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }

        public List<Category> ListAll()
        {
            return db.Categories.OrderBy(x => x.Id).ToList();
        }
        public Category CategoryDetail(int ID)
        {
            return db.Categories.Find(ID);
        }

        public bool Update(Category entity)
        {
            try
            {
                var account = db.Categories.Find(entity.Id);
                account.Name = entity.Name;
                account.ParentId = entity.ParentId;
                account.ShowInHome = entity.ShowInHome;
                account.ShowInMenu = entity.ShowInMenu;
                account.SortOrder = entity.SortOrder;
                account.Thumbnail = entity.Thumbnail;
                account.SiteTitle = entity.SiteTitle;
                account.SeoAlias = entity.SeoAlias;
                account.MetaKeywords = entity.MetaKeywords;
                account.MetaDescription = entity.MetaDescription;
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
