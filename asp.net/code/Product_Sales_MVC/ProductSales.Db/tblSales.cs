//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProductSales.Db
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblSales
    {
        public int SalesId { get; set; }
        public int Qty { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public System.DateTime SalesDate { get; set; }
        public int Id { get; set; }
    
        public virtual tblProduct tblProduct { get; set; }
    }
}