using E_Commerce.Core.Features.Emails.Commands.Models;
using FluentValidation;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Emails.Commands.Validations
{
    public class SendEmailValidator : AbstractValidator<SendEmailCommand>
    {
        #region Fields
        #endregion
        #region Constructors
        public SendEmailValidator()
        {
 
            ApplyValidationsRules();
        }
        #endregion
        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("Not Empty")
                 .NotNull().WithMessage("Required");
            RuleFor(x => x.Massege)
                 .NotEmpty().WithMessage("Not Empty")
                 .NotNull().WithMessage("Required");
        }
        #endregion
    }
}
