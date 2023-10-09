using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEDC.Lamazon.Domain.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.DataAccess.EntitiesConfiguration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Key).IsRequired().HasMaxLength(255);

            builder.HasData(
                    new Role
                     {
                         Id = 1,
                         Key = "admin",
                         Name = "Admin"
                     },
                    new Role
                    {
                        Id = 2,
                        Key = "user",
                        Name = "User"
                    }
                );
        }
    }
}
