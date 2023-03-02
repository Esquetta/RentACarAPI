using Application.Featues.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.Application.Pipelines.Authorization;
using Core.Mailing;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Application.Featues.Auths.Commands.EnableEmailAuthenticator
{
    public class EnableEmailAuthenticatorCommand:IRequest,ISecuredRequest
    {
        public int UserId { get; set; }
        public string VerifyEmailUrl { get; set; }
        public string[] Roles => Array.Empty<string>();


        public class EnableEmailAuthenticatorCommandHandler : IRequestHandler<EnableEmailAuthenticatorCommand>
        {
            private readonly IUserRepository userRepository;
            private readonly AuthBusinessRules authBusinessRules;
            private readonly IEmailAuthenticatorRepository emailAuthenticatorRepository;
            private readonly IAuthService authService;
            private readonly IMailService mailService;
            public EnableEmailAuthenticatorCommandHandler(IUserRepository userRepository, AuthBusinessRules authBusinessRules, IEmailAuthenticatorRepository emailAuthenticatorRepository, IAuthService authService, IMailService mailService)
            {
                this.userRepository = userRepository;
                this.authBusinessRules = authBusinessRules;
                this.emailAuthenticatorRepository = emailAuthenticatorRepository;
                this.authService = authService;
                this.mailService = mailService;
            }

            public async Task<Unit> Handle(EnableEmailAuthenticatorCommand request, CancellationToken cancellationToken)
            {
               User? user = await userRepository.GetAsync(x=>x.Id==request.UserId);

                await authBusinessRules.UserShouldBeExists(user);

                await authBusinessRules.UserShouldNotBeHasAuthenticator(user);

                await emailAuthenticatorRepository.DeleteAllNonVerifiedAsync(user);

                EmailAuthenticator emailAuthenticator = await authService.CreateEmailAuthenticator(user);

                await emailAuthenticatorRepository.AddAsync(emailAuthenticator);

                Mail mail = new()
                {
                    ToEmail = user!.Email,
                    ToFullName = $"{user.FirstName} {user.LastName}",
                    Subject = "Email Authenticator",
                    TextBody = $"Hi {user.FirstName} {user.LastName} here is your  email auth code \n" +
                           $"{request.VerifyEmailUrl}?activationKey={HttpUtility.UrlEncode(emailAuthenticator.ActivationKey)}"
                };

                return Unit.Value;
            }
        }
    }
}
