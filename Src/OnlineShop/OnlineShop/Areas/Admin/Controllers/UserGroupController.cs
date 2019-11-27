using Model.Dao;
using Model.EntityFramework;
using Model.Extend;
using Model.ViewModel;
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
   
            var dao = new UserGroupDao();
            var entities = dao.GetUserGroups();
            

            //Loop and add the Parent Nodes.
            foreach (UserGroup type in entities)
            {
        
                   nodes.Add(new TreeViewNode { id = type.ID.ToString(), parent = "#", text = type.Name });
                
            }


            var childEntity = dao.GetRoleByGroup();

            // Loop and add the Child Nodes.
            foreach (UserRoleByGroupModel subType in childEntity)
            {
            
              nodes.Add(new TreeViewNode { id = subType.userGroup.ID.ToString() + "-" + subType.role.ID.ToString(), parent = subType.userGroup.ID.ToString(), text = subType.role.Name });
           

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