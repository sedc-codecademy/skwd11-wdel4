using SEDC.Lamazon.Domain.Enitites;
using SEDC.Lamazon.ViewModels.Models.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Mappers
{
    public static class ProductCategoryMapper
    {
        public static ProductCategoryViewModel ToProductCategoryViewModel(this ProductCategory productCategory)
        {
            return new ProductCategoryViewModel
            {
                Id = productCategory.Id,
                Name = productCategory.Name,
            };
        }

        public static ProductCategory ToProductCategory(this ProductCategoryViewModel productCategoryViewModel, int newId)
        {
            return new ProductCategory
            {
                Id = newId,
                Name = productCategoryViewModel.Name
            };
        }
    }
}
