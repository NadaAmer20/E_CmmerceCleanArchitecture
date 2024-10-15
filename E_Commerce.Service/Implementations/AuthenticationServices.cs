using E_Commerce.Data.Entites.Identity;
using E_Commerce.Data.Helper;
using E_Commerce.Data.Helpers;
using E_Commerce.Infrustructure.Context;
using E_Commerce.Infrustructure.Migrations;
using E_Commerce.Service.Abstracts;
using EntityFrameworkCore.EncryptColumn.Interfaces;
using EntityFrameworkCore.EncryptColumn.Util;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Service.Implementations
{
    public class AuthenticationServices : IAuthenticationServices
    {
        #region Fields
        private readonly JwtSettings _jwtSettings;
        private readonly ConcurrentDictionary<string, RefreshToken> _userRefreshTokens; // map works in a concurrent environment
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly IEmailServices _emailServices;
        private readonly IEncryptionProvider _encryptionProvider;
        #endregion

        #region Constructor
        public AuthenticationServices(JwtSettings jwtSettings,
                                      UserManager<User> userManager,
                                      ApplicationDbContext applicationDbContext, 
                                      IEmailServices emailServices )
        {
            _jwtSettings = jwtSettings;
            _userRefreshTokens = new ConcurrentDictionary<string, RefreshToken>();
            _userManager = userManager;
            _applicationDbContext = applicationDbContext;
            _emailServices = emailServices;
            _encryptionProvider = new GenerateEncryptionProvider("8a4dcaaec64d412380fe4b02193cd26f");
        }
        #endregion

        #region HandleFunctions

        public async Task<JwtAuthResult> GetJWTToken(User user)
        {
            var (jwtToken, accessToken) = await GenerateJwtToken(user);
            var refreshToken = GetRefreshToken(user.UserName);

            var userRefreshToken = new UserRefreshToken
            {
                AddedTime = DateTime.Now,
                ExpiryDate = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
                IsUsed = true,
                IsRevoked = false,
                JwtId = jwtToken.Id,
                RefreshToken = refreshToken.TokenString,
                Token = accessToken,
                UserId = user.Id
            };

            await _applicationDbContext.userRefreshToken.AddAsync(userRefreshToken);
            await _applicationDbContext.SaveChangesAsync(); // Ensure tokens are saved

            var response = new JwtAuthResult()
            {
                AccessToken = accessToken,
                refreshToken = refreshToken,
            };

            return response;
        }

        private async Task<(JwtSecurityToken, string)> GenerateJwtToken(User user)
        {
           // var roles = await _userManager.GetRolesAsync(user);
            var claims = await GetClaims(user);

            var jwtToken = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.AccessTokenExpireDate),
                signingCredentials:
                new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature)
            );

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return (jwtToken, accessToken);
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
            }
            return Convert.ToBase64String(randomNumber);
        }

        private RefreshToken GetRefreshToken(string userName)
        {
            var refreshToken = new RefreshToken
            {
                TokenString = GenerateRefreshToken(),
                UserName = userName,
                ExpireAt = DateTime.Now.AddDays(_jwtSettings.RefreshTokenExpireDate),
            };
            return refreshToken;
        }

        private async Task<List<Claim>> GetClaims(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                // Include the NameIdentifier claim for UserId
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(nameof(UserClaimsModel.PhoneNumber), user.PhoneNumber),
            };

            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role.ToString()));
            var userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);
            return claims;
        }
        public async Task<string> ConfirmEmail(int UserId, string Code)
        {
            if (UserId == null || Code == null)
                return "ErrorWhenConfirmEmail";
            var user = await _userManager.FindByIdAsync(UserId.ToString());
            var confirmEmail = await _userManager.ConfirmEmailAsync(user, Code);
            if (!confirmEmail.Succeeded)
                return "ErrorWhenConfirmEmail";
            return "Success";
        }



        public async Task<string> ResetPasswordCode(string Email)
        {
            var trans = await _applicationDbContext.Database.BeginTransactionAsync();
            try
            {
                //user
                var user = await _userManager.FindByEmailAsync(Email);
                //user not Exist => not found
                if (user == null)
                    return "UserNotFound";
                var chars = "0123456789";
                var random = new Random();
                var randomNumber = new string(Enumerable.Repeat(chars, 6).Select(s => s[random.Next(s.Length)]).ToArray());

                //update User In Database Code
                user.Code = randomNumber;
                var updateResult = await _userManager.UpdateAsync(user);
                if (!updateResult.Succeeded)
                    return "ErrorInUpdateUser";
                var message = "Code To Reset Passsword : " + user.Code;
                //Send Code To  Email 
                await _emailServices.SendEmail(user.Email, message, "Reset Password");
                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }
        public async Task<string> ResetPassword(string Email, string Password)
        {
            var trans = await _applicationDbContext.Database.BeginTransactionAsync();
            try
            {
                //Get User
                var user = await _userManager.FindByEmailAsync(Email);
                //user not Exist => not found
                if (user == null)
                    return "UserNotFound";
                await _userManager.RemovePasswordAsync(user);
                if (!await _userManager.HasPasswordAsync(user))
                {
                    await _userManager.AddPasswordAsync(user, Password);
                }
                await trans.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                await trans.RollbackAsync();
                return "Failed";
            }
        }
        public async Task<string> ConfirmResetPassword(string Code, string Email)
        {
            //Get User
            //user
            var user = await _userManager.FindByEmailAsync(Email);
            //user not Exist => not found
            if (user == null)
                return "UserNotFound";
            //Decrept Code From Database User Code
            var userCode = user.Code;
            //Equal With Code
            if (userCode == Code) return "Success";
            return "Failed";
        }

        #endregion
    }
}
