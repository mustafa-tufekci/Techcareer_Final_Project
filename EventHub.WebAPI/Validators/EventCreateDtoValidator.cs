using EventHub.Entities.DTOs;
using FluentValidation;

namespace EventHub.WebAPI.Validators
{
    public class EventCreateDtoValidator : AbstractValidator<EventCreateDto>
    {
        public EventCreateDtoValidator()
        {
            RuleFor(x => x.EventName).NotEmpty();
            RuleFor(x => x.EventDescription).NotEmpty();
            RuleFor(x => x.EventDate)
            .NotEmpty().WithMessage("Even date must not be empty.")
            .Must((model, evenDate) => evenDate > model.ApplicationDeadline)
            .WithMessage("Application deadline must be earlier than event date.");
            RuleFor(x => x.ApplicationDeadline)
            .NotEmpty().WithMessage("Application deadline must not be empty.");
            RuleFor(x => x.Address).NotEmpty();
            RuleFor(x => x.Capacity).NotEmpty().GreaterThan(0);
            RuleFor(x => x.TicketPrice).NotEmpty().When(x => x.IsTicketed == true);
            RuleFor(x => x.CityId).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
