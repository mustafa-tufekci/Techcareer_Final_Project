using EventHub.Entities.Models;
using FluentValidation;

namespace EventHub.WebAPI.Validators
{
    public class CityValidator : AbstractValidator<City>
    {
        public CityValidator()
        {
            RuleFor(x => x.CityName).NotEmpty();
        }
    }
}
