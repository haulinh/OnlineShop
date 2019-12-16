using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EntityFramework;
using Model.ViewModel;

namespace Model.Dao
{
    public class OrderDao
    {
        OnlineShopDbContext db = null;
        public OrderDao()
        {
            db = new OnlineShopDbContext();
        }
        public long Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.ID;
        }
        public List<InvoiceViewModel> GetListInvoice()
         {

            List<Order> order = db.Orders.ToList();
            List<OrderDetail> orderDetail = db.OrderDetails.ToList();
            List<Product> products = db.Products.ToList();
            var userViewModel = from o in order
                                select new InvoiceViewModel
                                {
                                    order = o,
                                    orderDetails = (
                                    from d in orderDetail.Where(x => x.OrderID == o.ID)
                                    join p in products
                                    on d.ProductID equals p.ID
                                    select new OrderDetailViewModel
                                    {
                                        orderDetail = d,
                                        product = p,
                                    }
                                    ).ToList(),
                                };

            return userViewModel.OrderByDescending(x=>x.order.CreatedDate).ToList();
        }


        public InvoiceViewModel ViewDetail(long ID)
        {

            List<Order> order = db.Orders.ToList();
            List<OrderDetail> orderDetail = db.OrderDetails.ToList();
            List<Product> products = db.Products.ToList();
            var userViewModel = from o in order
                                select new InvoiceViewModel
                                {
                                    order = o,
                                    orderDetails = (
                                    from d in orderDetail.Where(x => x.OrderID == o.ID)
                                    join p in products
                                    on d.ProductID equals p.ID
                                    select new OrderDetailViewModel
                                    {
                                        orderDetail = d,
                                        product = p,
                                    }
                                    ).ToList(),
                                };

            return userViewModel.FirstOrDefault(x=>x.order.ID==ID);

        }
    }
}
