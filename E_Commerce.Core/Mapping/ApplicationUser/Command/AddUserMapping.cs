using E_Commerce.Core.Features.ApplicationUser.Commands.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Data.Entites.Identity;
using MediatR;
using AutoMapper;
namespace E_Commerce.Core.Mapping.ApplicationUser
{
    public partial class ApplicationUserProfile : Profile
    {
        public void AddUserMapping()
        {
          CreateMap<AddUserCommand, User>();
        }
    }
}
