using E_Commerce.Data.Entites.Identity;
using E_Commerce.Data.Requests;
using E_Commerce.Infrustructure.Context;
using E_Commerce.Service.Abstracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace E_Commerce.Service.Implementations
{
    public class AuthorizationServices: IAuthorizationServices
    {
        #region Fields
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _dbContext;
        #endregion
        #region Fields
        public AuthorizationServices(RoleManager<Role> roleManager, UserManager<User> userManager, ApplicationDbContext dbContext)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _dbContext = dbContext;

        }
        #endregion
        #region Fields

        public async Task<string> AddRoleAsync(string roleName)
        {
            var IdentityRole = new Role();
            IdentityRole.Name = roleName;
            var result = await _roleManager.CreateAsync(IdentityRole);
            if (result.Succeeded)
                return "Success";
            else
                return "Failed";
        }
        

        public async Task<bool> IsRoleExstists(string roleName)
            => await _roleManager.RoleExistsAsync(roleName);

        public async Task<List<Role>> GetRolesAsync()
        {
            return await _roleManager.Roles.ToListAsync();
        }

        public async Task<Role> GetRoleById(int id)
        {
            return await _roleManager.FindByIdAsync(id.ToString());
        }
 
        //public async Task<string> EditRoleAsync(EditRoleCommand request)
        //{
        //    //check role is exist or not
        //    var role = await _roleManager.FindByIdAsync(request.Id.ToString());
        //    if (role == null)
        //        return "notFound";
        //    role.Name = request.Name;
        //    var result = await _roleManager.UpdateAsync(role);
        //    if (result.Succeeded)
        //        return "Success";
        //    var errors = string.Join("-", result.Errors);
        //    return errors;

        //}

        public async Task<string> DeleteRoleAsync(int roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            if (role == null) return "NotFound";
            //Chech if user has this role or not
            var users = await _userManager.GetUsersInRoleAsync(role.Name);
            //return exception 
            if (users != null && users.Count() > 0) return "Used";
            //delete
            var result = await _roleManager.DeleteAsync(role);
            //success
            if (result.Succeeded) return "Success";
            //problem
            var errors = string.Join("-", result.Errors);

            return errors;
        }

       
        #endregion



    }
}
