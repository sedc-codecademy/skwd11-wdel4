using SEDC.Lamazon.DataAccess;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Mappers;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }


        public void CreateProduct(ProductViewModel productViewModel)
        {
            var product = productViewModel.ToProduct(StaticDb.ProductId++);
            int productId = _productRepository.Insert(product);
            if(productId <= 0)
            {
                throw new Exception($"Something went wrong while saving the new product");
            }
        }

        public void DeleteProductById(int id)
        {
            _productRepository.DeleteById(id);
        }

        public List<ProductViewModel> GetAllProducts()
        {
            var products = _productRepository.GetAll();

            return products.Select(x => x.ToProductViewModel()).ToList();
        }

        public ProductViewModel GetProductById(int id)
        {
           var product = _productRepository.GetById(id);
            return product.ToProductViewModel();
        }

        public void UpdateProduct(ProductViewModel productViewModel)
        {
            var product = productViewModel.ToProduct();
            _productRepository.Update(product);
        }
    }
}
