using FluentValidation;

namespace Rbyte.Application.Product.Read
{
    public class ReadProductModelValidator : AbstractValidator<ReadProductModel>
    {
        public ReadProductModelValidator()
        {
            RuleFor(x => x.Name)
                .Must(x => x != null && x.Length > 3)
                .WithMessage("Product name must be longer than 3 characters");

            RuleFor(x => x.ProductId)
                .Must(x => x != 0)
                .WithMessage("Product id cannot be equal 0");
        }
    }
}