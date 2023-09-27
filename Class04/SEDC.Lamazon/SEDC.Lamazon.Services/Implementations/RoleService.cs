using SEDC.Lamazon.DataAccess.Interfaces;
using SEDC.Lamazon.Mappers;
using SEDC.Lamazon.Services.Interfaces;
using SEDC.Lamazon.ViewModels.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Services.Implementations
{
    public class RoleService : IRoleService
    {

        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public List<RoleViewModel> GetAllRoles()
        {
            var roles = _roleRepository.GetAll();
            return roles.Select(x => x.ToRoleViewModel()).ToList();
        }

        public RoleViewModel GetRoleById(int id)
        {

            var role = _roleRepository.GetById(id);
            return role.ToRoleViewModel();
        }
    }
}
