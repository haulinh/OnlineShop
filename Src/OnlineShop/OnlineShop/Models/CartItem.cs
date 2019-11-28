using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Models
{
    [Serializable]
    public class CartItem
    {
        public long ProductID { set; get; }
        public int Quantity { set; get; }
    }
}