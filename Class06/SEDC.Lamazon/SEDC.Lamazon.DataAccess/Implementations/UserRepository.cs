using Microsoft.EntityFrameworkCore;
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
        public UserRepository(LamazonDbContext dbContext) : base(dbContext)
        {
        }

        public override List<User> GetAll()
        {
            return _dbSet.Include(x => x.Role).ToList();
        }

        public List<User> GetAll(int userId)
        {
            return _dbSet.Include(x => x.Role).Where(x => x.Id != userId).ToList();
        }

        public User LoginUser(string email)
        {
            var user = _dbSet.Include(x => x.Role).FirstOrDefault(x => x.Email == email);

            return user;
        }
    }
}
