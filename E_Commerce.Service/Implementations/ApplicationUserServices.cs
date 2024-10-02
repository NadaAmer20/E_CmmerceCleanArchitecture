using E_Commerce.Data.Entites.Identity;
using E_Commerce.Infrustructure.Context;
using E_Commerce.Service.Abstracts;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Implementations
{
    public class ApplicationUserServices: IApplicationUserServices
    {
        #region Fields
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _applicationDBContext;
        #endregion
        #region Constructors
        public ApplicationUserServices(UserManager<User> userManager,
                                   
                                      ApplicationDbContext applicationDBContext)
        {
            _userManager = userManager;
            _applicationDBContext = applicationDBContext;
        }
        #endregion
        #region Handle Functions
        public async Task<string> AddUserAsync(User user, string password)
        {
            //  var trans = await _applicationDBContext.Database.BeginTransactionAsync();

            //if Email is Exist
            var existUser = await _userManager.FindByEmailAsync(user.Email);
            if (existUser != null)
                return "EmailIsExist";
            var userByUserName = await _userManager.FindByNameAsync(user.UserName);
            if (userByUserName != null)
                return "UserNameIsExist";

            var createResult = await _userManager.CreateAsync(user, password);
            if (!createResult.Succeeded)
                return string.Join(",", createResult.Errors.Select(x => x.Description).ToList());
            await _userManager.AddToRoleAsync(user, "User");
            return "Success";


        }
        #endregion

    }
}
