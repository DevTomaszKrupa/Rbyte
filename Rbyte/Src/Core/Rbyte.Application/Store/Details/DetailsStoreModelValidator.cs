using FluentValidation;

namespace Rbyte.Application.Store.Details
{
    public class DetailsStoreModelValidator : AbstractValidator<DetailsStoreModel>
    {
        public DetailsStoreModelValidator()
        {
            RuleFor(x => x.Name)
                .Must(x => x != null && x.Length > 3)
                .WithMessage("Store name must be longer than 3 characters");

            RuleFor(x => x.StoreId)
                .Must(x => x != 0)
                .WithMessage("Store id cannot be equal 0");
        }
    }
}