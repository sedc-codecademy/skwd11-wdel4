using Microsoft.AspNetCore.Identity;
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

        private PasswordHasher<User> passwordHasher = new PasswordHasher<User>();

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Email).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(100);
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(255);

            builder.HasOne(x => x.Role)
                .WithMany(x => x.Users)
                .HasForeignKey(x => x.RoleId);

            var user1 = new User
            {
                Id = 1,
                Email = "admin@gmail.com",
                FullName = "Admin Test",
                Password = "pas123",
                RoleId = 1,
                PhoneNumber = "123456789",
                StreetAddress = "Random Street 1",
                City = "City1",
                State = "State1",
                PostalCode = "10001"
            };
            user1.Password = passwordHasher.HashPassword(user1, user1.Password);

            var user2 = new User
            {
                Id = 2,
                Email = "user@gmail.com",
                FullName = "User Test",
                Password = "pas456",
                RoleId = 2,
                PhoneNumber = "987654321",
                StreetAddress = "Random Street 2",
                City = "City2",
                State = "State2",
                PostalCode = "10002"
            };
            user2.Password = passwordHasher.HashPassword(user2, user2.Password);

            builder.HasData(
                user1,
                user2
              );

        }
    }
}
