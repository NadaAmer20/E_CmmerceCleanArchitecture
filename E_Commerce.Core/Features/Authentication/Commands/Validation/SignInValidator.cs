using E_Commerce.Core.Features.Authentication.Commands.Models;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Authentication.Commands.Validation
{
    public class SignInValidator : AbstractValidator<SignInCommand>
    {
        #region Fields
        #endregion
        #region Constuctors
        public SignInValidator()
        {
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }
        #endregion
        #region Actions
        public void ApplyValidationRules()
        {
            RuleFor(x => x.UserName)
   .NotEmpty().WithMessage("User name cannot be empty.")
   .NotNull().WithMessage("User name is required.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password cannot be empty.")
                .NotNull().WithMessage("Password is required.");

        }
        public void ApplyCustomValidationRules()
        {


        }
        #endregion
    }
}
