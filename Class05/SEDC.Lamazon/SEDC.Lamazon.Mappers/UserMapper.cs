using SEDC.Lamazon.DataAccess;
using SEDC.Lamazon.Domain.Enitites;
using SEDC.Lamazon.ViewModels.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Mappers
{
    public static class UserMapper
    {
        public static UserViewModel ToUserViewModel(this User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role.ToRoleViewModel(),
            };
        }

        public static User ToUser(this UserViewModel user)
        {
            return new User
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                Role = user.Role.ToRole()
            };
        }

        public static User ToUser(this RegisterUserViewModel registerUserViewModel, int nextId)
        {
            return new User
            {
                Id = nextId,
                FullName = registerUserViewModel.FullName,
                Email = registerUserViewModel.Email,
                Password = registerUserViewModel.Password,
                Role = StaticDb.Roles.FirstOrDefault(x => x.Key == "user"),
            };
        }

        public static User ToUser(this UpdateUserViewModel updateUserViewModel)
        {
            return new User
            {
                Id = updateUserViewModel.Id,
                FullName = updateUserViewModel.FullName,
                Email = updateUserViewModel.Email,
                Password = updateUserViewModel.Password,
                Role = updateUserViewModel.Role.ToRole()
            };
        }
    }
}
