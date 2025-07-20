using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Test_Application.Models
{
    public class FormValidation
    {
        [Required]
        [StringLength(100, ErrorMessage = "Name cannot be longer than 50 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name can only contain letters and spaces.")]
        public string Name { get; set; }


        [Required]
        [RegularExpression(@"^\S+$", ErrorMessage = "Username cannot contain spaces")]
        public string UName { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}-\d{5}-\d{1}$", ErrorMessage = "ID must be in the format NN-NNNNN-N (e.g., 20-42437-1)")]
        public string ID { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        
        [Required]

        public DateTime DOB { get; set; }
    }
}