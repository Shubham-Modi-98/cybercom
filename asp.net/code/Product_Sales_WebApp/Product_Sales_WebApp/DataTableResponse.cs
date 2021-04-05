using System.Collections.Generic;

namespace Product_Sales_WebApp
{
    internal class DataTableResponse
    {
        public int draw { get; internal set; }
        public int recordsFiltered { get; internal set; }
        public int recordsTotal { get; internal set; }
        public List<Product> data { get; set; }
    }
}