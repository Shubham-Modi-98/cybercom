using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropDownDemo_MVC_EF.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CollegeId { get; set; }

        public virtual College College { get; set; }
    }
}