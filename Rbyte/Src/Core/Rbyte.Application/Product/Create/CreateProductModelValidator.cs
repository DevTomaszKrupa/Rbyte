using FluentValidation;

namespace Rbyte.Application.Product.Create
{
    public class CreateProductModelValidator : AbstractValidator<CreateProductModel>
    {
        public CreateProductModelValidator()
        {
            RuleFor(x => x.Name)
                .Must(x => x != null && x.Length > 3)
                .WithMessage("Product name must be longer than 3 characters");

            RuleFor(x => x.Price)
                .Must(x => x > 0)
                .WithMessage("Product price must be greater than 0");

            RuleFor(x => x.Barcode)
                .Must(x => x.ToString().Length == 5)
                .WithMessage("Barcode must have 5 digits and not contains 0");

            RuleFor(x => x.CategoryId)
                .Must(x => x.HasValue && x > 0)
                .WithMessage("Category is required");
        }
    }
}
