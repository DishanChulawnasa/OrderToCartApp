using System.ComponentModel.DataAnnotations;
using OrderToCartApp.Models;

namespace OrderToCartApp.CustomValidations
{
    public class ProductListValidationAttribute :ValidationAttribute
    {
        public ProductListValidationAttribute() { }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null) 
            {
                List<Product> products = (List<Product>)value;

                if (products.Count == 0)
                {

                    return new ValidationResult("Order should have at least one product", new string[] { nameof(validationContext.MemberName) });
                }

                return ValidationResult.Success;
            }

            return null;
        }
           


    }
}
