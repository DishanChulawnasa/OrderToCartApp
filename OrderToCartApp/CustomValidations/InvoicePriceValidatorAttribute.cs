using System.ComponentModel.DataAnnotations;
using System.Reflection;
using OrderToCartApp.Models;

namespace OrderToCartApp.CustomValidations
{
    public class InvoicePriceValidatorAttribute : ValidationAttribute
    {
       
        public InvoicePriceValidatorAttribute() { }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null) 
            { 
                PropertyInfo? OtherProperty = validationContext.ObjectType.GetProperty(nameof(Order.Products));
            
                if (OtherProperty != null)
                {
                    List<Product> Products = (List<Product>)OtherProperty.GetValue(validationContext.ObjectInstance)!;

                    double CalculatedPrice = 0;
                    foreach (Product Product in Products)
                    {
                        CalculatedPrice += Product.price * Product.Quantity;
                    }

                    double returnPrice = (double)value;

                    if (CalculatedPrice != returnPrice)
                    {
                        return new ValidationResult("Invoice Price should be equal to the sum of all products", new string[] { nameof(validationContext.MemberName) });
                    }

                }
                else
                {
                    return new ValidationResult("No produts to validate Invoice Price", new string[] { nameof(validationContext.MemberName) });
                }
                
                return ValidationResult.Success;
            
            }
            else
            {
                return null;
            }
        }

    }

}
