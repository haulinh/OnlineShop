using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EntityFramework;
using Model.ViewModel;

namespace Model.Dao
{
    public class TagDao
    {
        OnlineShopDbContext db = null;
        public TagDao()
        {
            db = new OnlineShopDbContext();
        }
        public async Task<string> Insert(Tag entity)
        {
            db.Tags.Add(entity);
            await db.SaveChangesAsync();
            return entity.Id;
        }

        public List<Tag> ListAll()
        {
            return db.Tags.OrderBy(x=>x.Id).ToList();
        }

        
    }
}
