using AutoMapper;
using Microsoft.AspNetCore.Identity;
using SEDC.Lamazon.DataAccess;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Enitites;
using SEDC.Lamazon.Mappers;
using SEDC.Lamazon.Services.Helpers;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.Shared.Exceptions.User;
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
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IRoleRepository roleRepository, IMapper mapper )
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public List<UserViewModel> GetAllUsers(int userId)
        {
            var users =_userRepository.GetAll(userId);
            return _mapper.Map<List<UserViewModel>>(users);
         
        }

        public UserViewModel GetUserById(int id)
        {
            var user = _userRepository.GetById(id);
            return _mapper.Map<UserViewModel>(user);
        }

        public UserViewModel LoginUser(LoginUserViewModel loginUserViewModel)
        {
            var user = _userRepository.LoginUser(loginUserViewModel.Email);

            if(user is null)
            {
                throw new UserNotFoundExcpetion("Login credentials do not match any user");
            }
            var passwordVericationResult = PasswordHashHelper.VerifyHashedPassword(user, loginUserViewModel.Password);

            if(passwordVericationResult == PasswordVerificationResult.Failed)
            {
                throw new UserException("Wrong Login Credentials");
            }

            return _mapper.Map<UserViewModel>(user);
        }

        public void RegisterUser(RegisterUserViewModel registerUserViewModel)
        {
            var user = _mapper.Map<User>(registerUserViewModel);
            PasswordHashHelper.HashPassword(user);

            if(registerUserViewModel.Password != registerUserViewModel.ConfirmationPassword)
            {
                throw new UserException("Passwrods must match");
            }

            var role = _roleRepository.GetById(registerUserViewModel.RoleId);

            if(role == null)
            {
                var userRole = _roleRepository.GetById(2);
                if (role == userRole)
                {
                    throw new Exception("Role does not exist");
                }
                user.Role = userRole;
            }
            else
            {
                user.Role = role;
            } 

            _userRepository.Insert(user);
      
        }

        public void UpdateUser(UpdateUserViewModel updateUserViewModel)
        {
            var user = _mapper.Map<User>(updateUserViewModel);
            _userRepository.Update(user);
        }

        public void DeleteUserById(int id)
        {
            _userRepository.DeleteById(id);
        }
    }
}
