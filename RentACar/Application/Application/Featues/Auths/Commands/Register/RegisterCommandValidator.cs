using Application.Featues.Auth.Commands.Register;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Auths.Commands.Register
{
    public class RegisterCommandValidator:AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.UserForRegisterDto.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.UserForRegisterDto.FirstName).NotEmpty();
            RuleFor(x => x.UserForRegisterDto.LastName).NotEmpty();
            RuleFor(x => x.UserForRegisterDto.Password).NotEmpty().MinimumLength(6).MaximumLength(20);
        }
    }
}
