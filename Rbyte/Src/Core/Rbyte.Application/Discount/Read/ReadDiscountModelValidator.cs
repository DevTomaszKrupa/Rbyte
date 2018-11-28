using FluentValidation;

namespace Rbyte.Application.Discount.Read
{
    public class ReadDiscountModelValidator : AbstractValidator<ReadDiscountModel>
    {
        public ReadDiscountModelValidator()
        {
            RuleFor(x => x.Value)
                .Must(x => x > 0)
                .WithMessage("Value must be greater than 0");

            RuleFor(x => x.DiscountId)
                .Must(x => x != 0)
                .WithMessage("Discount id cannot be equal 0");
        }
    }
}