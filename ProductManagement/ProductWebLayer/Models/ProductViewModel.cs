using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProductWebLayer.Models
{
    /// <summary>
    /// This class is to display the product details in view ,
    /// and get the inputs for the product from the user.
   
    /// </summary>
    public class ProductViewModel
    {
        [Required]
        [Display(Name = "Product Title")]
        public string ProductTitle { get; set; }

        [Required]
        [Display(Name = "Product Style")]
        public string ProductStyle { get; set; }

        [Required]
        [Display(Name = "Product Color")]
        public string ProductColor { get; set; }

        [Required]
        [Display(Name = "Product Price")]
        [RegularExpression(@"^\d+\.\d{0,2}$", ErrorMessage = "Error - Please enter the price in double, example 1.22.")]
        [Range(0, 99999.99)]
        public double ProductPrice { get; set; }

        [Required]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Stock must be a number")]
        [Display(Name = "Product Stock")]
        public int ProductStock { get; set; }

        [Required]
        [Display(Name = "Product SKU")]
        public string ProductSku { get; set; }

    }
}