using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StronglyTypedHelperMVC.Models
{
    public class Employee
    {
        [Display(Name = "Enter Id")]
        public int Id { get; set; }

        [Display(Name = "Enter Name")]
        public string Name { get; set; }
        
        [Display(Name = "Enter Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        [Display(Name = "Is Online")]
        public bool IsOnline { get; set; }
        
        [Display(Name = "Enter DOJ")]
        [DataType(DataType.Date)]
        public DateTime DateOfJoining { get; set; }
    }
}