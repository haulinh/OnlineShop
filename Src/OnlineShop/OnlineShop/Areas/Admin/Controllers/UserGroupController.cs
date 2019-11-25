using Model.Dao;
using Model.EntityFramework;
using Model.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class UserGroupController : Controller
    {
        // GET: Admin/UserGroup
        [HttpGet]
        public ActionResult Index()
        {
            List<TreeViewNode> nodes = new List<TreeViewNode>();
            var dao = new ProductCategoryDao();
            var entities = dao.GetListProductCategory();
            

            //Loop and add the Parent Nodes.
            foreach (ProductCategory type in entities)
            {
                if (type.ParentID == null)
                {
                    nodes.Add(new TreeViewNode { id = type.ID.ToString(), parent = "#", text = type.Name });
                }
            }

            //Loop and add the Child Nodes.
            foreach (ProductCategory subType in entities)
            {
                if (subType.ParentID!=null)
                {
                    nodes.Add(new TreeViewNode { id = subType.ParentID.ToString() + "-" + subType.ID.ToString(), parent = subType.ParentID.ToString(), text = subType.Name });
                }
             
            }

            //Serialize to JSON string.
            ViewBag.Json = (new JavaScriptSerializer()).Serialize(nodes);
            return View();
        }

        [HttpPost]
        public ActionResult Index(string selectedItems)
        {
            List<TreeViewNode> items = (new JavaScriptSerializer()).Deserialize<List<TreeViewNode>>(selectedItems);
            return RedirectToAction("Index");
        }
    }
   
}