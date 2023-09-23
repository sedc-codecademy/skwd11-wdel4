using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.ViewModels.Models.ProductCategory
{
    public class ProductCategoryViewModel
    {
        public int Id { get; set; }
        [MinLength(2, ErrorMessage = "The name can't be shorter than 2 characters")]
        public string Name { get; set; }
    }
}
