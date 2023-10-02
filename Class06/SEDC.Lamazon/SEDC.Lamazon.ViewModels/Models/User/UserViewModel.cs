using SEDC.Lamazon.ViewModels.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.ViewModels.Models.User
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public RoleViewModel Role { get; set; }
    }
}
