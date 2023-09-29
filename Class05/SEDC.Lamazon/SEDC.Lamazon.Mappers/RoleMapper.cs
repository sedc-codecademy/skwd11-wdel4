using SEDC.Lamazon.Domain.Enitites;
using SEDC.Lamazon.ViewModels.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Mappers
{
    public static class RoleMapper
    {
        public static RoleViewModel ToRoleViewModel(this Role role)
        {
            return new RoleViewModel
            {
                Id = role.Id,
                Key = role.Key,
                Name = role.Name,
            };
        }

        public static Role ToRole(this RoleViewModel role)
        {
            return new Role
            {
                Id = role.Id,
                Key = role.Key,
                Name = role.Name,
            };
        }
    }
}
