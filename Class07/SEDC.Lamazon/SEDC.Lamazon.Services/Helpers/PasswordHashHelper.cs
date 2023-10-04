using Microsoft.AspNetCore.Identity;
using SEDC.Lamazon.Domain.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Services.Helpers
{
    public static class PasswordHashHelper
    {
        private static PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

        public static void HashPassword(User user)
        {
            user.Password = _passwordHasher.HashPassword(user, user.Password);
        }
       
        public static PasswordVerificationResult VerifyHashedPassword(User user, string password)
        {
            return _passwordHasher.VerifyHashedPassword(user, user.Password, password);
        }

    }
}
