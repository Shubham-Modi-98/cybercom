using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryDbLayer.Db.Models
{
    public class OrderTypeIms
    {
        public int OrderTypeID { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public bool Status { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
    }
}
