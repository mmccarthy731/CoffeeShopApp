//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CoffeeShopApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Item
    {
        [Required(ErrorMessage = "Product Name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Product Description is required!")]
        public string Description { get; set; }

        [RegularExpression("^[0-9]{1,}$", ErrorMessage = "Quantity must be an integer value.")]
        [Required(ErrorMessage = "Stock Quantity is a required field.")]
        public short Quantity { get; set; }

        [RegularExpression("^[0-9.]{1,}$", ErrorMessage = "Price must be an integer or decimal value.")]
        [Required(ErrorMessage = "Price is a required field.")]
        public decimal Price { get; set; }
    }
}
