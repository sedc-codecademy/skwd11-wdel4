﻿using SEDC.Lamazon.ViewModels.Models.Product;
using SEDC.Lamazon.ViewModels.Models.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Services.Interfaces
{
    public interface IProductService
    {
        List<ProductViewModel> GetAllProducts();
        ProductViewModel GetProductById(int id);
        UpdateProductViewModel GetProducForEditById(int id);
        void CreateProduct(CreateProductViewModel createProductViewModel);
        void UpdateProduct(UpdateProductViewModel updateProductViewModel);
        void DeleteProductById(int id);
    }
}
