using AutoMapper;
using SEDC.Lamazon.Domain.Enitites;
using SEDC.Lamazon.ViewModels.Models.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.Lamazon.Utilities.AutMapperProfiles
{
    public class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<Role, RoleViewModel>().ReverseMap();
        }
    }
}
