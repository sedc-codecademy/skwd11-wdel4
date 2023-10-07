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

        public ProductCategoryRepository(LamazonDbContext dbContext) : base(dbContext)
        {
            
        }

        //public ProductCategory GetByName(string name)
        //{
        //    return _dbSet.FirstOrDefault(x => x.Name.ToLower() == name.ToLower());
        //}

        //public ProductCategory GetByNameContains(string name)
        //{
        //    return _dbSet.FirstOrDefault(x => x.Name.ToLower().Contains(name.ToLower()));
        //}
    }
}
