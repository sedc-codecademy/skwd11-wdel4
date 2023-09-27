using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Domain.Enitites;
using SEDC.Lamazon.ViewModels.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.DataAccess.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository() : base(StaticDb.Users)
        {
        }

        public User LoginUser(LoginUserViewModel loginUserViewModel)
        {
            var user = _entitites.FirstOrDefault(x => x.Email == loginUserViewModel.Email && x.Password == loginUserViewModel.Password);

            return user;
        }
    }
}
