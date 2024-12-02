using System.ComponentModel.DataAnnotations;

namespace OrderToCartApp.CustomValidations
{
    public class MinimumDateValidatorAttribute : ValidationAttribute
    {


        public MinimumDateValidatorAttribute() {       
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                DateTime orderDate = (DateTime)value;
                const string minimumDateTimeString = "2000-01-01";
                DateTime minimumDateTime = DateTime.ParseExact(minimumDateTimeString, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                
                if(orderDate < minimumDateTime)
                {
                    return new ValidationResult("Order Date should be greater than 2000-01-01", new string[] { nameof(validationContext.MemberName) });
                }

                return ValidationResult.Success;

            }
            return null;
        }
    }
}
