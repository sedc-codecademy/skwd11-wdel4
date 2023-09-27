using SEDC.Lamazon.DataAccess;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Mappers;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository )
        {
            _userRepository = userRepository;
        }

        public List<UserViewModel> GetAllUsers()
        {
            var users =_userRepository.GetAll();
            return users.Select(x => x.ToUserViewModel()).ToList();
        }

        public UserViewModel GetUserById(int id)
        {
            var user = _userRepository.GetById(id);
            return user.ToUserViewModel();
        }

        public UserViewModel LoginUser(LoginUserViewModel loginUserViewModel)
        {
            var user = _userRepository.LoginUser(loginUserViewModel);

            if(user is null)
            {
                throw new Exception("Login credentials do not match any user");
            }

            return user.ToUserViewModel();
        }

        public void RegisterUser(RegisterUserViewModel registerUserViewModel)
        {
            var user = registerUserViewModel.ToUser(StaticDb.UserId++);
            var userId = _userRepository.Insert(user);
            if(userId <= 0)
            {
                throw new Exception("Something when wrong");
            }
        }

        public void UpdateUser(UpdateUserViewModel updateUserViewModel)
        {
            var user = updateUserViewModel.ToUser();
            _userRepository.Update(user);
        }

        public void DeleteUserById(int id)
        {
            _userRepository.DeleteById(id);
        }
    }
}
