using AutoMapper;
using E_Commerce.Core.Features.ApplicationUser.Commands.Models;
using E_Commerce.Data.Entites.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile : Profile
    {
        public void UpdateUserMapping()
        {
            CreateMap<UpdateUserCommand, User>();
        }
    }

}
