using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EntityFramework;
using Model.ViewModel;
namespace Model.Dao
{
    public class PostDao
    {
        OnlineShopDbContext db = null;
        public PostDao()
        {
            db = new OnlineShopDbContext();
        }

        public async Task<long> Insert(Content entity)
        {
            db.Contents.Add(entity);
            await db.SaveChangesAsync();
            return entity.ID;
        }

        public List<Content> ListAll()
        {
            return db.Contents.OrderBy(x => x.ID).ToList();
        }
    }
}
