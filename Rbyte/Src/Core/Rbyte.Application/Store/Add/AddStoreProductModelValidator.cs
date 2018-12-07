using FluentValidation;

namespace Rbyte.Application.Store.Add
{
    public class AddStoreProductModelValidator : AbstractValidator<AddStoreProductModel>
    {
        public AddStoreProductModelValidator()
        {
            RuleFor(x => x.StoreId)
                .Must(x => x != 0)
                .WithMessage("Store id cannot be equal 0");

            RuleFor(x => x.ProductId)
                .Must(x => x.HasValue && x != null)
                .WithMessage("Product cannot be null");

            RuleFor(x => x.Count)
                .Must(x => x > 0)
                .WithMessage("Count couldn't be equal 0");
        }
    }
}