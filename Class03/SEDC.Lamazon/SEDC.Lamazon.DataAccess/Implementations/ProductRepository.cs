using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.DataAccess.Implementations
{
    public class ProductRepository : IProductRepository
    {
        public void DeleteById(int id)
        {
            var product = StaticDb.Products.FirstOrDefault(x => x.Id == id);
            if (product == null)
            {
                throw new Exception($"ProductCategory with id {id} was not found");
            }

            StaticDb.Products.Remove(product);
        }

        public List<Product> GetAll()
        {
            return StaticDb.Products;
        }

        public Product GetById(int id)
        {
            return StaticDb.Products.FirstOrDefault(x => x.Id == id);
        }

        public int Insert(Product entity)
        {
            StaticDb.Products.Add(entity);
            return entity.Id;
        }

        public void Update(Product entity)
        {
            var product = StaticDb.Products.FirstOrDefault(x => x.Id == entity.Id);
            if (product == null)
            {
                throw new Exception($"Product with id {entity.Id} was not found");
            }

            int index = StaticDb.Products.IndexOf(product);
            StaticDb.Products[index] = entity;
        }
    }
}
