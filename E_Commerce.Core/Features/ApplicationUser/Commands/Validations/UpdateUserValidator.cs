using E_Commerce.Core.Features.ApplicationUser.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.ApplicationUser.Commands.Validations
{
    public class UpdateUserValidator : AbstractValidator<AddUserCommand>
    {
        #region Fields
        //   private readonly IStringLocalizer<SharedResourses> _localizer;

        #endregion
        #region Constructors
        public UpdateUserValidator()//IStringLocalizer<SharedResourses> localizer)
        {
            //  _localizer = localizer;
            ApplyValidationsRules();
            //  ApplyCustomValidationsRules();
        }

        #endregion
        #region Handle Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required.")
                .MaximumLength(100).WithMessage("First Name cannot exceed 100 characters.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required.")
                .MaximumLength(100).WithMessage("Last Name cannot exceed 100 characters.");

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("User Name is required.")
                .MaximumLength(100).WithMessage("User Name cannot exceed 100 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("A valid Email is required.");
 
        }

        public void ApplyCustomValidationsRules()
        {

        }

        #endregion
    }

    }
