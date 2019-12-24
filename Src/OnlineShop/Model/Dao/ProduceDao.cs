using Model.EntityFramework;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Model.Dao
{
    public class ProductDao
    {
        OnlineShopDbContext db = null;
        public ProductDao()
        {
            db = new OnlineShopDbContext();
        }

        public List<ProductViewModel> ListByCategoryId(long categoryID, ref int totalRecord, int pageIndex = 1, int pageSize = 2, int oderBy=-1)
        {
         
            List<Product> products = db.Products.ToList();
            List<ProductCategory> groups = db.ProductCategories.ToList();
            var cate = db.ProductCategories.FirstOrDefault(x=>x.ID==categoryID);
                if (cate.ParentID!=null)
            {
                groups = groups.Where(x => x.ID == categoryID).ToList();
            }
            else
            {
                groups = groups.Where(x => x.ParentID == categoryID).ToList();
            }

           
            var model = from u in products
                                join g in groups
                                on u.CategoryID equals g.ID
                                select new ProductViewModel
                                {
                                    product = u,
                                    category = g,
                                };

            totalRecord =model.Count();
            model= model.OrderByDescending(x => x.product.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            if (oderBy==1)
            {
                decimal? value = 0;
                model = model.OrderByDescending(x => value=x.product.PromotionPrice!=0? x.product.PromotionPrice: x.product.Price).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            if (oderBy == 2)
            {
                decimal? value = 0;
                model = model.OrderBy(x => value = x.product.PromotionPrice != 0 ? x.product.PromotionPrice : x.product.Price).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            return model.ToList();
        }


        public List<ProductViewModel> Search(string keyWord, ref int totalRecord, int pageIndex = 1, int pageSize = 2, int oderBy = -1)
        {

            List<Product> products = db.Products.Where(x=>x.Name.Contains(keyWord)).ToList();
            List<ProductCategory> groups = db.ProductCategories.ToList();
     
            var model = from u in products
                        join g in groups
                        on u.CategoryID equals g.ID
                        select new ProductViewModel
                        {
                            product = u,
                            category = g,
                        };

            totalRecord = model.Count();
            model = model.OrderByDescending(x => x.product.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            if (oderBy == 1)
            {
                decimal? value = 0;
                model = model.OrderByDescending(x => value = x.product.PromotionPrice != 0 ? x.product.PromotionPrice : x.product.Price).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            if (oderBy == 2)
            {
                decimal? value = 0;
                model = model.OrderBy(x => value = x.product.PromotionPrice != 0 ? x.product.PromotionPrice : x.product.Price).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            }
            return model.ToList();
        }

        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }


        public List<ProductViewModel> ListHotProduct(int top)
        {
            List<Product> products = db.Products.ToList();
            List<ProductCategory> groups = db.ProductCategories.ToList();
            var model = from u in products
                        join g in groups
                        on u.CategoryID equals g.ID
                        select new ProductViewModel
                        {
                            product = u,
                            category = g,
                        };
            return model.Where(x=>x.product.Status==true && x.product.IsHot==true).OrderByDescending(x => x.product.CreatedDate).Take(top).ToList();
        }

        public List<ProductViewModel> ListBestSellingProduct(int top)
        {
            List<Product> products = db.Products.ToList();
            List<OrderDetail> od = db.OrderDetails.ToList();



          
            var productss = od.GroupBy(p => p.ProductID).OrderByDescending(pi => pi.Sum(pii => pii.Quantity)).Select(p => p.Key).ToList();
            List<ProductCategory> groups = db.ProductCategories.ToList();
            var model = from  p in productss
                         join u in products
                        on p equals u.ID
                        join g in groups
                        on u.CategoryID equals g.ID
                       
                        select new ProductViewModel
                        {
                            product = u,
                            category = g,
                        };
            return model.ToList();




        }



        public List<ProductViewModel> ListPromotionProduct(int top)
        {
            List<Product> products = db.Products.Where(x => x.PromotionPrice != 0 && x.Status == true).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
            List<ProductCategory> groups = db.ProductCategories.ToList();
            var productViewModel = from u in products
                                join g in groups
                                on u.CategoryID equals g.ID
                                select new ProductViewModel
                                {
                                    product = u,
                                    category = g,
                                };

            return productViewModel.OrderBy(x => x.product.CreatedDate).ToList();

        }
        public List<string> ListName(string keyword)
        {
            return db.Products.Where(x => x.Name.Contains(keyword)).Select(x => x.Name).ToList();
        }


        public int CountProduct()
        {
            return db.Products.Count();
        }

        public List<ProductViewModel> GetListProduct(string name = "", long? masp = null, bool? status = null, int? CategoryID = null,int? minQ=null,int? maxQ=null)
        {

            List<Product> products = db.Products.ToList();
            List<ProductCategory> groups = db.ProductCategories.ToList();
            var productViewModel = from u in products
                                join g in groups
                                on u.CategoryID equals g.ID 
                                select new ProductViewModel
                                {
                                    product = u,
                                    category = g,
                                };

            if (!String.IsNullOrEmpty(name))
            {
                productViewModel=productViewModel.Where(x => x.product.Name.Contains(name));
            }

            if (masp!=null)
            {
                productViewModel = productViewModel.Where(x => x.product.ID==masp);
            }



            if (status != null)
            {
                productViewModel = productViewModel.Where(x => x.product.Status == status);
            }

            
            if (CategoryID != null)
            {
                var cateDao = new ProductCategoryDao();
                var cate = cateDao.ViewDetail(CategoryID.Value);
                if(cate.ParentID!=null)
                {
                    productViewModel = productViewModel.Where(x => x.category.ID == CategoryID);
                }
                else
                {

                    productViewModel = productViewModel.Where(x => x.category.ParentID == CategoryID);
           

                }


              
            }

            if (minQ!=null && maxQ!=null)
            {
                productViewModel = productViewModel.Where(x => x.product.Quantity >=minQ && x.product.Quantity<=maxQ);
            }




            return productViewModel.OrderBy(x => x.product.CreatedDate).ToList();

        }

        /// <summary>
        /// Get list product by category
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        //public List<ProductViewModel> ListByCategoryId(long categoryID)
        //{
        //    //totalRecord = db.Products.Where(x => x.CategoryID == categoryID).Count();
         
            
        //    return model.ToList();
        //}
        //public List<ProductViewModel> Search(string keyword, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        //{
        //    //totalRecord = db.Products.Where(x => x.Name == keyword).Count();
        //    //var model = (from a in db.Products
        //    //             join b in db.ProductCategories
        //    //             on a.CategoryID equals b.ID
        //    //             where a.Name.Contains(keyword)
        //    //             select new
        //    //             {
        //    //                 CateMetaTitle = b.MetaTitle,
        //    //                 CateName = b.Name,
        //    //                 CreatedDate = a.CreatedDate,
        //    //                 ID = a.ID,
        //    //                 Images = a.Image,
        //    //                 Name = a.Name,
        //    //                 MetaTitle = a.MetaTitle,
        //    //                 Price = a.Price
        //    //             }).AsEnumerable().Select(x => new ProductViewModel()
        //    //             {
        //    //                 CateMetaTitle = x.MetaTitle,
        //    //                 CateName = x.Name,
        //    //                 CreatedDate = x.CreatedDate,
        //    //                 ID = x.ID,
        //    //                 Images = x.Images,
        //    //                 Name = x.Name,
        //    //                 MetaTitle = x.MetaTitle,
        //    //                 Price = x.Price
        //    //             });
        //    //model.OrderByDescending(x => x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize);
        //    //return model.ToList();
        //}
        /// <summary>
        /// List feature product
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<Product> ListFeatureProduct(int top)
        {
            return db.Products.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public List<Product> ListRelatedProducts(long productId)
        {
            var product = db.Products.Find(productId);
            return db.Products.Where(x => x.ID != productId && x.CategoryID == product.CategoryID).ToList();
        }
        public Product ViewDetail(long id)
        {
            return db.Products.Find(id);
        }


        public long Insert(Product entity)
        {
            entity.CreatedDate = DateTime.Now;
            db.Products.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }

        public bool Update(Product entity)
        {
            try
            {
                var product = db.Products.Find(entity.ID);
                if (!string.IsNullOrEmpty(entity.Name))
                {
                    product.Name = entity.Name;
                }
                product.TopHot = entity.TopHot;
                product.Price = entity.Price;
                product.PromotionPrice = entity.PromotionPrice;
                product.Image = entity.Image;
                product.MoreImages = entity.MoreImages;
                product.OrginalPrice = product.OrginalPrice;
                product.Quantity = product.Quantity;
                product.CategoryID = entity.CategoryID;
                product.Warranty = product.Warranty;
                product.ModifiedBy = entity.ModifiedBy;
                product.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }


    }
}
