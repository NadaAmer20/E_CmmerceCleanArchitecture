using E_Commerce.Core.Features.Carts.Commands.Models;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Features.Carts.Commands.Validations
{
    public class RemoveCartValidator : AbstractValidator<RemoveCartCommand>
    {
        #region Fields
        #endregion
        #region Constructors
        public RemoveCartValidator() 
        {
            ApplyValidationRules();
            //  ApplyCustomValidationsRules();
        }

        #endregion
        #region Handle Functions
        public void ApplyValidationRules()
        {
            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be greater than 0.");

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }
        public void ApplyCustomValidationsRules()
        {

        }

        #endregion
    }
}
