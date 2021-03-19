using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyModel.Model
{
    public class EmployeeModel
    {
        public int Id { get; set; }
     
        [Required]
        public int EmpId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        public string City { get; set; }
    }
}
