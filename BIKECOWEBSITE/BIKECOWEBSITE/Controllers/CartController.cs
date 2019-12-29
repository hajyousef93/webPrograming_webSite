using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BIKECOWEBSITE.Models;

namespace BIKECOWEBSITE.Controllers
{
    public class CartController : Controller
    {
        private ADMDataBaseEntities db = new ADMDataBaseEntities();



        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        private int isExist(string id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.Product1 == id)
                    return i;
            return -1;


        }
        public ActionResult deletenow(string id)
        {
            int index = isExist(id);
            List<Item> cart = (List<Item>)Session["cart"];

            if (cart[index].Quantity <= 1)
            {
                cart.RemoveAt(index);
                Session["cart"] = cart;
            }
            else
            {
                cart[index].Quantity--;
                Session["cart"] = cart;
            }
            return View("Cart");

        }

        public ActionResult Ordernow(string id)
        {
            if (Session["UserId"] != null)
            {

                if (Session["cart"] == null)
                {
                    List<Item> cart = new List<Item>();
                    cart.Add(new Item(db.Products.Find(id), 1));
                    Session["cart"] = cart;
                }
                else
                {
                    List<Item> cart = (List<Item>)Session["cart"];
                    int index = isExist(id);
                    if (index == -1)
                        cart.Add(new Item(db.Products.Find(id), 1));
                    else
                        cart[index].Quantity++;
                    Session["cart"] = cart;
                }
                return View("Cart");
            }
            else {
                return RedirectToAction("Register", "Customers");
            }
        }
    }
}