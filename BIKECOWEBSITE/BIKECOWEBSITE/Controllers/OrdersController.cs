using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BIKECOWEBSITE.Models;


namespace BIKECOWEBSITE.Controllers
{
    public class OrdersController : Controller
    {
        private ADMDataBaseEntities db = new ADMDataBaseEntities();

        // GET: Orders
        public ActionResult Index()
        {
            return View(db.Orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {


            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderNumber,PriseOfOrder,DateOfPurchase,ID")] Order order,
            [Bind(Include = "ID,OrderNumber,Category,ProductPrice,Product")] OrdersDetail ordersDetail)
        {
            ADMDataBaseEntities db = new ADMDataBaseEntities();
            int orderdetid = db.OrdersDetails.OrderByDescending(p => p.ID).First().ID;
            ViewBag.orderdeid = orderdetid + 1;
            int orderid = db.Orders.OrderByDescending(p => p.ID).First().ID;
            ViewBag.ID = orderid + 1;
            string orderno = db.Orders.OrderByDescending(p => p.OrderNumber).First().OrderNumber;
            string ordernoint = orderno.Substring(2);
            ViewBag.NO = Convert.ToInt32(ordernoint) + 1;

            if (ModelState.IsValid)
            {

                db.Orders.Add(order);
                db.SaveChanges();

                var newOrdersDetail = db.OrdersDetails.Create();
                newOrdersDetail.ID = ordersDetail.ID;
                newOrdersDetail.OrderNumber = ordersDetail.OrderNumber;
                newOrdersDetail.Category = ordersDetail.Category;
                newOrdersDetail.ProductPrice = ordersDetail.ProductPrice;
                newOrdersDetail.Product = ordersDetail.Product;
                db.OrdersDetails.Add(ordersDetail);
                db.SaveChanges();



                return RedirectToAction("Index");
            }

            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderNumber,PriseOfOrder,DateOfPurchase,ID")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        //public ActionResult Confirm_Order(double sum, int cont)
        //{
        //    ADMDataBaseEntities db = new ADMDataBaseEntities();

        //    var solditem = new List<string>();
        //    var cat = new List<string>();
        //    var qty = new List<int>();
        //    var price = new List<double>();



        //    int orderdetid = db.OrdersDetails.OrderByDescending(p => p.ID).First().ID;
        //    ViewBag.orderdeid = orderdetid + 1;
        //    int orderid = db.Orders.OrderByDescending(p => p.ID).First().ID;
        //    ViewBag.ID = orderid + 1;
        //    string orderno = db.Orders.OrderByDescending(p => p.OrderNumber).First().OrderNumber;
        //    string ordernoint = orderno.Substring(2);
        //    ViewBag.NO = Convert.ToInt32(ordernoint) + 1;
        //    ViewBag.sum = sum;
        //    //ViewBag.Cat = 1;
        //    ViewBag.cont = cont;

        //    foreach(Item item in (List<Item>)Session["cart"])
        //        {
        //        double suumm = 0;
        //        if (item.Product.SellPrice.HasValue)
        //        {
        //            suumm = item.Product.SellPrice.Value;
        //            price.Add(item.Product.SellPrice.Value);
        //        }
        //        sum += (suumm * item.Quantity);
           
        //           solditem.Add(item.Product.Product1);
        //        cat.Add(item.Product.Category);
        //        qty.Add(item.Quantity);


        //    }
        //    using (ADMDataBaseEntities dc = new ADMDataBaseEntities())
        //    {
        //    }
        //    for (int i = 0; i <= solditem.Count() - 1; i++)
        //    {
        //        ViewBag.shodata = db.OrdersDetails.ToList();

        //        //ViewBag.shodata = db.OrdersDetails.Where(pro=>pro.Product==) ToList();
        //    }
        //    //List<OrdersDetail> ci = new List<OrdersDetail> { new OrdersDetail { ID = 0, Category = "", OrderNumber = "", Product = "", ProductPrice = 0 } };


        //    return View();
        //}

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Confirm_Order([Bind(Include = "OrderNumber,PriseOfOrder,DateOfPurchase,ID")] Order order, List<OrdersDetail> list)
        //{

            
        //    string contreq = Request["solditem.Count"];

        //    int cont = Convert.ToInt32(contreq);
        //    double sum = 1;
        //    var solditem = new List<string>();
        //    var cat = new List<string>();
        //    var qty = new List<int>();
        //    var price = new List<double>();
        //    foreach (Item item in (List<Item>)Session["cart"])
        //    {

        //        double suumm = 0;
        //        if (item.Product.SellPrice.HasValue)
        //        {
        //            suumm = item.Product.SellPrice.Value;
        //            price.Add(item.Product.SellPrice.Value);
        //        }
        //        sum += (suumm * item.Quantity);

        //        solditem.Add(item.Product.Product1);
        //        cat.Add(item.Product.Category);
        //        qty.Add(item.Quantity);
        //    }

        //    //if (ModelState.IsValid)
        //    //{
        //    //    db.Orders.Add(order);
        //    //    db.SaveChanges();


        //        //if (ModelState.IsValid)
        //        //{
        //        //    using (ADMDataBaseEntities db = new ADMDataBaseEntities())
        //        //    {
        //        //        foreach (var ord in list)
        //        //        {
        //        //            var newOrdersDetail = db.OrdersDetails.Create();
        //        //            newOrdersDetail.ID = ord.ID;
        //        //            newOrdersDetail.OrderNumber = ord.OrderNumber;
        //        //            newOrdersDetail.Category = ord.Category;
        //        //            newOrdersDetail.ProductPrice = ord.ProductPrice;
        //        //            newOrdersDetail.Product = ord.Product;
        //        //            db.OrdersDetails.Add(ord);
        //        //        }
        //        //        db.SaveChanges();
        //        //    }
        //        //}





        //        return RedirectToAction("Index1","OrdersDetails");
        //    //}

            //return View(order);
        }

        //[HttpPost]
        //public ActionResult Confirm_Order(List<OrdersDetail> ordersDetail)
        //{

        //    ADMDataBaseEntities db = new ADMDataBaseEntities();

        //    foreach (OrdersDetail ord in ordersDetail)
        //    {
        //        var newOrdersDetail = db.OrdersDetails.Create();
        //        //orderdetidnew = orderdetidnew + i;

        //        newOrdersDetail.ID = ord.ID;
        //        newOrdersDetail.OrderNumber = ord.OrderNumber;
        //        newOrdersDetail.Category = ord.Category;
        //        newOrdersDetail.ProductPrice = ord.ProductPrice;
        //        newOrdersDetail.Product = ord.Product;
        //        db.OrdersDetails.Add(ord);
        //        db.SaveChanges();
        //    }

        //        return View();
        //}











        //public ActionResult Createorderdetail()
        //{


        //    int orderdetid = db.OrdersDetails.OrderByDescending(p => p.ID).First().ID;
        //    ViewBag.orderdeid = orderdetid + 1;
        //    int orderid = db.Orders.OrderByDescending(p => p.ID).First().ID;
        //    ViewBag.ID = orderid + 1;
        //    string orderno = db.Orders.OrderByDescending(p => p.OrderNumber).First().OrderNumber;
        //    string ordernoint = orderno.Substring(2);
        //    ViewBag.NO = Convert.ToInt32(ordernoint) + 1;
        //    //ViewBag.sum = sum;
        //    ////ViewBag.Cat = 1;
        //    //ViewBag.cont = cont;

            

        //    using (ADMDataBaseEntities db = new ADMDataBaseEntities())
        //    {
        //    }
        //        return PartialView(db.OrdersDetails.ToList());
            
        //}
        //[HttpPost]
        //public ActionResult Createorderdetail(List<OrdersDetail> list)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        using (ADMDataBaseEntities db = new ADMDataBaseEntities())
        //        {
        //            foreach (var ord in list)
        //            {
        //                var newOrdersDetail = db.OrdersDetails.Create();
        //                newOrdersDetail.ID = ord.ID;
        //                newOrdersDetail.OrderNumber = ord.OrderNumber;
        //                newOrdersDetail.Category = ord.Category;
        //                newOrdersDetail.ProductPrice = ord.ProductPrice;
        //                newOrdersDetail.Product = ord.Product;
        //                db.OrdersDetails.Add(ord);
        //            }
        //            db.SaveChanges();
        //        }
        //    }
        //    return PartialView(list);
        //}



        //}
}
