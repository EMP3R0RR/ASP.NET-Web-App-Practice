using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; //must needed for ValidationAttribute and custom validation classes
using System.Linq;
using System.Web;
using Test_Application.Models;

namespace Test_Application.CustomValidations
{
    public class EmailEqualsID : ValidationAttribute // annotate the class name and pass the error message on the main class in class levels
    {
        public override bool IsValid(object value)
        {
            var model = value as FormValidation; // Replace with your actual model class name
            if (model == null) return true; // Skip if not the right model type

            if (string.IsNullOrEmpty(model.ID) || string.IsNullOrEmpty(model.Email))
                return true; // Leave null/empty checks to [Required]

            string expectedEmail = $"{model.ID}@student.aiub.edu";
            return string.Equals(model.Email, expectedEmail, StringComparison.OrdinalIgnoreCase);
        }

       

    }
}