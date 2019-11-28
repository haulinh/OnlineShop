using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Controllers
{
    public class CartController : Controller
    {

        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {

                 list = (List<CartItem>)cart;
            }
            else
            {

            }
                return View(list);
        }


        public ActionResult AddItem(long produceId,int quantity)
        {
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;


                if (list.Exists(x=>x.ProductID==produceId))
                {
                    foreach (var item in list)
                    {
                        if (item.ProductID == produceId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.ProductID = produceId;
                    item.Quantity = quantity;
                    list.Add(item);
                }
            
            }
            else
            {
                var item = new CartItem();
                item.ProductID = produceId;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                Session[CartSession] = list;
            }


            return RedirectToAction("Index");
        }
    }
}