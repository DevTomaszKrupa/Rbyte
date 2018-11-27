using FluentValidation;

namespace Rbyte.Application.Category.Create
{
    public class CreateCategoryModelValidator : AbstractValidator<CreateCategoryModel>
    {
        public CreateCategoryModelValidator()
        {
            RuleFor(x => x.Name)
                .Must(x => x != null && x.Length > 3)
                .WithMessage("Category name must be longer than 3 characters");
        }
    }
}