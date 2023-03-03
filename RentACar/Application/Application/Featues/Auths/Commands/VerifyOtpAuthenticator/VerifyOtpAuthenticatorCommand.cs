using Application.Featues.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Auths.Commands.VerifyOtpAuthenticator
{
    public class VerifyOtpAuthenticatorCommand:IRequest,ISecuredRequest
    {
        public int UserId { get; set; }
        public string OtpCode { get; set; }

        public string[] Roles => Array.Empty<string>();


        public class VerifyOtpAuthenticatorCommandHandler:IRequestHandler<VerifyOtpAuthenticatorCommand>
        {
            private readonly IAuthService authService;
            private readonly IOtpAuthenticatorRepository otpAuthenticatorRepository;
            private readonly AuthBusinessRules authBusinessRules;

            public VerifyOtpAuthenticatorCommandHandler(IAuthService authService, IOtpAuthenticatorRepository otpAuthenticatorRepository, AuthBusinessRules authBusinessRules)
            {
                this.authService = authService;
                this.otpAuthenticatorRepository = otpAuthenticatorRepository;
                this.authBusinessRules = authBusinessRules;
            }

            public async Task<Unit> Handle(VerifyOtpAuthenticatorCommand request, CancellationToken cancellationToken)
            {
                OtpAuthenticator authenticator = await otpAuthenticatorRepository.GetAsync(x=>x.UserId==request.UserId,
                    include:x=>x.Include(x=>x.User));

                await authBusinessRules.UserOtpAuthenticatorShouldBeExists(authenticator);

                authenticator!.User.AuthenticatorType = Core.Security.Enums.AuthenticatorType.Otp;

                await authService.VerifyAuthenticatorCode(authenticator.User, request.OtpCode);

                authenticator.IsVerified=true;
                await otpAuthenticatorRepository.UpdateAsync(authenticator);

                return Unit.Value;

            }
        }
    }
}
