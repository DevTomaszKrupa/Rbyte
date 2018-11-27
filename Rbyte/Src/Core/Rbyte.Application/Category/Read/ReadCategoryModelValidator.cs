using FluentValidation;

namespace Rbyte.Application.Category.Read
{
    public class ReadCategoryModelValidator : AbstractValidator<ReadCategoryModel>
    {
        public ReadCategoryModelValidator()
        {
            RuleFor(x => x.Name)
                .Must(x => x != null && x.Length > 3)
                .WithMessage("Category name must be longer than 3 characters");

            RuleFor(x => x.CategoryId)
                .Must(x => x != 0)
                .WithMessage("Category id cannot be equal 0");
        }
    }
}