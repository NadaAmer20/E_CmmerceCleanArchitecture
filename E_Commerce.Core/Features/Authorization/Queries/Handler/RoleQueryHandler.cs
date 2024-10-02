using AutoMapper;
using E_Commerce.Core.Bases;
using E_Commerce.Core.Features.Authorization.Queries.Models;
using E_Commerce.Core.Features.Authorization.Queries.Results;
using E_Commerce.Data.Entites.Identity;
using E_Commerce.Service.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Authorization.Queries.Handler
{
    public class RoleQueryHandler : ResponseHandler,
      IRequestHandler<GetRolesListQuery, Response<List<GetRolesListResult>>>,
        IRequestHandler<GetRoleByIdQuery, Response<GetRoleByIdResult>>
    {

        #region Properties
        private readonly IAuthorizationServices _authorizationServices;
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        #endregion

        #region Constructor
        public RoleQueryHandler( IMapper mapper, IAuthorizationServices authorizationServices,
            UserManager<User> userManager) 
        {
            _mapper = mapper;
            _authorizationServices = authorizationServices;
            _userManager = userManager;
        }
        #endregion

        #region Functions

        public async Task<Response<List<GetRolesListResult>>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _authorizationServices.GetRolesAsync();
            var result = _mapper.Map<List<GetRolesListResult>>(roles);
            return Success(result);
        }


        public async Task<Response<GetRoleByIdResult>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _authorizationServices.GetRoleById(request.Id);
            if (role == null) return NotFound<GetRoleByIdResult>( "NotFound");
            var result = _mapper.Map<GetRoleByIdResult>(role);
            return Success(result);
        }
        #endregion
    }
}
