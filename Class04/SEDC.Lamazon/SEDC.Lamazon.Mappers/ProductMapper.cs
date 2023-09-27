using SEDC.Lamazon.Domain.Enitites;
using SEDC.Lamazon.ViewModels.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Mappers
{
    public static class ProductMapper
    {

        public static ProductViewModel ToProductViewModel (this Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                ProductCategory = product.ProductCategory.ToProductCategoryViewModel(),
            };
        }

        public static UpdateProductViewModel ToUpdateProductViewModel(this Product product)
        {
            return new UpdateProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                ProductCategoryId = product.ProductCategory.Id,
            };
        }

        public static Product ToProduct(this ProductViewModel productViewModel)
        {
            return new Product
            {
                Id = productViewModel.Id,
                Name = productViewModel.Name,
                Description = productViewModel.Description,
                ImageUrl = productViewModel.ImageUrl,
                Price = productViewModel.Price,
                ProductCategory = productViewModel.ProductCategory.ToProductCategory()
            };
        }

        public static Product ToProduct(this CreateProductViewModel createProductViewModel, int nextId, ProductCategory productCategory)
        {
            return new Product
            {
                Id = nextId,
                Name = createProductViewModel.Name,
                Description = createProductViewModel.Description,
                ImageUrl = createProductViewModel.ImageUrl,
                Price = createProductViewModel.Price,
                ProductCategory = productCategory
            };
        }

        public static Product ToProduct(this UpdateProductViewModel updateProductViewModel, ProductCategory productCategory)
        {
            return new Product
            {
                Id = updateProductViewModel.Id,
                Name = updateProductViewModel.Name,
                Description = updateProductViewModel.Description,
                ImageUrl = updateProductViewModel.ImageUrl,
                Price = updateProductViewModel.Price,
                ProductCategory = productCategory
            };
        }

        public static Product ToProduct(this ProductViewModel productViewModel, int nextId)
        {
            return new Product
            {
                Id = nextId,
                Name = productViewModel.Name,
                Description = productViewModel.Description,
                ImageUrl = productViewModel.ImageUrl,
                Price = productViewModel.Price,
                ProductCategory = productViewModel.ProductCategory.ToProductCategory()
            };
        }
    }
}
