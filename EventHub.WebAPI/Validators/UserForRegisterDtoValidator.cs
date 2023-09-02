using EventHub.BL.Abstract;
using EventHub.Entities.DTOs;
using FluentValidation;
using System.Text.RegularExpressions;

namespace EventHub.WebAPI.Validators
{
    public class UserForRegisterDtoValidator : AbstractValidator<UserForRegisterDto>
    {
        IUserService _userService;
        public UserForRegisterDtoValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress().WithMessage("{PropertyValue} geçerli bir e-posta adresi değil");
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8).WithMessage("Parolanız en az 8 karakterli olmalı")
                .Must(IsPasswordValid).WithMessage("En az bir harf ve bir sayı içermelidir.")
                .Equal(x => x.PasswordRepeat).WithMessage("Parolalar eşleşmiyor");
            RuleFor(x => x.PasswordRepeat).NotEmpty();
        }
        private bool IsPasswordValid(string arg)
        {
            Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,}$");
            return regex.IsMatch(arg);
        }
    }
}
