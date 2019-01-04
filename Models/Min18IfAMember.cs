using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.ViewModels;
namespace Vidly.Models
{
    public class Min18IfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;
            if (customer.MemberShipTypeId == MembershipTypes.Unknown ||
                customer.MemberShipTypeId == MembershipTypes.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if (customer.BirthDate==null)
            {
                return new ValidationResult("BirthDate is Required.");
            }

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;
            return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customer should be 18 years old to be a member.");

          
        }
    }
}