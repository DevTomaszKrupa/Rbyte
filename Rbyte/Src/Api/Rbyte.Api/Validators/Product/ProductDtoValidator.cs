using FluentValidation;
using Rbyte.Domain.Models.Product;

namespace Rbyte.Api.Validators.Product
{
    public class ProductDtoValidator : AbstractValidator<ProductDto>
    {
        public ProductDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .MaximumLength(100);
            RuleFor(p => p.Description)
                .MaximumLength(500); ;
            RuleFor(p => p.Barcode)
                .NotEmpty()
                .GreaterThan(9999)
                .LessThan(100000)
                .WithMessage("Barcode must be between 10000 and 99999");
            RuleFor(p => p.Tax)
                .GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(100);
        }
    }
}
