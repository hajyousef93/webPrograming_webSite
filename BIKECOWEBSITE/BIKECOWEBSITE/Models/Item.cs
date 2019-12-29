using BIKECOWEBSITE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BIKECOWEBSITE.Controllers
{
    public class Item
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }

        //private int quantity;

        public Item(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

    


    }
}