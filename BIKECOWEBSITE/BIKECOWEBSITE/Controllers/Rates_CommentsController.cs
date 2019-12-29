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
    public class Rates_CommentsController : Controller
    {
        private ADMDataBaseEntities db = new ADMDataBaseEntities();

        // GET: Rates_Comments
        public ActionResult Index()
        {
            var rates_Comments = db.Rates_Comments.Include(r => r.Product);
            return View(rates_Comments.ToList());
        }

        // GET: Rates_Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rates_Comments rates_Comments = db.Rates_Comments.Find(id);
            if (rates_Comments == null)
            {
                return HttpNotFound();
            }
            return PartialView(rates_Comments);
        }

        // GET: Rates_Comments/Create
        public ActionResult Create()
        {
            ViewBag.ProductID = new SelectList(db.Products, "Product1", "Category");
            return View();
        }

        // POST: Rates_Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProductID,Comments,Rates")] Rates_Comments rates_Comments)
        {
            if (ModelState.IsValid)
            {
                db.Rates_Comments.Add(rates_Comments);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProductID = new SelectList(db.Products, "Product1", "Category", rates_Comments.ProductID);
            return View(rates_Comments);
        }

        // GET: Rates_Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rates_Comments rates_Comments = db.Rates_Comments.Find(id);
            if (rates_Comments == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductID = new SelectList(db.Products, "Product1", "Category", rates_Comments.ProductID);
            return View(rates_Comments);
        }

        // POST: Rates_Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductID,Comments,Rates")] Rates_Comments rates_Comments)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rates_Comments).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProductID = new SelectList(db.Products, "Product1", "Category", rates_Comments.ProductID);
            return View(rates_Comments);
        }

        // GET: Rates_Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rates_Comments rates_Comments = db.Rates_Comments.Find(id);
            if (rates_Comments == null)
            {
                return HttpNotFound();
            }
            return View(rates_Comments);
        }

        // POST: Rates_Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Rates_Comments rates_Comments = db.Rates_Comments.Find(id);
            db.Rates_Comments.Remove(rates_Comments);
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
        public ActionResult Commentsfull(string id)
        {
            var rates_Comments = db.Rates_Comments.Where(r => r.ProductID == id);
            return View(rates_Comments.ToList());
        }
        public ActionResult Ratesfull(string id)
        {
            var rates_Comments = db.Rates_Comments.Where(r => r.ProductID == id);
            return View(rates_Comments.ToList());
        }
        public ActionResult newCreate()
        {
            ViewBag.ProductID = new SelectList(db.Products, "Product1", "Category");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult newCreate(List<Rates_Comments> rates_Comments)
        {
            if (ModelState.IsValid)
            {
                using (ADMDataBaseEntities db = new ADMDataBaseEntities())
                {
                    foreach (var rat in rates_Comments)
                    {
                        var newrate = db.Rates_Comments.Create();
                        newrate.ID = rat.ID;
                        newrate.ProductID = rat.ProductID;
                        newrate.Comments = rat.Comments;
                        newrate.Rates = rat.Rates;
                        newrate.User_ID = rat.User_ID;
                        db.Rates_Comments.Add(rat);
                    }
                    db.SaveChanges();
                    Session["cart"] = null;
                }
            }
            //ViewBag.ProductID = new SelectList(db.Products, "Product1", "Category", rates_Comments.ProductID);
            return RedirectToAction("Index", "Home");
        }

    }
}
