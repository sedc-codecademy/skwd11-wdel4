using AutoMapper;
using SEDC.Lamazon.DataAccess;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Enitites;
using SEDC.Lamazon.Mappers;
using SEDC.Lamazon.Services.Interfaces;
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
            var productCategory = productCategoryViewModel.ToProductCategory(StaticDb.ProductCategoryId++);
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

            //return productCategories.Select(x => _mapper.Map<ProductCategoryViewModel>(x)).ToList();

            //return productCategories.Select(x => x.ToProductCategoryViewModel()).ToList();
        }

        public ProductCategoryViewModel GetProductCategoryById(int id)
        {
            var productCategory = _productCategoryRepository.GetById(id);
            return productCategory.ToProductCategoryViewModel();
        }

        public void UpdateProductCategory(ProductCategoryViewModel productCategoryViewModel)
        {
            // var productCategory = productCategoryViewModel.ToProductCategory();
            var productCategory = _mapper.Map<ProductCategory>(productCategoryViewModel);
            _productCategoryRepository.Update(productCategory);
        }

        public void DeleteProductCategoryById(int id)
        {
            _productCategoryRepository.DeleteById(id);
        }
    }
}
