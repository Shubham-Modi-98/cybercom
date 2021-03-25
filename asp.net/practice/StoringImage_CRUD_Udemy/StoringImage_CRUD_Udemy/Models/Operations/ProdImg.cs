using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoringImage_CRUD_Udemy.Models
{
    public class ProdImg
    {
        public int Id { get; set; }
        public string ProdId { get; set; }
        public string ProdName { get; set; }
        public int ProdQty { get; set; }
        public decimal ProdPrice { get; set; }
        public string Image { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    }
}