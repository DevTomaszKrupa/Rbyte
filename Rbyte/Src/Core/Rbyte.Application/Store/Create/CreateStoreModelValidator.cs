using FluentValidation;

namespace Rbyte.Application.Store.Create
{
    public class CreateStoreModelValidator : AbstractValidator<CreateStoreModel>
    {
        public CreateStoreModelValidator()
        {
            RuleFor(x => x.Name)
                .Must(x => x != null && x.Length > 3)
                .WithMessage("Store name must be longer than 3 characters");
        }
    }
}