using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEDC.Lamazon.Domain.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.DataAccess.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(225);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.ImageUrl).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.Price).IsRequired();

            builder.HasOne(x => x.ProductCategory)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.ProductCategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                 new Product
                 {
                     Id = 1,
                     Name = "Meatball Marinara",
                     Description = "The Meatball Marinara is iconic to the Subway® brand and this favourite comes with tender beef meatballs smothered in a rich marinara sauce.",
                     ImageUrl = "https://www.subway.com/ns/images/menu/UKM/ENG/036_SubMeatball_WD.jpg",
                     Price = 10M,
                     ProductCategoryId = 1,

                 },
                new Product
                {
                    Id = 2,
                    Name = "Coca Cola",
                    Description = "Coca-Cola, or Coke, is a carbonated soft drink manufactured by the Coca-Cola Company. Originally marketed as a temperance drink and intended as a patent medicine, it was invented in the late 19th century by John Stith Pemberton in Atlanta, Georgia.",
                    ImageUrl = "https://th.bing.com/th/id/R.f7c80ce3bc654933f2fb4a3ffbaff719?rik=kZZnQCt3Fqm0aw&pid=ImgRaw&r=0",
                    Price = 1.35M,
                    ProductCategoryId = 2
                },
                new Product
                {
                    Id = 3,
                    Name = "The Pragmatic Programmer",
                    Description = "The Pragmatic Programmer: From Journeyman to Master is a book about computer programming and software engineering, written by Andrew Hunt and David Thomas and published in October 1999.",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/8/8f/The_pragmatic_programmer.jpg/220px-The_pragmatic_programmer.jpg",
                    Price = 39.99M,
                    ProductCategoryId = 3,
                },
                new Product
                {
                    Id = 4,
                    Name = "Design Patterns: Elements of Reusable Object-Oriented Software",
                    Description = "Design Patterns: Elements of Reusable Object-Oriented Software (1994) is a software engineering book describing software design patterns. The book was written by Erich Gamma, Richard Helm, Ralph Johnson, and John Vlissides, with a foreword by Grady Booch. The book is divided into two parts, with the first two chapters exploring the capabilities and pitfalls of object-oriented programming, and the remaining chapters describing 23 classic software design patterns.",
                    ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/51szD9HC9pL._SX395_BO1,204,203,200_.jpg",
                    Price = 53.79M,
                    ProductCategoryId = 3
                }
                );
        }
    }
}
