using FluentValidation;

namespace Rbyte.Application.Tax.Create
{
    public class CreateTaxModelValidator : AbstractValidator<CreateTaxModel>
    {
        public CreateTaxModelValidator()
        {
            RuleFor(x => x.Value)
                .Must(x => x >= 0)
                .WithMessage("Tax canot be minus value");
        }
    }
}