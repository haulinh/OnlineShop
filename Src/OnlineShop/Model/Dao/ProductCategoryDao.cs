using Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
   public class ProductCategoryDao
    {
        OnlineShopDbContext db = null;
        public ProductCategoryDao()
        {
            db = new OnlineShopDbContext();
        }



        public List<ProductCategory> GetListProductCategory(string parent=null,string child=null)
        {
            var listCate = db.ProductCategories.ToList();
            var temp = listCate;
            if (!string.IsNullOrEmpty(parent))
            {
                var parrentEntity = listCate.FirstOrDefault(x => x.Name.Contains(parent));
                if (parrentEntity != null)
                {
                 
                    listCate = listCate.Where(x=>x.ParentID == parrentEntity.ID).ToList();
                    listCate.Add(parrentEntity);
                }
               

            }

            //dump code
            if (!string.IsNullOrEmpty(child))
            {
               
                listCate = listCate.Where(x =>x.ParentID!=null && x.Name.Contains(child)).ToList();
              
                foreach (var item in listCate)
                {
                    var parrentEntities = temp.FirstOrDefault(x => x.ID ==item.ParentID);

                    if (parrentEntities!=null)
                    {
                        listCate.Add(parrentEntities);
                        break;
                    }  
                }
             
               

            }

                return listCate.ToList();
        }

        public ProductCategory ViewDetail(long id)
        {
            return db.ProductCategories.Find(id);
        }

        public long Insert(ProductCategory entity)
        {
            entity.CreatedDate = DateTime.Now;
            db.ProductCategories.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }


        public List<ProductCategory> ListAll()
        {

            return db.ProductCategories.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }


        public List<ProductCategory> ListAllForManager(string name = "", long? parrentId = null, bool? status = null)
        {
            var cate = db.ProductCategories.ToList();

            if (!String.IsNullOrEmpty(name))
            {
                cate = cate.Where(x => x.Name.Contains(name)).ToList();
            }

            if (parrentId!=null)
            {
                cate = cate.Where(x => x.ParentID==parrentId).ToList();
            }

            if (status != null)
            {
                cate = cate.Where(x => x.Status == status).ToList();
            }




            return cate.ToList();
        }





        public List<ProductCategory> ListParentCategorys()
        {
            return db.ProductCategories.Where(x => x.Status == true && x.ParentID == null).OrderBy(x => x.CreatedDate).ToList();
        }


        public List<ProductCategory> ListChildCaterogys()
        {
            return db.ProductCategories.Where(x => x.Status == true && x.ParentID!=null).OrderBy(x => x.CreatedDate).ToList();
        }


        public ProductCategory Detail(long id)
        {
            return db.ProductCategories.Find(id);

        }

    }
}
