using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product_Sales_WebApp
{
    public class Product
    {
        public string ProdId { get; set; }
        public string ProdName { get; set; }
        public decimal ProdPrice { get; set; }
        public string ProdImage { get; set; }

        //public virtual Sales Sales { get; set; }

        //public int ProdQty { get; set; }
    }
}