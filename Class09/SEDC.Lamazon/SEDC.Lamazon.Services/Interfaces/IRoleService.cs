using SEDC.Lamazon.ViewModels.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Services.Interfaces
{
    public interface IRoleService
    {
        List<RoleViewModel> GetAllRoles();
        RoleViewModel GetRoleById(int id);
    }
}
