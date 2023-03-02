using Application.Featues.Auths.Rules;
using Application.Services.Repositories;
using Core.Security.Entities;
using Core.Security.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Featues.Auths.Commands.VerifiyEmailAuthenticator
{
    public class VerifyEmailAuthenticatorCommand : IRequest
    {
        // public int UserId { get; set; }

        public string ActivationKey { get; set; }
        public string[] Roles => Array.Empty<string>();

        public class VerifyEmailAuthenticatorCommandHandler : IRequestHandler<VerifyEmailAuthenticatorCommand>
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
                EmailAuthenticator emailAuthenticator = await emailAuthenticatorRepository.GetAsync(predicate: x => x.ActivationKey == request.ActivationKey,
                    include: x => x.Include(x => x.User));

                await authBusinessRules.EmailAuthenticatorCheck(emailAuthenticator);

                emailAuthenticator.IsVerified = true;
                emailAuthenticator.ActivationKey = null;
                emailAuthenticator.User.AuthenticatorType = AuthenticatorType.Email;
                await emailAuthenticatorRepository.UpdateAsync(emailAuthenticator);

                return Unit.Value;
            }
        }
    }
}
