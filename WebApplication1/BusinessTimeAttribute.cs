using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1
{
    [AttributeUsage(AttributeTargets.All)]
    public class BusinessTimeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime dateTime)
            {
                var utcTime = dateTime.ToUniversalTime();
                if (utcTime.Hour >= 9 && utcTime.Hour <= 17)
                {
                    if (utcTime < DateTime.UtcNow)
                    {
                        return new ValidationResult("The date and time must be in the future.");
                    }
                }
                else
                {
                    return new ValidationResult("Invalid business time format." + "\n" +
                        "Please enter time between 9 and 17 hours in UTC.");
                }
            }
            else
            {
                return new ValidationResult("Invalid date format.");
            }
            return ValidationResult.Success;
        }
    }
}
