using E_Commerce.Core.Features.Authorization.Commands.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Service.Abstracts;
namespace E_Commerce.Core.Features.Authorization.Commands.Validations
{
    public class AddRoleValidator : AbstractValidator<AddRoleCommand>
    {
        #region Fields
        private readonly IAuthorizationServices _authorizationService;
        #endregion
        #region Constructors

        #endregion
        public AddRoleValidator(IAuthorizationServices authorizationService)
        {
            _authorizationService = authorizationService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.RoleName)
                 .NotEmpty().WithMessage("NotEmpty")
                 .NotNull().WithMessage("Required");
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.RoleName)
                .MustAsync(async (Key, CancellationToken) => !await _authorizationService.IsRoleExstists(Key))
                .WithMessage("IsExist");
        }

        #endregion
    }

}
