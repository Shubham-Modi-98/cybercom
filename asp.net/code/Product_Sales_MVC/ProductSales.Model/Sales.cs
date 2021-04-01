using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSales.Model
{
     public class Sales
    {
        public int SalesId { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public System.DateTime SalesDate { get; set; }

        public int Id { get; set; }

        public virtual Product Product { get; set; }
    }
}
