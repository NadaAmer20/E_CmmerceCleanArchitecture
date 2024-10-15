using E_Commerce.Core.Features.Authentication.Queries.Models;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Authentication.Queries.Validations
{

    public class ConfirmResetPasswordValidations : AbstractValidator<ConfirmResetPasswordQuery>
    {
        #region Fields
        #endregion

        #region Constructors
        public ConfirmResetPasswordValidations()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Code)
                 .NotEmpty().WithMessage("NotEmpty")
                 .NotNull().WithMessage("Required");
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