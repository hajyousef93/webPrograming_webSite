using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BIKECOWEBSITE.Models;


namespace BIKECOWEBSITE.Controllers
{
    public class HomeController : Controller
    {
        ADMDataBaseEntities db = new ADMDataBaseEntities();


        public ActionResult Index()
        {
            List<object> myModel = new List<object>();
            myModel.Add(db.Categories.ToList());
            myModel.Add(db.Products.ToList());
            myModel.Add(db.Customers.ToList());



            return View(myModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Map()
        {

            return PartialView();
        }

    }
}