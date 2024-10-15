using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using E_Commerce.Core.Mapping.ApplicationUser;
namespace E_Commerce.Core.Mapping.ApplicationUser
{
  
        public partial class ApplicationUserProfile : Profile
        {
            public ApplicationUserProfile()
            {
                AddUserMapping();
                UpdateUserMapping();
                GetUserByIdMapping();
            }
        }
 
}
