using SEDC.Lamazon.ViewModels.Models.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Services.Interfaces
{
    public interface IProductCategoryService
    {
        List<ProductCategoryViewModel> GetAllProductCategories();
        ProductCategoryViewModel GetProductCategoryById(int id);
        void CreateProductCategory(ProductCategoryViewModel productCategoryViewModel);
        void UpdateProductCategory(ProductCategoryViewModel productCategoryViewModel);
        void DeleteProductCategoryById(int id);
    }
}
