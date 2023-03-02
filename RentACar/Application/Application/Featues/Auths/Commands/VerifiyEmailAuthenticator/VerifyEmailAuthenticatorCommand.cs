using Application.Featues.Auths.Rules;
using Application.Services.Repositories;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Auths.Commands.VerifiyEmailAuthenticator
{
    public class VerifyEmailAuthenticatorCommand:IRequest
    {
        public string ActivationKey { get; set; }
        public string[] Roles => Array.Empty<string>();

        public class VerifyEmailAuthenticatorCommandHandler:IRequestHandler<VerifyEmailAuthenticatorCommand>
        {

            private readonly IEmailAuthenticatorRepository emailAuthenticatorRepository;
            private readonly AuthBusinessRules authBusinessRules;
            public VerifyEmailAuthenticatorCommandHandler(IEmailAuthenticatorRepository emailAuthenticatorRepository, AuthBusinessRules authBusinessRules)
            {
                this.emailAuthenticatorRepository = emailAuthenticatorRepository;
                this.authBusinessRules = authBusinessRules;
            }

            public async Task<Unit> Handle(VerifyEmailAuthenticatorCommand request, CancellationToken cancellationToken)
            {
                EmailAuthenticator emailAuthenticator = await emailAuthenticatorRepository.GetAsync(x => x.ActivationKey == request.ActivationKey,
                    include:x=>x.Include(a=>a.User));

                await authBusinessRules.UserEmailAuthenticatorShouldBeExists(emailAuthenticator);

                emailAuthenticator.IsVerified = true;
                emailAuthenticator.ActivationKey = null;
                emailAuthenticator.User.AuthenticatorType = Core.Security.Enums.AuthenticatorType.Email;
                await emailAuthenticatorRepository.UpdateAsync(emailAuthenticator);

                return Unit.Value;
            }
        }
    }
}
