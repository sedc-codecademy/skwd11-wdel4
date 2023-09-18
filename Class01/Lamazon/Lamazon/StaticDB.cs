using Lamazon.Models.Entities;

namespace Lamazon
{
    public static class StaticDB
    {

        public static List<ProductCategory> Categories = new List<ProductCategory>()
        {
            new ProductCategory
            {
                Id = 1,
                Name = "Books",
            },
            new ProductCategory
            {
                Id = 2,
                Name = "Drinks",
            },
            new ProductCategory
            {
                Id = 3,
                Name = "Food",
            },
            new ProductCategory
            {
                Id = 4,
                Name = "Electronics",
            },
            new ProductCategory
            {
                Id = 5,
                Name = "Other",
            },
        };


        public static List<Product> Products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Zoki Poki",
                Description = "Children book",
                //Category = Models.Enums.CategoryEnum.Books,
                Category = Categories.FirstOrDefault(x => x.Id == 1)!,
                Price = 60
            },
            new Product
            {
                Id = 2,
                Name = "Coca Cola",
                Description = "Fizzy Dring",
               Category = Categories.FirstOrDefault(x => x.Id == 2)!,
                Price = 10
            },
            new Product
            {
                Id = 3,
                Name = "Laptop",
                Description = "test test",
                Category = Categories.FirstOrDefault(x => x.Id == 4)!,
                Price = 60
            },
            new Product
            {
                Id = 4,
                Name = "Backpack",
                Description = "test test",
                Category = Categories.FirstOrDefault(x => x.Id == 5)!,
                Price = 120
            },
        };
    }
}
