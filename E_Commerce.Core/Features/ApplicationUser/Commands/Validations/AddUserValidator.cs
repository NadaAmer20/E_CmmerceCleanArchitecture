using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using E_Commerce.Core.Features.ApplicationUser.Commands.Models;
namespace E_Commerce.Core.Features.ApplicationUser.Commands.Validations
{
    public class AddUserValidator: AbstractValidator<AddUserCommand>
    {
        #region Fields
     //   private readonly IStringLocalizer<SharedResourses> _localizer;

    #endregion
    #region Constructors
    public AddUserValidator()//IStringLocalizer<SharedResourses> localizer)
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

                RuleFor(x => x.PassWord)
                    .NotEmpty().WithMessage("Password is required.");

                RuleFor(x => x.ConfirmPassword)
                    .Equal(x => x.PassWord).WithMessage("Password and Confirm Password do not match.");

        }

    public void ApplyCustomValidationsRules()
    {

    }

    #endregion
}
}
