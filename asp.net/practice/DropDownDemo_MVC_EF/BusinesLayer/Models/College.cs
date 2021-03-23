using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DropDownDemo_MVC_EF.Models
{
    public class College
    {
        //public College()
        //{
        //    this.Student = new HashSet<Student>();
        //}
        public int Id { get; set; }
        public string CollegeName { get; set; }

        //public virtual ICollection<Student> Student { get; set; }
    }
}