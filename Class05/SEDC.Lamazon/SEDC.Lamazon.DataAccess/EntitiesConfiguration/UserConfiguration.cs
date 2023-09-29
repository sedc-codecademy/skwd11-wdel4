using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SEDC.Lamazon.Domain.Enitites;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.DataAccess.EntitiesConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(100);
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(255);

            builder.HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId);

            builder.HasData(
                 new User
                 {
                     Id = 1,
                     Email = "admin@gmail.com",
                     FullName = "Admin Test",
                     Password = "pas123",
                     RoleId = 1
                 },
                new User
                {
                    Id = 2,
                    Email = "user@gmail.com",
                    FullName = "User Test",
                    Password = "pas456",
                    RoleId = 2
                });

        }
    }
}
