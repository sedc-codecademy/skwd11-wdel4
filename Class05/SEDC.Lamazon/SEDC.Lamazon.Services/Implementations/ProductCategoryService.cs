using AutoMapper;
using SEDC.Lamazon.DataAccess;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Enitites;
using SEDC.Lamazon.Mappers;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.Shared.Exceptions.ProductCategory;
using SEDC.Lamazon.ViewModels.Models.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Services.Implementations
{
    public class ProductCategoryService : IProductCategoryService
    {

        private readonly IProductCategoryRepository _productCategoryRepository;
        private readonly IMapper _mapper;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository, IMapper mapper)
        {
            _productCategoryRepository = productCategoryRepository;
            _mapper = mapper;

        }
        public void CreateProductCategory(ProductCategoryViewModel productCategoryViewModel)
        {
            ValidateCategory(productCategoryViewModel.Name);
            //var productCategory = productCategoryViewModel.ToProductCategory(StaticDb.ProductCategoryId++);
            var productCategory = _mapper.Map<ProductCategory>(productCategoryViewModel);

            int producCategoryId = _productCategoryRepository.Insert(productCategory);

            if (producCategoryId <= 0)
            {
                throw new Exception($"Something went wrong while saving the new category");
            } 
        }

        public List<ProductCategoryViewModel> GetAllProductCategories()
        {
            var productCategories = _productCategoryRepository.GetAll();

            return _mapper.Map<List<ProductCategoryViewModel>>(productCategories);

        }

        public ProductCategoryViewModel GetProductCategoryById(int id)
        {
            var productCategory = _productCategoryRepository.GetById(id);
            return productCategory.ToProductCategoryViewModel();
        }

        public void UpdateProductCategory(ProductCategoryViewModel productCategoryViewModel)
        {
            ValidateCategory(productCategoryViewModel.Name);
            // var productCategory = productCategoryViewModel.ToProductCategory();
            var productCategory = _mapper.Map<ProductCategory>(productCategoryViewModel);
            _productCategoryRepository.Update(productCategory);
        }

        public void DeleteProductCategoryById(int id)
        {
            _productCategoryRepository.DeleteById(id);
        }

        private void ValidateCategory(string name)
        {

            var productCategory = _productCategoryRepository.GetByName(name);

            if(productCategory is not null)
            {
                throw new ProductCategoryException($"Product Category {name} already exists");
            }

            var productCategoryContains = _productCategoryRepository.GetByNameContains(name);

            if (productCategoryContains is not null)
            {
                throw new ProductCategoryException($"Product Category {name} is too simmilar to an already existing category");
            }
        }
    }
}
