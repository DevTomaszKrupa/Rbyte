using FluentValidation;

namespace Rbyte.Application.Discount.Update
{
    public class UpdateDiscountModelValidator : AbstractValidator<UpdateDiscountModel>
    {
        public UpdateDiscountModelValidator()
        {
            RuleFor(x => x.Value)
                .Must(x => x > 0 && x < 100)
                .WithMessage("Discount must be greater than 0");

            RuleFor(x => x.DiscountId)
                .Must(x => x != 0)
                .WithMessage("Discount id cannot be equal 0");
        }
    }
}