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
    public class ResetPasswordValidations
    : AbstractValidator<ResetPasswordCommand>
    {
        #region Fields
         #endregion

        #region Constructors
        public ResetPasswordValidations()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Handle Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("Not Empty")
                 .NotNull().WithMessage("Required");
            RuleFor(x => x.Password)
                 .NotEmpty().WithMessage("Not Empty")
                 .NotNull().WithMessage("Required");
            RuleFor(x => x.ConfirmPassword)
                 .Equal(x => x.Password).WithMessage("Password Not Equal ConfirmPassword");

        }

        public void ApplyCustomValidationsRules()
        {

        }

        #endregion
    }
}