using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.DataAccess.Implementations
{
    public class ProductCategoryRepository : GenericRepository<ProductCategory>, IProductCategoryRepository
    {
        private readonly IProductRepository _productRepository;

        public ProductCategoryRepository(IProductRepository productRepository) : base(StaticDb.ProductCategories)
        {
            _productRepository = productRepository;
        }

        public override void DeleteById(int id)
        {
            var productCategoty = _entitites.FirstOrDefault(p => p.Id == id);

            if(productCategoty != null)
            {
                var products = _productRepository.GetAll().Where(x => x.ProductCategory.Id == id).ToList();

                foreach(var product in products)
                {
                    _productRepository.DeleteById(product.Id);
                }

                _entitites.Remove(productCategoty);
            }
        }


        //public void DeleteById(int id)
        //{
        //    var productCategory = StaticDb.ProductCategories.FirstOrDefault(x => x.Id == id);
        //    if (productCategory == null)
        //    {
        //        throw new Exception($"ProductCategory with id {id} was not found");
        //    }

        //    StaticDb.ProductCategories.Remove(productCategory);
        //}

        //public List<ProductCategory> GetAll()
        //{
        //    return StaticDb.ProductCategories;
        //}

        //public ProductCategory GetById(int id)
        //{
        //    return StaticDb.ProductCategories.FirstOrDefault(x => x.Id == id);
        //}

        //public int Insert(ProductCategory entity)
        //{
        //    StaticDb.ProductCategories.Add(entity);
        //    return entity.Id;
        //}

        //public void Update(ProductCategory entity)
        //{
        //    var productCategory = StaticDb.ProductCategories.FirstOrDefault(x => x.Id == entity.Id);
        //    if (productCategory == null)
        //    {
        //        throw new Exception($"ProductCategory with id {entity.Id} was not found");
        //    }

        //    int index = StaticDb.ProductCategories.IndexOf(productCategory);
        //    StaticDb.ProductCategories[index] = entity;
        //}
    }
}
