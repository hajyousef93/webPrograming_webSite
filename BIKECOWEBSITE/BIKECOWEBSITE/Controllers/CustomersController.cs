using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Threading;
using System.Web.Mvc;
using BIKECOWEBSITE.Models;
using System.Data.SqlClient;
using Microsoft.AnalysisServices.AdomdClient;


namespace BIKECOWEBSITE.Controllers
{
    public class CustomersController : Controller
    {
        private ADMDataBaseEntities db = new ADMDataBaseEntities();

        // GET: Customers
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.Order);
            return View(customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.OrderNumber = new SelectList(db.Orders, "OrderNumber", "OrderNumber");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Marital_Status,Gender,Income,Children,Education,Occupation,Home_Owner,Cars,Commute_Distance,Region,Age,Buy,OrderNumber,Email,F_Name,L_Name,Pass")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderNumber = new SelectList(db.Orders, "OrderNumber", "OrderNumber", customer.OrderNumber);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(double? id)
        {

            int[] Children = new int[] { 0, 1, 2, 3, 4, 5 };
            ViewBag.OrderNumber = new SelectList(db.Orders, "OrderNumber", "OrderNumber");
            ViewBag.Gender = new SelectList(db.Customers.Select(x => x.Gender).Distinct());
            ViewBag.email = new SelectList(db.Customers.Select(x => x.Email).Distinct());
            ViewBag.fn = new SelectList(db.Customers.Select(x => x.F_Name).Distinct());
            ViewBag.ln = new SelectList(db.Customers.Select(x => x.L_Name).Distinct());
            ViewBag.pas = new SelectList(db.Customers.Select(x => x.Pass).Distinct());
            ViewBag.Marital_Status = new SelectList(db.Customers.Select(x => x.Marital_Status).Distinct());
            ViewBag.Education = new SelectList(db.Customers.Select(x => x.Education).Distinct());
            ViewBag.Occupation = new SelectList(db.Customers.Select(x => x.Occupation).Distinct());
            ViewBag.Home_Owner = new SelectList(db.Customers.Select(x => x.Home_Owner).Distinct());
            ViewBag.Cars = new SelectList(db.Customers.Select(x => x.Cars).Distinct());
            ViewBag.Commute_Distance = new SelectList(db.Customers.Select(x => x.Commute_Distance).Distinct());
            ViewBag.Region = new SelectList(db.Customers.Select(x => x.Region).Distinct());
            ViewBag.Children = new SelectList(Children);
            ViewBag.ID = id;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            ViewBag.OrderNumber = new SelectList(db.Orders, "OrderNumber", "OrderNumber", customer.OrderNumber);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Marital_Status,Gender,Income,Children,Education,Occupation,Home_Owner,Cars,Commute_Distance,Region,Age,Buy,OrderNumber,F_Name,L_Name,Pass,Email")] Customer customer)
        {
            int[] Children = new int[] { 0, 1, 2, 3, 4, 5 };
            ViewBag.OrderNumber = new SelectList(db.Orders, "OrderNumber", "OrderNumber");
            ViewBag.Gender = new SelectList(db.Customers.Select(x => x.Gender).Distinct());
            ViewBag.email = new SelectList(db.Customers.Select(x => x.Email).Distinct());
            ViewBag.fn = new SelectList(db.Customers.Select(x => x.F_Name).Distinct());
            ViewBag.ln = new SelectList(db.Customers.Select(x => x.L_Name).Distinct());
            ViewBag.pas = new SelectList(db.Customers.Select(x => x.Pass).Distinct());
            ViewBag.Marital_Status = new SelectList(db.Customers.Select(x => x.Marital_Status).Distinct());
            ViewBag.Education = new SelectList(db.Customers.Select(x => x.Education).Distinct());
            ViewBag.Occupation = new SelectList(db.Customers.Select(x => x.Occupation).Distinct());
            ViewBag.Home_Owner = new SelectList(db.Customers.Select(x => x.Home_Owner).Distinct());
            ViewBag.Cars = new SelectList(db.Customers.Select(x => x.Cars).Distinct());
            ViewBag.Commute_Distance = new SelectList(db.Customers.Select(x => x.Commute_Distance).Distinct());
            ViewBag.Region = new SelectList(db.Customers.Select(x => x.Region).Distinct());
            ViewBag.Children = new SelectList(Children);

            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.OrderNumber = new SelectList(db.Orders, "OrderNumber", "OrderNumber", customer.OrderNumber);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(double id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
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
        public ActionResult Register()
        {
            int[] Children = new int[] { 0, 1, 2, 3, 4, 5 };
            double personId = db.Customers.OrderByDescending(p => p.ID).First().ID;

            ViewBag.OrderNumber = new SelectList(db.Orders, "OrderNumber", "OrderNumber");
            ViewBag.Gender = new SelectList(db.Customers.Select(x => x.Gender).Distinct());
            ViewBag.Marital_Status = new SelectList(db.Customers.Select(x => x.Marital_Status).Distinct());
            ViewBag.Education = new SelectList(db.Customers.Select(x => x.Education).Distinct());
            ViewBag.Occupation = new SelectList(db.Customers.Select(x => x.Occupation).Distinct());
            ViewBag.Home_Owner = new SelectList(db.Customers.Select(x => x.Home_Owner).Distinct());
            ViewBag.Cars = new SelectList(db.Customers.Select(x => x.Cars).Distinct());
            ViewBag.Commute_Distance = new SelectList(db.Customers.Select(x => x.Commute_Distance).Distinct());
            ViewBag.Region = new SelectList(db.Customers.Select(x => x.Region).Distinct());
            ViewBag.Children = new SelectList(Children);
            ViewBag.ID = personId + 1;

            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "ID,Marital_Status,Gender,Income,Children,Education,Occupation,Home_Owner,Cars,Commute_Distance,Region,Age,Buy,OrderNumber,F_Name,L_Name,Pass,Email")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.OrderNumber = new SelectList(db.Orders, "OrderNumber", "OrderNumber", customer.OrderNumber);
            return View(customer);
        }
        public ActionResult Login()
        {
            return PartialView();
        }
        [HttpPost]
        public JsonResult LoginUser(Customer model)
        {
            string result = "fail";

            ADMDataBaseEntities db = new ADMDataBaseEntities();
            Customer customer = db.Customers.SingleOrDefault(x => x.Email == model.Email && x.Pass == model.Pass);
            if (customer != null)
            {
                Session["UserId"] = customer.ID;
                Session["UserName"] = customer.Email;
                if (customer.ID == 29453)
                {
                    result = "Admin";
                    Session["type"] = "Admin";
                }
                else
                {
                    result = "GeneralUser";
                }
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
        //on page-load
        public ActionResult He_will_buy()
        {
            //declaring and sending values from controller to view
            int[] Children = new int[] { 0, 1, 2, 3, 4, 5 };
            ViewBag.Gender = new SelectList(db.Customers.Select(x => x.Gender).Distinct());
            ViewBag.Marital_Status = new SelectList(db.Customers.Select(x => x.Marital_Status).Distinct());
            ViewBag.Education = new SelectList(db.Customers.Select(x => x.Education).Distinct());
            //for example user can't choose any other occupation
            ViewBag.Occupation = new SelectList(db.Customers.Select(x => x.Occupation).Distinct());
            ViewBag.Home_Owner = new SelectList(db.Customers.Select(x => x.Home_Owner).Distinct());
            ViewBag.Cars = new SelectList(db.Customers.Select(x => x.Cars).Distinct());
            ViewBag.Commute_Distance = new SelectList(db.Customers.Select(x => x.Commute_Distance).Distinct());
            ViewBag.Region = new SelectList(db.Customers.Select(x => x.Region).Distinct());
            ViewBag.Children = new SelectList(Children);

            return View();
        }
        //onclick
        [HttpPost, ActionName("He_will_buy")]
        public ActionResult He_will_buyPost()
        {
            //same varibles should be readed by the buttoon and post it to the DB
            int[] Children = new int[] { 0, 1, 2, 3, 4, 5 };
            ViewBag.Gender = new SelectList(db.Customers.Select(x => x.Gender).Distinct());
            ViewBag.Marital_Status = new SelectList(db.Customers.Select(x => x.Marital_Status).Distinct());
            ViewBag.Education = new SelectList(db.Customers.Select(x => x.Education).Distinct());
            ViewBag.Occupation = new SelectList(db.Customers.Select(x => x.Occupation).Distinct());
            ViewBag.Home_Owner = new SelectList(db.Customers.Select(x => x.Home_Owner).Distinct());
            ViewBag.Cars = new SelectList(db.Customers.Select(x => x.Cars).Distinct());
            ViewBag.Commute_Distance = new SelectList(db.Customers.Select(x => x.Commute_Distance).Distinct());
            ViewBag.Region = new SelectList(db.Customers.Select(x => x.Region).Distinct());
            ViewBag.Children = new SelectList(Children);

            //requesting the posted value by the user
            string Commute_Distance = Request["Commute_Distance"].ToString();
            string Education = Request.Form["Education"].ToString();
            string Gender = Request.Form["Gender"].ToString();
            string Home_Owner = Request.Form["Home_Owner"].ToString();
            string Marital_Status = Request.Form["Marital_Status"].ToString();
            string Occupation = Request.Form["Occupation"].ToString();
            string Region = Request.Form["Region"].ToString();
            int getage = Convert.ToInt32(Request.Form["Age"]);
            int getcar = Convert.ToInt32(Request.Form["Cars"]);
            int getchild = Convert.ToInt32(Request.Form["Children"]);
            int getincome = Convert.ToInt32(Request.Form["Income"]);

            //declaring the Admomd connection
            AdomdConnection con = new AdomdConnection("Data Source=WS\\SQLEXPRESS; Catalog=ADMDataBase");
            con.Open();
            AdomdCommand cmd = new AdomdCommand();
            cmd.Connection = con;
            //setting the query
            string s = @"Select flattened predicthistogram (Buy) from BIKECOBMM natural prediction join
                                           (select '" + getage + @"' as [Age],
                                            '" + getcar + @"' as [Cars],
                                            '" + getchild + @" ' as [Children],
                                            '" + Commute_Distance + @"' as [Commute Distance],
                                            '" + Education + @"' as [Education],
                                            '" + Gender + @"' as [Gender],
                                            '" + Home_Owner + @"' as [Home Owner],
                                            '" + getincome + @"' as [Income],
                                            '" + Marital_Status + @"' as [Marital Status],
                                            '" + Occupation + @"' as [Occupation],
                                            '" + Region + @"' as [Region]) as t";
            cmd.CommandText = s;
            AdomdDataReader dr = cmd.ExecuteReader();
            string final_result = "";
            
            //bring me the result of string "yes/no" and the int percentage
            if (dr.Read())
            {
                if (dr[0] != null)
                {
                    final_result += dr[0].ToString() + " " + dr[2].ToString();
                    ViewBag.final_resultstring = dr[0].ToString();
                    //send the results to view
                    ViewBag.final_resultint = dr[2].ToString();
                }
                dr.Close();
                con.Close();
            }
            return View();
        }
        //on page-load
        public ActionResult Classify_customer()
        {
            //declaring values and send it to view
            int[] Children = new int[] { 0, 1, 2, 3, 4, 5 };
            ViewBag.Gender = new SelectList(db.Customers.Select(x => x.Gender).Distinct());
            ViewBag.Marital_Status = new SelectList(db.Customers.Select(x => x.Marital_Status).Distinct());
            ViewBag.Education = new SelectList(db.Customers.Select(x => x.Education).Distinct());
            ViewBag.Occupation = new SelectList(db.Customers.Select(x => x.Occupation).Distinct());
            ViewBag.Home_Owner = new SelectList(db.Customers.Select(x => x.Home_Owner).Distinct());
            ViewBag.Cars = new SelectList(db.Customers.Select(x => x.Cars).Distinct());
            ViewBag.Commute_Distance = new SelectList(db.Customers.Select(x => x.Commute_Distance).Distinct());
            ViewBag.Region = new SelectList(db.Customers.Select(x => x.Region).Distinct());
            ViewBag.Children = new SelectList(Children);

            return View();
        }
        //on post 
        [HttpPost, ActionName("Classify_customer")]
        public ActionResult Classify_customerPost()
        {
            //setting the values that user should choose from
            int[] Children = new int[] { 0, 1, 2, 3, 4, 5 };
            ViewBag.Gender = new SelectList(db.Customers.Select(x => x.Gender).Distinct());
            ViewBag.Marital_Status = new SelectList(db.Customers.Select(x => x.Marital_Status).Distinct());
            ViewBag.Education = new SelectList(db.Customers.Select(x => x.Education).Distinct());
            ViewBag.Occupation = new SelectList(db.Customers.Select(x => x.Occupation).Distinct());
            ViewBag.Home_Owner = new SelectList(db.Customers.Select(x => x.Home_Owner).Distinct());
            ViewBag.Cars = new SelectList(db.Customers.Select(x => x.Cars).Distinct());
            ViewBag.Commute_Distance = new SelectList(db.Customers.Select(x => x.Commute_Distance).Distinct());
            ViewBag.Region = new SelectList(db.Customers.Select(x => x.Region).Distinct());
            ViewBag.Children = new SelectList(Children);
            //requesting whatever user inserted
            string Commute_Distance = Request["Commute_Distance"].ToString();
            string Education = Request.Form["Education"].ToString();
            string Gender = Request.Form["Gender"].ToString();
            string Home_Owner = Request.Form["Home_Owner"].ToString();
            string Marital_Status = Request.Form["Marital_Status"].ToString();
            string Occupation = Request.Form["Occupation"].ToString();
            string Region = Request.Form["Region"].ToString();
            int getage = Convert.ToInt32(Request.Form["Age"]);
            int getcar = Convert.ToInt32(Request.Form["Cars"]);
            int getchild = Convert.ToInt32(Request.Form["Children"]);
            int getincome = Convert.ToInt32(Request.Form["Income"]);
            //starting the connection
            AdomdConnection con = new AdomdConnection("Data Source=WS\\SQLEXPRESS; Catalog=ADMDataBase");
            con.Open();
            AdomdCommand cmd = new AdomdCommand();
            cmd.Connection = con;
            //quering the data base
            string s = @"Select flattened Category from BIKECOCCMM natural prediction join
                                           (select '" + getage + @"' as [Age],
                                            '" + getcar + @"' as [Cars],
                                            '" + getchild + @" ' as [Children],
                                            '" + Commute_Distance + @"' as [Commute Distance],
                                            '" + Education + @"' as [Education],
                                            '" + Gender + @"' as [Gender],
                                            '" + Home_Owner + @"' as [Home Owner],
                                            '" + getincome + @"' as [Income],
                                            '" + Marital_Status + @"' as [Marital Status],
                                            '" + Occupation + @"' as [Occupation],
                                            '" + Region + @"' as [Region]) as t";
            cmd.CommandText = s;
            AdomdDataReader dr = cmd.ExecuteReader();
            string final_result = "";
            //returen the value from db, stor it and send it to view
            if (dr.Read())
            {
                if (dr[0] != null)
                {
                    final_result += dr[0].ToString();
                    ViewBag.final_result = dr[0].ToString();
                }
                dr.Close();
                con.Close();
            }
            return View();
        }
        //on page-load
        public ActionResult Get_Recommendation()
        {
            //setting variables and send it to view
            int[] Children = new int[] { 0, 1, 2, 3, 4, 5 };
            ViewBag.Gender = new SelectList(db.Customers.Select(x => x.Gender).Distinct());
            ViewBag.Marital_Status = new SelectList(db.Customers.Select(x => x.Marital_Status).Distinct());
            ViewBag.Education = new SelectList(db.Customers.Select(x => x.Education).Distinct());
            ViewBag.Occupation = new SelectList(db.Customers.Select(x => x.Occupation).Distinct());
            ViewBag.Home_Owner = new SelectList(db.Customers.Select(x => x.Home_Owner).Distinct());
            ViewBag.Cars = new SelectList(db.Customers.Select(x => x.Cars).Distinct());
            ViewBag.Commute_Distance = new SelectList(db.Customers.Select(x => x.Commute_Distance).Distinct());
            ViewBag.Region = new SelectList(db.Customers.Select(x => x.Region).Distinct());
            ViewBag.Children = new SelectList(Children);


            return View();
        }
        //on post, or click 
        [HttpPost, ActionName("Get_Recommendation")]
        public ActionResult Get_RecommendationPost()
        {

            int[] Children = new int[] { 0, 1, 2, 3, 4, 5 };
            ViewBag.Gender = new SelectList(db.Customers.Select(x => x.Gender).Distinct());
            ViewBag.Marital_Status = new SelectList(db.Customers.Select(x => x.Marital_Status).Distinct());
            ViewBag.Education = new SelectList(db.Customers.Select(x => x.Education).Distinct());
            ViewBag.Occupation = new SelectList(db.Customers.Select(x => x.Occupation).Distinct());
            ViewBag.Home_Owner = new SelectList(db.Customers.Select(x => x.Home_Owner).Distinct());
            ViewBag.Cars = new SelectList(db.Customers.Select(x => x.Cars).Distinct());
            ViewBag.Commute_Distance = new SelectList(db.Customers.Select(x => x.Commute_Distance).Distinct());
            ViewBag.Region = new SelectList(db.Customers.Select(x => x.Region).Distinct());
            ViewBag.Children = new SelectList(Children);
            //get the results from the user
            string Commute_Distance = Request["Commute_Distance"].ToString();
            string Education = Request.Form["Education"].ToString();
            string Gender = Request.Form["Gender"].ToString();
            string Home_Owner = Request.Form["Home_Owner"].ToString();
            string Marital_Status = Request.Form["Marital_Status"].ToString();
            string Occupation = Request.Form["Occupation"].ToString();
            string Region = Request.Form["Region"].ToString();
            int getage = Convert.ToInt32(Request.Form["Age"]);
            int getcar = Convert.ToInt32(Request.Form["Cars"]);
            int getchild = Convert.ToInt32(Request.Form["Children"]);
            int getincome = Convert.ToInt32(Request.Form["Income"]);
            //start connection
            AdomdConnection con = new AdomdConnection("Data Source=WS\\SQLEXPRESS; Catalog=ADMDataBase");
            con.Open();
            AdomdCommand cmd = new AdomdCommand();
            cmd.Connection = con;
            //start query the DB
            string s = @"Select predict ([Product]) from BIKECOGRMM natural prediction join
                                           (select '" + getage + @"' as [Age],
                                            '" + getcar + @"' as [Cars],
                                            '" + getchild + @" ' as [Children],
                                            '" + Commute_Distance + @"' as [Commute Distance],
                                            '" + Education + @"' as [Education],
                                            '" + Gender + @"' as [Gender],
                                            '" + Home_Owner + @"' as [Home Owner],
                                            '" + getincome + @"' as [Income],
                                            '" + Marital_Status + @"' as [Marital Status],
                                            '" + Occupation + @"' as [Occupation],
                                            '" + Region + @"' as [Region]) as t";
            cmd.CommandText = s;
            AdomdDataReader dr = cmd.ExecuteReader();
            string final_result = "";
            //returen the result
            if (dr.Read())
            {
                if (dr[0] != null)
                {
                    final_result += dr[0].ToString();
                    ViewBag.final_result = dr[0].ToString();
                }
                dr.Close();
                con.Close();
            }
            return View();
        }



    }
}
