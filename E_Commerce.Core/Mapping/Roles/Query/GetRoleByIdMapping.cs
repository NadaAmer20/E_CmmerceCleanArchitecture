using E_Commerce.Core.Features.Authorization.Queries.Results;
using E_Commerce.Data.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace E_Commerce.Core.Mapping.Roles
{
    public partial class RolesProfile
    {
        public void GetRoleByIdMapping()
        {
            CreateMap<Role, GetRoleByIdResult>();
        }
    }
}

