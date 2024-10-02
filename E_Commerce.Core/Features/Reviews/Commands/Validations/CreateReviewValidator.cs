using E_Commerce.Core.Features.Reviews.Commands.Models;
using FluentValidation;
using System;

namespace E_Commerce.Core.Features.Reviews.Commands.Validations
{
    public class CreateReviewValidator : AbstractValidator<CreateReviewCommands>
    {
        public CreateReviewValidator()
        {
            ApplyValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage("Comment is required.")
                .MaximumLength(500).WithMessage("Comment cannot exceed 500 characters.");

            RuleFor(x => x.Rate)
                .InclusiveBetween(1, 5).WithMessage("Rate must be between 1 and 5.");

         //   RuleFor(x => x.UserId)
           //     .GreaterThan(0).WithMessage("User ID must be greater than 0.");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("Product ID must be greater than 0.");
        }

       
    }
}
