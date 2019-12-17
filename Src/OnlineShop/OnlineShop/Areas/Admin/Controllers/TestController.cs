using Model.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class TestController : Controller
    {
        // GET: Admin/Test
        // GET: Home
        public ActionResult Index()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();

            dataPoints.Add(new DataPoint("Mercury", 36));
            dataPoints.Add(new DataPoint("Venus", 67.2));
            dataPoints.Add(new DataPoint("Earth", 93));
            dataPoints.Add(new DataPoint("Mars", 141.6));
            dataPoints.Add(new DataPoint("Jupiter", 483.6));
            dataPoints.Add(new DataPoint("Saturn", 886.7));
            dataPoints.Add(new DataPoint("Uranus", 1784));
            dataPoints.Add(new DataPoint("Neptune", 2794.4));

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }
    }
}