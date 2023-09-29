﻿using AutoMapper;
using SEDC.Lamazon.DataAccess;
using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Enitites;
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
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper )
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public List<UserViewModel> GetAllUsers()
        {
            var users =_userRepository.GetAll();
            return _mapper.Map<List<UserViewModel>>(users);
         
        }

        public UserViewModel GetUserById(int id)
        {
            var user = _userRepository.GetById(id);
            return _mapper.Map<UserViewModel>(user);
        }

        public UserViewModel LoginUser(LoginUserViewModel loginUserViewModel)
        {
            var user = _userRepository.LoginUser(loginUserViewModel);

            if(user is null)
            {
                throw new Exception("Login credentials do not match any user");
            }

            return _mapper.Map<UserViewModel>(user);
        }

        public void RegisterUser(RegisterUserViewModel registerUserViewModel)
        {
            var user = _mapper.Map<User>(registerUserViewModel);
            var userId = _userRepository.Insert(user);
            if(userId <= 0)
            {
                throw new Exception("Something when wrong");
            }
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
