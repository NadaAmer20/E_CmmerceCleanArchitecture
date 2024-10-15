using E_Commerce.Core.Bases;//ResponseHandler
using E_Commerce.Core.Features.Authorization.Queries.Models;
using E_Commerce.Data.DTOs;
using E_Commerce.Data.Entites.Identity;
using E_Commerce.Service.Abstracts;
using MediatR;//IRequestHandler
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Authorization.Queries.Handler
{
    public class ClaimQueryHandler : ResponseHandler,
         IRequestHandler<ManageUserClaimsQuery, Response<ManageUserClaimsResults>>
    {
        #region Fileds
        private readonly IAuthorizationServices _authorizationService;
        private readonly UserManager<User> _userManager;
        #endregion
        #region Constructors
        public ClaimQueryHandler( IAuthorizationServices authorizationService,
                                  UserManager<User> userManager) 
        {
            _authorizationService = authorizationService;
            _userManager = userManager;
        }
        #endregion
        #region Handle Functions
        public async Task<Response<ManageUserClaimsResults>> Handle(ManageUserClaimsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null) return NotFound<ManageUserClaimsResults>( "User Is Not Found");
            var result = await _authorizationService.ManageUserClaimData(user);
            return Success(result);
        }
        #endregion
    }
}
