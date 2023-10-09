using AutoMapper;
using SEDC.Lamazon.DataAccess.Interfaces;
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
        private readonly IMapper _mapper;

        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            _roleRepository = roleRepository;
            _mapper = mapper;
        }

        public List<RoleViewModel> GetAllRoles()
        {
            var roles = _roleRepository.GetAll();
            return _mapper.Map < List<RoleViewModel>>(roles);
        }

        public RoleViewModel GetRoleById(int id)
        {

            var role = _roleRepository.Get(x => x.Id == id);

            return _mapper.Map<RoleViewModel>(role);
           
        }
    }
}
