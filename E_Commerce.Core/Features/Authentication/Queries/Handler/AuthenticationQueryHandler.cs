using E_Commerce.Core.Bases;
using E_Commerce.Core.Features.Authentication.Queries.Models;
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

namespace E_Commerce.Core.Features.Authentication.Queries.Handler
{
    public class AuthenticationQueryHandler : ResponseHandler,
           IRequestHandler<ConfirmEmailQuery, Response<string>>,
        IRequestHandler<ConfirmResetPasswordQuery, Response<string>>
    {
        #region Fields
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthenticationServices _authenticationServices;

        #endregion
        #region Constructor
        public AuthenticationQueryHandler(UserManager<User> userManager, SignInManager<User> signInManager
            , IAuthenticationServices authenticationServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationServices = authenticationServices;
        }




        #endregion
        #region HandleFunctions

      

        public async Task<Response<string>> Handle(ConfirmEmailQuery request, CancellationToken cancellationToken)
        {
            var confirmEmail = await _authenticationServices.ConfirmEmail(request.UserId, request.Code);
            if (confirmEmail == "ErrorWhenConfirmEmail")
                return BadRequest<string>("Error When ConfirmEmail");
            return Success<string>("ConfirmEmail Done");
        }


        public async Task<Response<string>> Handle(ConfirmResetPasswordQuery request, CancellationToken cancellationToken)
        {
            var result = await _authenticationServices.ConfirmResetPassword(request.Code, request.Email);
            switch (result)
            {
                case "UserNotFound": return BadRequest<string>("UserIsNotFound");
                case "Failed": return BadRequest<string>("InvaildCode");
                case "Success": return Success<string>("");
                default: return BadRequest<string>("InvaildCode");
            }
        }
        #endregion
    }
}