using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EntityFramework;

namespace Model.ViewModel
{
    public  class OrderDetailViewModel
    {
        public OrderDetail orderDetail;
        public Product product;
    }
    public class InvoiceViewModel
    {
        public Order order;
        public List<OrderDetailViewModel> orderDetails;
    }
}
