using EventHub.Entities.Models;
using FluentValidation;

namespace EventHub.WebAPI.Validators
{
    public class EventParticipantValidator : AbstractValidator<EventParticipant>
    {
        public EventParticipantValidator() 
        {
            RuleFor(x => x.UserID).NotEmpty();
            RuleFor(x => x.EventID).NotEmpty();
        }
    }
}
