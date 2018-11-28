using FluentValidation;

namespace Rbyte.Application.Discount.Create
{
    public class CreateDiscountModelValidator : AbstractValidator<CreateDiscountModel>
    {
        public CreateDiscountModelValidator()
        {
            RuleFor(x => x.Value)
                .Must(x => x > 0 && x < 100)
                .WithMessage("Discount value must be greater than 0 and smaller than 100");

            RuleFor(x => x.CategoryId)
                .Must(x => x.HasValue && x > 0)
                .WithMessage("Category is required");
        }
    }
}