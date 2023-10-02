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
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);

            builder.HasData(
                 new ProductCategory
                 {
                     Id = 1,
                     Name = "Food"
                 },
                new ProductCategory
                {
                    Id = 2,
                    Name = "Drinks"
                },
                new ProductCategory
                {
                    Id = 3,
                    Name = "Books"
                }
                );
        }
    }
}
