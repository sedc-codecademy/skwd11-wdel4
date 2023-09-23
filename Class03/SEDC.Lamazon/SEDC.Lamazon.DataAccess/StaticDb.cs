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

            Products = new List<Product>()
            {
                new Product
                {
                    Id = 1,
                    Name = "Meatball Marinara",
                    Description = "The Meatball Marinara is iconic to the Subway® brand and this favourite comes with tender beef meatballs smothered in a rich marinara sauce.",
                    ImageUrl = "https://www.subway.com/ns/images/menu/UKM/ENG/036_SubMeatball_WD.jpg",
                    Price = 10M,
                    ProductCategory = ProductCategories.First(x => x.Id == 1),

                },
                new Product
                {
                    Id = 2,
                    Name = "Coca Cola",
                    Description = "Coca-Cola, or Coke, is a carbonated soft drink manufactured by the Coca-Cola Company. Originally marketed as a temperance drink and intended as a patent medicine, it was invented in the late 19th century by John Stith Pemberton in Atlanta, Georgia.",
                    ImageUrl = "https://th.bing.com/th/id/R.f7c80ce3bc654933f2fb4a3ffbaff719?rik=kZZnQCt3Fqm0aw&pid=ImgRaw&r=0",
                    Price = 1.35M,
                    ProductCategory = ProductCategories.First(x => x.Id == 2)
                },
                new Product
                {
                    Id = 3,
                    Name = "The Pragmatic Programmer",
                    Description = "The Pragmatic Programmer: From Journeyman to Master is a book about computer programming and software engineering, written by Andrew Hunt and David Thomas and published in October 1999.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/8/8f/The_pragmatic_programmer.jpg/220px-The_pragmatic_programmer.jpg",
                    Price = 39.99M,
                    ProductCategory = ProductCategories.First(x => x.Id == 3)
                },
                new Product
                {
                    Id = 4,
                    Name = "Design Patterns: Elements of Reusable Object-Oriented Software",
                    Description = "Design Patterns: Elements of Reusable Object-Oriented Software (1994) is a software engineering book describing software design patterns. The book was written by Erich Gamma, Richard Helm, Ralph Johnson, and John Vlissides, with a foreword by Grady Booch. The book is divided into two parts, with the first two chapters exploring the capabilities and pitfalls of object-oriented programming, and the remaining chapters describing 23 classic software design patterns.",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51szD9HC9pL._SX395_BO1,204,203,200_.jpg",
                    Price = 53.79M,
                    ProductCategory = ProductCategories.First(x => x.Id == 3)
                }
            };
            ProductId = 5;

        }

        public static List<ProductCategory> ProductCategories { get; set; }
        public static List<Product> Products { get; set; }

        public static int ProductCategoryId {get; set;}
        public static int ProductId { get; set; }

    }
}
