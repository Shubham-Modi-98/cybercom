﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_EF_Exception_Demo.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProdId { get; set; }
        public string ProdName { get; set; }
        public int ProdQty { get; set; }
        public decimal ProdPrice { get; set; }
    }
}