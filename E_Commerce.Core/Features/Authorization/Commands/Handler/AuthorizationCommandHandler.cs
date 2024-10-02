using E_Commerce.Core.Bases;
using E_Commerce.Core.Features.Authorization.Commands.Models;
using E_Commerce.Service.Abstracts;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Authorization.Commands.Handler
{
    public class AuthorizationCommandHandler : ResponseHandler,
        IRequestHandler<AddRoleCommand, Response<string>>,
        //IRequestHandler<EditRoleCommand, Response<string>>,
        IRequestHandler<DeleteRoleCommand, Response<string>>
    {
        #region Feilds
        private readonly IAuthorizationServices _authorizationServices;
        #endregion
        #region Constructor
        public AuthorizationCommandHandler( IAuthorizationServices authorizationServices) 
        {
            _authorizationServices = authorizationServices;
        }
        #endregion
        #region HandleFunctions

        public async Task<Response<string>> Handle(AddRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationServices.AddRoleAsync(request.RoleName);
            if (result == "Success")
            {
                return Success("");
            }
            return BadRequest<string>("FaliedToAddRole");
        }

        //public async Task<Response<string>> Handle(EditRoleCommand request, CancellationToken cancellationToken)
        //{
        //    var result = await _authorizationServices.EditRoleAsync(request);
        //    if (result == "notFound") return NotFound<string>();
        //    else if (result == "Success") return Success((string)"Success");
        //    else
        //        return BadRequest<string>(result);
        //}

        public async Task<Response<string>> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
        {
            var result = await _authorizationServices.DeleteRoleAsync(request.Id);
            if (result == "NotFound") return NotFound<string>();
            else if (result == "Used") return BadRequest<string>("RoleIsUsed");//NOOO
            else if (result == "Success") return Success((string)"Deleted");
            else
                return BadRequest<string>(result);
        }

        #endregion
    }
}