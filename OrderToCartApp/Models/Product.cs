using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OrderToCartApp.Models
{
    public class Product
    {
        [Display(Name = "Product Code")]
        [Required(ErrorMessage = "{0} Can't be blank")]
        [Range(1, double.MaxValue)]
        public int ProductCode { get; set; }

        [Display(Name = "Product Price")]
        [Required(ErrorMessage = "{0} Can't be blank")]
        [Range(1, double.MaxValue)]
        public double price { get; set; }

        [Display(Name = "Product Qunatity")]
        [Required(ErrorMessage = "{0} Can't be blank")]
        [Range(1, double.MaxValue)]
        public int Quantity { get; set; }

    }
}
