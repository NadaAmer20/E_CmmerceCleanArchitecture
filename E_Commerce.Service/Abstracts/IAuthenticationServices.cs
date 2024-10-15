using E_Commerce.Data.Entites.Identity;
using E_Commerce.Data.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Abstracts
{
    public interface IAuthenticationServices
    {
        public Task<JwtAuthResult> GetJWTToken(User user);
        public Task<string> ConfirmEmail(int UserId, string Code);
        public Task<string> ResetPasswordCode(string Email);
        public Task<string> ResetPassword(string Email, string Password);
        public Task<string> ConfirmResetPassword(string Code, string Email);
    }
}
