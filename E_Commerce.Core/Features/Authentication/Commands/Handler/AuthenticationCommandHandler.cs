using E_Commerce.Core.Bases;
using E_Commerce.Core.Features.Authentication.Commands.Models;
using E_Commerce.Data.Entites.Identity;
using E_Commerce.Data.Helpers;
using E_Commerce.Service.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Authentication.Commands.Handler
{
    public class AuthenticationCommandHandler :
      ResponseHandler, IRequestHandler<SignInCommand, Response<JwtAuthResult>>,
        IRequestHandler<ResetPasswordCommand, Response<string>>,
        IRequestHandler<SendResetPasswordCommand, Response<string>>
    {
        #region Fields
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthenticationServices _authenticationServices;

        #endregion
        #region Constructor
        public AuthenticationCommandHandler(UserManager<User> userManager, SignInManager<User> signInManager
            , IAuthenticationServices authenticationServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authenticationServices = authenticationServices;
        }




        #endregion
        #region Handle Function
        public async Task<Response<JwtAuthResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            //Check if user is exist or not
            var user = await _userManager.FindByNameAsync(request.UserName);
            //Return The UserName Not Found
            if (user == null)
                return BadRequest<JwtAuthResult>("UserName Is Not Exist");
            //try To Sign in 
            //    bool signInResult = await _userManager.CheckPasswordAsync(user, request.Password);
            bool signInResult = await _userManager.CheckPasswordAsync(user, request.Password);
            //   var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            //if Failed Return Passord is wrong
            if (!signInResult)
                return BadRequest<JwtAuthResult>("Password Not Correct");
         //   if (!user.EmailConfirmed)
           //     return BadRequest<JwtAuthResult>("Email Not Confirmed");
            //Generate Token
            var result = await _authenticationServices.GetJWTToken(user);
            //return Token 
            return Success(result);
        }


        public async Task<Response<string>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenticationServices.ResetPassword(request.Email, request.Password);
            switch (result)
            {
                case "UserNotFound": return BadRequest<string>("User Is Not Found");
                case "Failed": return BadRequest<string>("Invaild Code");
                case "Success": return Success<string>("");
                default: return BadRequest<string>("InvaildCode");
            }
        }
        public async Task<Response<string>> Handle(SendResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var result = await _authenticationServices.ResetPasswordCode(request.Email);
            switch (result)
            {
                case "UserNotFound": return BadRequest<string>("User Is Not Found");
                case "ErrorInUpdateUser": return BadRequest<string>("Try Again In Another Time");
                case "Failed": return BadRequest<string>("Try Again In Another Time");
                case "Success": return Success<string>("");
                default: return BadRequest<string>("Try Again In Another Time");
            }
        }

        #endregion
    }
}
