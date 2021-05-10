//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InventoryDbLayer.Db
{
    using System;
    using System.Collections.Generic;
    
    public partial class Orders
    {
        public int OrderID { get; set; }
        public int OrderTypeID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Status { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual OrderType OrderType { get; set; }
        public virtual Product Product { get; set; }
    }
}
