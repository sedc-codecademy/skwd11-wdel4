using SEDC.Lamazon.Domain.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.DataAccess
{
    public static class StaticDb
    {
        static StaticDb()
        {
            ProductCategories = new List<ProductCategory>()
            {
                new ProductCategory
                {
                    Id = 1,
                    Name = "Food"
                },
                new ProductCategory
                {
                    Id =2,
                    Name = "Drinks"
                },
                new ProductCategory
                {
                    Id = 3,
                    Name = "Books"
                },
            };
            ProductCategoryId = 4;

        }

        public static List<ProductCategory> ProductCategories { get; set; }

        public static int ProductCategoryId {get; set;}

    }
}
