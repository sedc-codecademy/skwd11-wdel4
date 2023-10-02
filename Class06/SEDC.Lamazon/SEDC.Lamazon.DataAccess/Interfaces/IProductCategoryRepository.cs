﻿using SEDC.Lamazon.Domain.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.DataAccess.Interfaces
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        ProductCategory GetByName(string name);
        ProductCategory GetByNameContains(string name);
    }
}
