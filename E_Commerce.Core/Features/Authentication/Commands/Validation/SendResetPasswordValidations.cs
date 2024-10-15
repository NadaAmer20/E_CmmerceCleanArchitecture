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
    public class SendResetPasswordValidations : AbstractValidator<ResetPasswordCommand>
    {
        #region Fields
        #endregion

        #region Constructors
        public SendResetPasswordValidations()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Handle Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("NotEmpty")
                 .NotNull().WithMessage("Required");
        }

        public void ApplyCustomValidationsRules()
        {

        }

        #endregion
    }
}
