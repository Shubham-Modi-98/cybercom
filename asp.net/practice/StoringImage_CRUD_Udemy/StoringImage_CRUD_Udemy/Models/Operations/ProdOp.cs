using StoringImage_CRUD_Udemy.Models.DataBaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoringImage_CRUD_Udemy.Models.Operations
{
    public class ProdOp
    {
        public List<ProdImg> GetProds()
        {
            using (var context = new DbDemoEFEntities())
            {
                List<ProdImg> result = context.tblProd_Img.Select(x => new ProdImg()
                {
                    Id = x.Id,
                    ProdId = x.ProdId,
                    ProdName = x.ProdName,
                    ProdQty = x.ProdQty,
                    ProdPrice = x.ProdPrice,
                    Date = x.Date,
                    Image = x.Image
                }).ToList();
                return result;
            }
        }
    }
}