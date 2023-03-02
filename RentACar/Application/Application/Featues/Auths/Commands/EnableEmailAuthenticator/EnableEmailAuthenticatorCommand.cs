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
    public class EnableEmailAuthenticatorCommand : IRequest, ISecuredRequest
    {
        public int UserId { get; set; }
        public string VerifyEmailUrl { get; set; }
        public string[] Roles => Array.Empty<string>();


        public class EnableEmailAuthenticatorCommandHandler : IRequestHandler<EnableEmailAuthenticatorCommand>
        {
            private readonly IUserRepository userRepository;
            private readonly IEmailAuthenticatorRepository emailAuthenticatorRepository;
            private readonly IAuthService authService;
            private readonly IMailService mailService;
            private readonly AuthBusinessRules authBusinessRules;

            public EnableEmailAuthenticatorCommandHandler(IUserRepository userRepository, IEmailAuthenticatorRepository emailAuthenticatorRepository, IAuthService authService, IMailService mailService, AuthBusinessRules authBusinessRules)
            {
                this.userRepository = userRepository;
                this.emailAuthenticatorRepository = emailAuthenticatorRepository;
                this.authService = authService;
                this.mailService = mailService;
                this.authBusinessRules = authBusinessRules;
            }

            public async Task<Unit> Handle(EnableEmailAuthenticatorCommand request, CancellationToken cancellationToken)
            {
                User? user = await userRepository.GetAsync(x => x.Id == request.UserId);

                await authBusinessRules.UserShouldBeExist(user);

                await authBusinessRules.NoneAuthentiactorCheck(user);

                await emailAuthenticatorRepository.DeleteAllNonVerifiedAsync(user!);

                EmailAuthenticator emailAuthenticator = await authService.CreateEmailAuthenticator(user!);

                await emailAuthenticatorRepository.AddAsync(emailAuthenticator);

                Mail mail = new() {
                 
                    ToEmail= user.Email,
                    ToFullName=$"{user.FirstName} {user.LastName}",
                    Subject="Verify Email",
                    TextBody=$"Hi {user.FirstName},\n Here is your email {request.VerifyEmailUrl}?activationKey={HttpUtility.UrlEncode(emailAuthenticator.ActivationKey)}"
                
                };

                mailService.SendMail(mail);

                return Unit.Value;

            }
        }

    }
}
