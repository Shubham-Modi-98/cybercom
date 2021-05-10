using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDbLayer.Db.Models
{
    public class OrderIms
    {
        public int OrderID { get; set; }
        public int OrderTypeID { get; set; }
        public System.DateTime OrderDate { get; set; }
        //public string OrderDate { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }

        public virtual CustomerIms Customer { get; set; }
        public virtual OrderTypeIms OrderType { get; set; }
        public virtual ProductIms Product { get; set; }
    }
}
