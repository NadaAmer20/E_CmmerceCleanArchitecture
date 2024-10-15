using E_Commerce.Core.Features.Carts.Commands.Models;
using E_Commerce.Core.Features.Products.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Carts.Commands.Validations
{
    public class AddCartValidator : AbstractValidator<AddCartCommand>
    {
        #region Fields
        #endregion
        #region Constructors
        public AddCartValidator() 
        {
            ApplyValidationsRules();
            //  ApplyCustomValidationsRules();
        }

        #endregion
        #region Handle Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.ProductId)
                       .GreaterThan(0).WithMessage("ProductId must be greater than 0.");

            //RuleFor(x => x.)
            //    .GreaterThanOrEqualTo(0).WithMessage("Quantity must be 0 or greater.");

            //RuleFor(x => x.Date)
            //    .NotEmpty().WithMessage("Date cannot be empty.");
            //RuleFor(x => x.UserId)
            //    .GreaterThan(0).WithMessage("UserId must be greater than 0.");
        }

        public void ApplyCustomValidationsRules()
        {

        }

        #endregion
    }
}
