using FluentValidation;

namespace Rbyte.Application.Tax.Read
{
    public class ReadTaxModelValidator : AbstractValidator<ReadTaxModel>
    {
        public ReadTaxModelValidator()
        {
            RuleFor(x => x.TaxId)
                .Must(x => x != 0)
                .WithMessage("Tax id cannot be equal 0");
        }
    }
}