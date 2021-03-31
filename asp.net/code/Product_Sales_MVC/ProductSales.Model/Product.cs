using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSales.Model
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Product Id")]
        public string ProdId { get; set; }

        [Required]
        [Display(Name = "Product Name")]
        public string ProdName { get; set; }

        [Required]
        [Range(1,int.MaxValue ,ErrorMessage = "Enter Valid Quantity")]
        [Display(Name = "Quantity")]
        public int Qty { get; set; }

        [Required]
        [Display(Name = "Price")]
        //[Range(typeof(decimal),"0",")]
        public decimal Price { get; set; }

        [Display(Name = "Image")]
        public string Image { get; set; }

        public virtual Sales Sales { get; set; }


    }
}
