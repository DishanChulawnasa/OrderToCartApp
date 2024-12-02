using OrderToCartApp.CustomValidations;
using System.ComponentModel.DataAnnotations;

namespace OrderToCartApp.Models
{
    public class Order
    {
        [Display(Name = "Order Number")]
        public int? OrderNo { get; set; }

        [Display(Name = "Order Date")]
        [MinimumDateValidator]
        [Required(ErrorMessage = "{0} can't be blank")]        
        public DateTime OrderDate { get; set; }

        [Display(Name = "Invoice Price")]
        [Required(ErrorMessage = "{0} Can't be blank")]
        [InvoicePriceValidator]
        [Range(1, double.MaxValue)]
        public double InvoicePrice { get; set; }

        [ProductListValidation]
        public List<Product> Products { get; set;}

    }
}
