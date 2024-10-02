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
    }
}
