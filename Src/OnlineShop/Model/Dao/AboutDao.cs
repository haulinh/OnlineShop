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
    public class AboutDao
    {
        OnlineShopDbContext db = null;
        public AboutDao()
        {
            db = new OnlineShopDbContext();
        }
        public IEnumerable<About> ListAllPaging(int page, int pageSize)
        {
            IOrderedQueryable<About> Abouts = db.Abouts;
            return Abouts.OrderByDescending(x => x.ID).ToPagedList(page, pageSize);
        }

        public About AboutDetail(int ID)
        {
            return db.Abouts.Find(ID);
        }

        public long Insert(About entity)
        {
            entity.CreatedDate = DateTime.Now;
            //entity.CreatedBy = nguoi dang nhap hien tai ; 
            db.Abouts.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(About entity)
        {
            try
            {
                var About = db.Abouts.Find(entity.ID);
                About.Name = entity.Name;
                About.MetaTitle = entity.MetaTitle;
                About.Description = entity.Description;
                About.Image = entity.Image;
                About.Detail = entity.Detail;
                About.ModifiedDate = DateTime.Now;
                //About.ModifiedBy = nguoidangnhaphientai
                About.MetaDescriptions = entity.MetaDescriptions;
                About.MetaKeywords = entity.MetaKeywords;
                About.Status = entity.Status;
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
