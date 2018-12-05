using FluentValidation;

namespace Rbyte.Application.Tax.Update
{
    public class UpdateTaxModelValidator : AbstractValidator<UpdateTaxModel>
    {
        public UpdateTaxModelValidator()
        {
            RuleFor(x => x.Value)
                .Must(x => x >= 0)
                .WithMessage("Tax canot be minus value");
        }
    }
}