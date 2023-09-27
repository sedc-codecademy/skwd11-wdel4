using SEDC.Lamazon.ViewModels.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Services.Interfaces
{
    public interface IUserService
    {
        List<UserViewModel> GetAllUsers();
        UserViewModel GetUserById(int id);
        void RegisterUser(RegisterUserViewModel registerUserViewModel);
        UserViewModel LoginUser(LoginUserViewModel loginUserViewModel);
        void UpdateUser(UpdateUserViewModel updateUserViewModel);
        void DeleteUserById(int id);
    }
}
