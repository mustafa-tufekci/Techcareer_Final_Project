using EventHub.Entities.DTOs;
using FluentValidation;
using System.Text.RegularExpressions;

namespace EventHub.WebAPI.Validators
{
    public class UserToUpdateDtoValidator : AbstractValidator<UserToUpdateDto>
    {
        public UserToUpdateDtoValidator()
        {
            RuleFor(x => x.UserID).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.NewPassword).NotEmpty().MinimumLength(8).WithMessage("Parolanız en az 8 karakterli olmalı")
                .Must(IsPasswordValid).WithMessage("En az bir harf ve bir sayı içermelidir.");
        }
        private bool IsPasswordValid(string arg)
        {
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            return regex.IsMatch(arg);
        }
    }
}
