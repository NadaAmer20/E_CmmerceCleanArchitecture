using E_Commerce.Core.Features.Authorization.Commands.Models;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Authorization.Commands.Validations
{
    public class EditRoleValidator : AbstractValidator<EditRoleCommand>
    {
        #region Fields
         #endregion
        #region Constructors

        #endregion
        public EditRoleValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Id)
                 .NotEmpty().WithMessage("NotEmpty")
                 .NotNull().WithMessage("Required");
            RuleFor(x => x.Name)
                 .NotEmpty().WithMessage("NotEmpty")
                 .NotNull().WithMessage("Required");
        }

        public void ApplyCustomValidationsRules()
        {

        }

        #endregion
    }
}
