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
    public class ProductsController : Controller
    {
        private ADMDataBaseEntities db = new ADMDataBaseEntities();

        // GET: Products
        public ActionResult Index()
        {

            return View(db.Products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return PartialView(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {

            var Offers = new List<SelectListItem>
            {
                new SelectListItem() { Value = "Top" },
                new SelectListItem() { Value = "New"},
                new SelectListItem() { Value = "Sale" }
            };
            ViewBag.offers = new SelectList(Offers.Select(x => x.Value).Distinct());
            ViewBag.Category = new SelectList(db.Categories.Select(x => x.Category1).Distinct());
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Product1,Qty,Cost,Category,SellPrice,Manufacturer,Specs,Hints,Pic,Offers")] Product product)
        {
            var Offers = new List<SelectListItem>
            {
                new SelectListItem() { Value = "Top" },
                new SelectListItem() { Value = "New"},
                new SelectListItem() { Value = "Sale" }
            };
            ViewBag.offers = new SelectList(Offers.Select(x => x.Value).Distinct());
            ViewBag.Category = new SelectList(db.Categories.Select(x => x.Category1).Distinct());

            if (ModelState.IsValid)
            {

                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(string id)
        {

            var Offers = new List<SelectListItem>
            {
                new SelectListItem() { Value = "Top" },
                new SelectListItem() { Value = "New"},
                new SelectListItem() { Value = "Sale" }
            };
            ViewBag.offers = new SelectList(Offers.Select(x => x.Value).Distinct());
            ViewBag.Category = new SelectList(db.Categories.Select(x => x.Category1).Distinct());

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Product1,Qty,Cost,Category,SellPrice,Manufacturer,Specs,Hints,Pic,Offers")] Product product)
        {

            var Offers = new List<SelectListItem>
            {
                new SelectListItem() { Value = "Top" },
                new SelectListItem() { Value = "New"},
                new SelectListItem() { Value = "Sale" }
            };
            ViewBag.offers = new SelectList(Offers.Select(x => x.Value).Distinct());
            ViewBag.Category = new SelectList(db.Categories.Select(x => x.Category1).Distinct());

            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
        public ActionResult View1(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
        return PartialView(product);
        }

        public ActionResult Index1()
        {
            ViewBag.listProducts = db.Products.ToList();
            return View();
        }
        public RedirectResult monthlyreport()
        {
            return Redirect("/Reports/MonthlyReportForm.aspx");
        }
        public RedirectResult Dailyreport()
        {
            return Redirect("/Reports/DailyReportForm.aspx");
        }

    }
}
