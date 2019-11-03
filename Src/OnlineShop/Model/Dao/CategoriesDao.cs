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

        public async Task<int> Insert(Category entity)
        {
            db.Categories.Add(entity);
            await db.SaveChangesAsync();
            return entity.Id;
        }

        public List<Category> ListAll()
        {
            return db.Categories.OrderBy(x => x.Id).ToList();
        }


    }
}
