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
    }
}
