using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Auths.Commands.EnableOtpAuthenticator
{
    public class EnableOtpAuthenticatorCommandValidator:AbstractValidator<EnableOtpAuthenticatorCommand>
    {
        public EnableOtpAuthenticatorCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
        }
    }
}
