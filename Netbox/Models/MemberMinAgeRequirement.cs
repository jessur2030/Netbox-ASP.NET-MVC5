using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Netbox.Models
{
    public class MemberMinAgeRequirement : ValidationAttribute
    {
        //Custom validation for Birthdate field
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == MembershipType.Unknown ||
                customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;
            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is require.");
            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;
            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Must be at least 18 years old to go in a membership.");

        }
    }
}