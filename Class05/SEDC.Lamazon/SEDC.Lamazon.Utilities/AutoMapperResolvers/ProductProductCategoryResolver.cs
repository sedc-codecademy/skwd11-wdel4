using AutoMapper;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Enitites;
using SEDC.Lamazon.ViewModels.Models.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Utilities.AutoMapperResolvers
{
    public class ProductProductCategoryResolver : IValueResolver<CreateProductViewModel, Product, ProductCategory>
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductProductCategoryResolver(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public ProductCategory Resolve(CreateProductViewModel source, Product destination, ProductCategory destMember, ResolutionContext context)
        {
            var productCategory = _productCategoryRepository.GetById(source.ProductCategoryId);
            return productCategory;

        }
    }
}
