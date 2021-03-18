using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RoutingMVC.Models
{
    public class Student
    {
        [Display(Name = "Enter Id")]
        public int Id { get; set; }

        [Display(Name = "Enter Name")]
        public string Name { get; set; }

        [Display(Name = "Enter Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public Address Address { get; set; }
    }
}