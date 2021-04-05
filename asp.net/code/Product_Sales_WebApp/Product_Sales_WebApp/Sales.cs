using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Product_Sales_WebApp
{
    public class Sales
    {
        public int SalesId { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public string SalesDate { get; set; }
        public int Id { get; set; }
        public string ProdName { get; set; }
        public string Image { get; set; }
    }
}