using FluentValidation;

namespace Rbyte.Application.Product.Update
{
    public class UpdateProductModelValidator : AbstractValidator<UpdateProductModel>
    {
        public UpdateProductModelValidator()
        {
            RuleFor(x => x.Name)
                .Must(x => x != null && x.Length > 3)
                .WithMessage("Product name must be longer than 3 characters");

            RuleFor(x => x.ProductId)
                .Must(x => x != 0)
                .WithMessage("Product id cannot be equal 0");

            RuleFor(x => x.Price)
                .Must(x => x > 0)
                .WithMessage("Product price must be greater than 0");

            RuleFor(x => x.Barcode)
                .Must(x => x.ToString().Length == 5)
                .WithMessage("Barcode must have 5 digits and not contains 0");
        }

    }
}