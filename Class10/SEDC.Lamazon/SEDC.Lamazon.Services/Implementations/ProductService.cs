using AutoMapper;
using SEDC.Lamazon.DataAccess;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Enitites;
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
        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;
        }

        public void CreateProduct(CreateProductViewModel createProductViewModel)
        {
            var productCategory = _productCategoryRepository.Get(x => x.Id == createProductViewModel.ProductCategoryId);

            if(productCategory == null)
            {
                throw new Exception();
            }

            //var product = createProductViewModel.ToProduct(StaticDb.ProductId++, productCategory);
            var product = _mapper.Map<Product>(createProductViewModel);

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
            var products = _productRepository.GetAll(inludeProperties: "ProductCategory");

            return _mapper.Map<List<ProductViewModel>>(products);       
        }

        public UpdateProductViewModel GetProducForEditById(int id)
        {
            var product = _productRepository.Get(x => x.Id == id, "ProductCategory");

            return _mapper.Map<UpdateProductViewModel>(product);
        }

        public ProductViewModel GetProductById(int id)
        {
           var product = _productRepository.Get(x => x.Id == id, "ProductCategory");

            return _mapper.Map<ProductViewModel>(product);
        }

        public void UpdateProduct(UpdateProductViewModel updateProductViewModel)
        {
            var productCategory = _productCategoryRepository.Get(x => x.Id == updateProductViewModel.ProductCategoryId);

            if (productCategory == null)
            {
                throw new Exception();
            }

            var product = _mapper.Map<Product>(updateProductViewModel);
            
            _productRepository.Update(product);
        }
    }
}
