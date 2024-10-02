using AutoMapper;
using E_Commerce.Core.Bases;
using E_Commerce.Core.Features.ApplicationUser.Commands.Models;
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
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_Commerce.Core.Features.ApplicationUser.Command.Models;
namespace E_Commerce.Core.Features.ApplicationUser.Commands.Handlers
{
    public class UserCommandHandler : ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>
        ,IRequestHandler<UpdateUserCommand, Response<string>>
          , IRequestHandler<DeleteUserCommand, Response<string>>,
                IRequestHandler<ChangePasswordCommand, Response<string>>

    {
        #region Feilds
        private readonly IMapper _mapper;
       private readonly UserManager<User> _userManager;
        private readonly IApplicationUserServices _applicationUserServices;
        #endregion

        #region Constructor
        public UserCommandHandler(UserManager<User> userManager,IMapper mapper, IApplicationUserServices applicationUserServices)
        {
            _mapper = mapper;
           _userManager = userManager;
            _applicationUserServices = applicationUserServices;
        }
        #endregion
        #region HandleFunction
        public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var identityUser = _mapper.Map<User>(request);
            //Create
            var createResult = await _applicationUserServices.AddUserAsync(identityUser, request.PassWord);
            switch (createResult)
            {
                case "EmailIsExist":
                    return BadRequest<string>("The email address already exists.");
                case "UserNameIsExist":
                    return BadRequest<string>("The username already exists.");
                case "ErrorInCreateUser":
                    return BadRequest<string>("Failed to create user. Please try again.");
                case "Failed":
                    return BadRequest<string>("Registration failed. Please try to register again.");
                case "Success":
                    return Success<string>("");
                default:
                    return BadRequest<string>("An unknown error occurred.");
            }
        }
        public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            //check if user is exist
            var oldUser = await _userManager.FindByIdAsync(request.Id.ToString());
            //if Not Exist notfound
            if (oldUser == null) 
                return NotFound<string>();
            //mapping
            var newUser = _mapper.Map(request, oldUser);
            //if username is Exist
            var userByUserName = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == newUser.UserName && x.Id != newUser.Id);
            //username is Exist
            if (userByUserName != null) return BadRequest<string>("UserNameIsAlreadyExsists");
            //update
            var result = await _userManager.UpdateAsync(newUser);
            //result is not success
            if (!result.Succeeded) return BadRequest<string>(result.Errors.FirstOrDefault().Description);
            //message
            return Success("Update");
        }
        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var User = await _userManager.FindByIdAsync(request.Id.ToString());
            if (User == null)
                return NotFound<string>("NotFound");
            var Result = await _userManager.DeleteAsync(User);
            if (!Result.Succeeded)
                return BadRequest<string>("FailedToDeleteUser");
            return Success<string>("Deleted");
        }

        public async Task<Response<string>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            //get user
            //check if user is exist
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            //if Not Exist notfound
            if (user == null)
                return NotFound<string>();

            //Change User Password
            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            //var user1=await _userManager.HasPasswordAsync(user);
            //await _userManager.RemovePasswordAsync(user);
            //await _userManager.AddPasswordAsync(user, request.NewPassword);

            //result
            if (!result.Succeeded) return BadRequest<string>(result.Errors.FirstOrDefault().Description);
            return Success<string>("Success");
        }

        #endregion

    } 
}
