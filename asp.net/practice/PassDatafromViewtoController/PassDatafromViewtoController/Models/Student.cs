using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PassDatafromViewtoController.Models
{
    public class Student
    {
        [Display(Name = "Enter Id")]
        [Required]
        public int Id { get; set; }

        [Display(Name = "Enter First Name")]
        [Required]
        public string FirstName { get; set; }
        
        [Display(Name = "Enter Last Name")]
        [Required]
        public string LastName { get; set; }
        
        [Display(Name = "Enter Email")]
        [DataType(DataType.EmailAddress)]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Display(Name = "Enter Mobile Number")]
        [DataType(DataType.PhoneNumber)]
        [Required]
        public string Mobile { get; set; }
    }
}