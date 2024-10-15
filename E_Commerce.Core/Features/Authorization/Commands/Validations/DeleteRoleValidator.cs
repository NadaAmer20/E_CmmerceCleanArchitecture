using E_Commerce.Core.Features.Authorization.Commands.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Authorization.Commands.Validations
{
    public class DeleteRoleValidator : AbstractValidator<DeleteRoleCommand>
    {
        #region Fields
        public readonly IAuthorizationService _authorizationService;

        #endregion
        #region Constructors
        public DeleteRoleValidator(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion
        #region  Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                 .NotEmpty().WithMessage( "NotEmpty")
                 .NotNull().WithMessage("Required");
        }
        // it is already exsists
        public void ApplyCustomValidationsRules()
        {
                 }
        #endregion
    }
}

