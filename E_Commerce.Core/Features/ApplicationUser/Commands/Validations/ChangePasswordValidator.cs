using E_Commerce.Core.Features.ApplicationUser.Commands.Models;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.ApplicationUser.Commands.Validations
{
    public class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
    {
        #region Fields

        #endregion
        #region Constructors
        public ChangePasswordValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        #endregion
        #region Handle Functions
        public void ApplyValidationsRules()
        {

            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("ID cannot be empty.")
                .NotNull().WithMessage("ID is required.");

            RuleFor(x => x.CurrentPassword)
                .NotEmpty().WithMessage("Current password cannot be empty.")
                .NotNull().WithMessage("Current password is required.");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("New password cannot be empty.")
                .NotNull().WithMessage("New password is required.");

            RuleFor(x => x.ConfirmPassword)
                .Equal(x => x.NewPassword).WithMessage("The confirmation password does not match the new password.");
   
        }

        public void ApplyCustomValidationsRules()
        {

        }

        #endregion
    }

}
