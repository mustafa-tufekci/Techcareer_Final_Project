using EventHub.Entities.Models;
using FluentValidation;

namespace EventHub.WebAPI.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty();
        }
    }
}
