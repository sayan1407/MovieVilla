using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MovieVilla.Models
{
    public class MinAge18YearsCheck : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            var Age = DateTime.Now.Year - customer.BirthDate.Value.Year;
            return (Age >= 18) ? ValidationResult.Success : new ValidationResult("Customer age can't be less than 18");

        }
    }
}