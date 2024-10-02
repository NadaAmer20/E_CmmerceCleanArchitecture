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
      ResponseHandler, IRequestHandler<SignInCommand, Response<JwtAuthResult>>
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
            if (user == null) return BadRequest<JwtAuthResult>("UserNameIsNotExist");
            //try To Sign in 
            bool signInResult = await _userManager.CheckPasswordAsync(user, request.Password);

            //var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            //if Failed Return Passord is wrong
            if (!signInResult) return BadRequest<JwtAuthResult>("PasswordNotCorrect");
            //Generate Token
            var result = await _authenticationServices.GetJWTToken(user);
            //return Token 
            return Success(result);
        }

        

       
 
        #endregion
    }
}
