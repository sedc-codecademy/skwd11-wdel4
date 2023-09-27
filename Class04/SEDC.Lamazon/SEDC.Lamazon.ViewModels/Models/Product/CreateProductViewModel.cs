using SEDC.Lamazon.ViewModels.Models.ProductCategory;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.ViewModels.Models.Product
{
    public class CreateProductViewModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(250)]
        public string Description { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "An Id can be only positive")]
        public int ProductCategoryId { get; set; }
    }
}
