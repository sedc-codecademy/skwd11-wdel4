using Microsoft.EntityFrameworkCore;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.DataAccess.Implementations
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(LamazonDbContext dbContext) : base(dbContext)
        {
                
        }

        //public override List<Product> GetAll()
        //{
        //    return _dbSet.Include(x => x.ProductCategory).ToList();
        //}

        //public override Product GetById(int id)
        //{
        //    return _dbSet.Include(x => x.ProductCategory).FirstOrDefault(x => x.Id == id);
        //}
    }
}
