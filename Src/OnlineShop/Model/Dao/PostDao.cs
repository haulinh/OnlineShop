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

        public async Task<int> Insert(Post entity)
        {
            db.Posts.Add(entity);
            await db.SaveChangesAsync();
            return entity.Id;
        }

        public List<Post> ListAll()
        {
            return db.Posts.OrderBy(x => x.Id).ToList();
        }
    }
}
