using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dappercrud.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductCode { get; set; }
        [Required]
        public int ProductQty { get; set; }
        [Required]
        public decimal ProductWeight { get; set; }
        public string ProductDesc { get; set; }

    }
}