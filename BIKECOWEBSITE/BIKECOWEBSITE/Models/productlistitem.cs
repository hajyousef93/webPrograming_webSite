using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIKECOWEBSITE.Models
{
    public class productlistitem
    {
        public IEnumerable<SelectListItem> chossproducts { get; set; }
        public IEnumerable<string> chossenproducts { get; set; }




    }
}