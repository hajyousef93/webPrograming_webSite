using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BIKECOWEBSITE.Models;
using Microsoft.AnalysisServices.AdomdClient;

namespace BIKECOWEBSITE.Controllers
{
    public class OrdersDetailsController : Controller
    {
        private ADMDataBaseEntities db = new ADMDataBaseEntities();

        // GET: OrdersDetails
        public ActionResult Index()
        {
            var ordersDetails = db.OrdersDetails;
            return View(ordersDetails.ToList());
        }

        // GET: OrdersDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdersDetail ordersDetail = db.OrdersDetails.Find(id);
            if (ordersDetail == null)
            {
                return HttpNotFound();
            }
            return View(ordersDetail);
        }

        // GET: OrdersDetails/Create
        public ActionResult Create()
        {
            ViewBag.Category = new SelectList(db.Categories, "Category1", "Category1");
            ViewBag.OrderNumber = new SelectList(db.Orders, "OrderNumber", "OrderNumber");
            ViewBag.Product = new SelectList(db.Products, "Product1", "Category");
            ViewBag.Product = new SelectList(db.OrdersDetails, "ID", "ID");
            ViewBag.Product = new SelectList(db.OrdersDetails, "ProductPrice", "ProductPrice");

            return View();
        }

        // POST: OrdersDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OrderNumber,Category,Product,ProductPrice")] OrdersDetail ordersDetail)
        {
            if (ModelState.IsValid)
            {
                db.OrdersDetails.Add(entity: ordersDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category = new SelectList(db.Categories, "Category1", "Category1", ordersDetail.Category);
            ViewBag.OrderNumber = new SelectList(db.Orders, "OrderNumber", "OrderNumber", ordersDetail.OrderNumber);
            ViewBag.Product = new SelectList(db.Products, "Product1", "Category", ordersDetail.Product);
            ViewBag.Product = new SelectList(db.OrdersDetails, "ID", "ID", ordersDetail.ID);
            ViewBag.Product = new SelectList(db.OrdersDetails, "ProductPrice", "ProductPrice", ordersDetail.ProductPrice);


            return View(ordersDetail);
        }

        // GET: OrdersDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdersDetail ordersDetail = db.OrdersDetails.Find(id);
            if (ordersDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.Category = new SelectList(db.Categories, "Category1", "Category1", ordersDetail.Category);
            ViewBag.OrderNumber = new SelectList(db.Orders, "OrderNumber", "OrderNumber", ordersDetail.OrderNumber);
            ViewBag.Product = new SelectList(db.Products, "Product1", "Category", ordersDetail.Product);
            return View(ordersDetail);
        }

        // POST: OrdersDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OrderNumber,Category,Product,ProductPrice")] OrdersDetail ordersDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordersDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Category = new SelectList(db.Categories, "Category1", "Category1", ordersDetail.Category);
            ViewBag.OrderNumber = new SelectList(db.Orders, "OrderNumber", "OrderNumber", ordersDetail.OrderNumber);
            ViewBag.Product = new SelectList(db.Products, "Product1", "Category", ordersDetail.Product);
            return View(ordersDetail);
        }

        // GET: OrdersDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrdersDetail ordersDetail = db.OrdersDetails.Find(id);
            if (ordersDetail == null)
            {
                return HttpNotFound();
            }
            return View(ordersDetail);
        }

        // POST: OrdersDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdersDetail ordersDetail = db.OrdersDetails.Find(id);
            db.OrdersDetails.Remove(ordersDetail);
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
        public ActionResult Order_Details()
        {
            int orderid = db.OrdersDetails.OrderByDescending(p => p.ID).First().ID;
            ViewBag.ID = orderid+1;
            ViewBag.Category = new SelectList(db.Categories, "Category1", "Category1");
            ViewBag.OrderNumber = new SelectList(db.Orders, "OrderNumber", "OrderNumber");
            ViewBag.Product = new SelectList(db.Products, "Product1", "Category");
            return View();
        }

        // POST: OrdersDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Order_Details([Bind(Include = "ID,OrderNumber,Category,Product,ProductPrice")] OrdersDetail ordersDetail)
        {
            if (ModelState.IsValid)
            {
                db.OrdersDetails.Add(ordersDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Category = new SelectList(db.Categories, "Category1", "Category1", ordersDetail.Category);
            ViewBag.OrderNumber = new SelectList(db.Orders, "OrderNumber", "OrderNumber", ordersDetail.OrderNumber);
            ViewBag.Product = new SelectList(db.Products, "Product1", "Category", ordersDetail.Product);
            return View(ordersDetail);
        }
    
    public ActionResult Index1(double sum, int cont)
    {
            
            int orderdetid = db.OrdersDetails.OrderByDescending(p => p.ID).First().ID;
            ViewBag.orderdeid = orderdetid + 1;
            int orderid = db.Orders.OrderByDescending(p => p.ID).First().ID;
            ViewBag.ID = orderid + 1;
            string orderno = db.Orders.OrderByDescending(p => p.OrderNumber).First().OrderNumber;
            string ordernoint = orderno.Substring(2);
            ViewBag.NO = Convert.ToInt32(ordernoint) + 1;
            ViewBag.sum = sum;
            ViewBag.cont = cont;

            var ordersDetails = db.OrdersDetails;
            return View(ordersDetails.ToList());
    }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index1(List<OrdersDetail> list, [Bind(Include = "OrderNumber,PriseOfOrder,DateOfPurchase,ID")] Order order, double sum)
        {
            ADMDataBaseEntities dc = new ADMDataBaseEntities();
            int orderdetid = dc.OrdersDetails.OrderByDescending(p => p.ID).First().ID;
            ViewBag.orderdeid = orderdetid + 1;
            int orderid = dc.Orders.OrderByDescending(p => p.ID).First().ID;
            ViewBag.ID = orderid + 1;
            string orderno = dc.Orders.OrderByDescending(p => p.OrderNumber).First().OrderNumber;
            string ordernoint = orderno.Substring(2);
            ViewBag.NO = Convert.ToInt32(ordernoint) + 1;
              ViewBag.sum = sum;
            ViewBag.Message = string.Format("Your invoice has been submited");

            using (ADMDataBaseEntities da = new ADMDataBaseEntities())
            {
                var newOrder = da.Orders.Create();
                order.ID = @ViewBag.ID;
                order.OrderNumber = "SO" + ViewBag.NO;
                order.PriseOfOrder = sum;
                order.DateOfPurchase = @DateTime.Now;
                db.Orders.Add(order);
                db.SaveChanges();
            }
                if (ModelState.IsValid)
            {
                using (ADMDataBaseEntities db = new ADMDataBaseEntities())
                {
                    foreach (var ord in list)
                    {
                        var newOrdersDetail = db.OrdersDetails.Create();
                        newOrdersDetail.Category = ord.Category;
                        newOrdersDetail.OrderNumber = ord.OrderNumber;
                        newOrdersDetail.ProductPrice = ord.ProductPrice;
                        newOrdersDetail.Product = ord.Product;
                        newOrdersDetail.ID = ord.ID;
                        db.OrdersDetails.Add(ord);
                    }
                    db.SaveChanges();
                }
            }
         
            
            //return Content("Your invoice has been submited sucssesfuly");
            return RedirectToAction("newCreate", "Rates_Comments");
        }
        //on page-load
        public ActionResult Bought_Together()
        {
            //decalre a product list to save the chossen product inside it
            productlistitem listedproduct = new productlistitem();

            List<SelectListItem> listproducts = new List<SelectListItem>();
            //choose the products from DB 
            foreach (Product choosen in db.Products.Distinct())
            {
                SelectListItem s = new SelectListItem()
                {
                    Text = choosen.Product1,
                    Value = choosen.Product1.ToString(),
                    Selected = false
                };
                listproducts.Add(s);
            }
            //inserting chossen products into the list
            listedproduct.chossproducts = listproducts;

            return View(listedproduct);
        }
        //on post use the list of products that user define
        [HttpPost, ActionName("Bought_Together")]
        public ActionResult Bought_Together(IEnumerable<string> chossenproducts)
        {
            //reseting output on each clcik
            TempData["output"] = "";
            string res = "";
            string[] splited = { "" };
            //sending the selected items to view to show it to user
            if (chossenproducts == null)
            {
                TempData["selected"] = "You Don't choose any item!";
            }
            else
            {
                res = string.Join(",", chossenproducts);
                TempData["selected"] = res;
            }
            splited = res.Split(',');
            //dealing with split list "can't use the form way, its MVC"
            for (int i = 0; i <= splited.Length-1; i++)
            {
                TempData["splited"] += splited[i];
            }    
            //declaring input and out lists to be send to another function to returen needed items
            List<string> input = new List<string>();
            List<string> output = new List<string>();
            //we need only 3 items to be shown 
            int count = 3;
            //adding the selected item to input list
            foreach (string i in splited)
            {
                input.Add(i);
            }
            //sending the values to another function, and waiting for its output
            predict(input, output, count);
            //reciving the output and send it to view
            if (output!=null)
            {
                res = string.Join(",", output);
           
                TempData["output"] += res;
            }
            return RedirectToAction("Bought_Together");
        }
        //function to handel the query
        private void predict(List<string> input, List<string> output, int count)
        {
            //starting the connection
            AdomdConnection CON = new AdomdConnection("Data Source=WS\\SQLEXPRESS; Catalog=ADMDataBase");
            CON.Open();

            AdomdCommand COM = CON.CreateCommand();
            //quering the DB
           string s = @"SELECT Flattened  PREDICT([Orders Details]," + count + @")
           FROM [BIKECOAITEMSMM] 
            NATURAL PREDICTION JOIN
            (SELECT ( ";
            //count the items to produce valid query
            foreach (string x in input)
            {
                if (input.IndexOf(x) > 0)
                    s += " Union ";
                //skiping special carecters (only seen in "Women's"!!!!!!short product..... comeon!)
                s += "Select '" + x.Replace("'", "''") + "' as [product]";
            }
            s += " )  AS [Orders Details]) As T;";
            COM.CommandText = s;

            AdomdDataReader DR = COM.ExecuteReader();
            //send the returend value to output
            while (DR.Read())
            {

                if (DR[0] != null)
                    output.Add(DR[0].ToString());
            }
            DR.Close();
            CON.Close();
        }
        //time series on page load
        public ActionResult Will_Be()
        {
            //declaring calculations from 1-90 periods only
            int[] days = Enumerable.Range(1,90).ToArray();
            ViewBag.days = new SelectList(days);
            return View();
        }
        //on post 
        [HttpPost, ActionName("Will_Be")]
        public ActionResult Will_Be(IEnumerable<string> chossenproducts)
        {
            int[] days = Enumerable.Range(1, 90).ToArray();
            ViewBag.days = new SelectList(days);
            int getdays = Convert.ToInt32(Request.Form["days"]);

            //reset the old results
            TempData["output"] = "";
            string res = "";            
            //declaring list of products that returend from prediction function 
            List<string> output = new List<string>();
            int count = getdays;
            //send the count of perdios and waiting for the output
            will_predict(output, count);
            //send the output to the view
            if (output != null)
            {
                res = string.Join(",", output);

                TempData["output"] += res;
            }
            return RedirectToAction("Will_Be");
        }
        //predicti function 
        private void will_predict(List<string> output, int count)
        {
            //start connection
            AdomdConnection CON = new AdomdConnection("Data Source=WS\\SQLEXPRESS; Catalog=ADMDataBase");
            CON.Open();

            AdomdCommand COM = CON.CreateCommand();
            //quering the database
            string s = @"SELECT Flattened  PredictTimeSeries([Prise Of Order]," + count + @")
            as Forecast from BIKECOTSMM;";
            COM.CommandText = s;

            AdomdDataReader DR = COM.ExecuteReader();
            //setting the format of retuernd amount
            double shape = 0;
            string format = "";
            //send the output formated clearly to the main function to be views
            while (DR.Read())
            {
                if (DR[0] != null)
                shape = Convert.ToDouble(DR[1]);
                format = shape.ToString("F2");
                output.Add(format);
            }
            DR.Close();
            CON.Close();
        }

    }

}
