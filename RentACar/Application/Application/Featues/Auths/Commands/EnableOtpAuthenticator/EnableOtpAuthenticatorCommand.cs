using Application.Featues.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;

namespace Application.Featues.Auths.Commands.EnableOtpAuthenticator
{
    public class EnableOtpAuthenticatorCommand:IRequest<EnabledOtpAuthenticatorResponse>,ISecuredRequest
    {
        public int UserId { get; set; }
        public string SecretKeyLabel { get; set; }
        public string SecretKeyIssuer { get; set; }

        public string[] Roles => Array.Empty<string>();

        public class EnableOtpAuthenticatorCommandHandler : IRequestHandler<EnableOtpAuthenticatorCommand, EnabledOtpAuthenticatorResponse>
        {
            private readonly IUserRepository userRepository;
            private readonly AuthBusinessRules authBusinessRules;
            private readonly IAuthService authService;
            private readonly IOtpAuthenticatorRepository otpAuthenticatorRepository;
            public EnableOtpAuthenticatorCommandHandler(IUserRepository userRepository, AuthBusinessRules authBusinessRules, IAuthService authService, IOtpAuthenticatorRepository otpAuthenticatorRepository)
            {
                this.userRepository = userRepository;
                this.authBusinessRules = authBusinessRules;
                this.authService = authService;
                this.otpAuthenticatorRepository = otpAuthenticatorRepository;
            }

            public async Task<EnabledOtpAuthenticatorResponse> Handle(EnableOtpAuthenticatorCommand request, CancellationToken cancellationToken)
            {
                User? user=await userRepository.GetAsync(x=>x.Id==request.UserId);

                await authBusinessRules.UserShouldBeExists(user);
                await authBusinessRules.UserShouldNotBeHasAuthenticator(user);

                await otpAuthenticatorRepository.DeleteAllNonVerifiedAsync(user);

                OtpAuthenticator createdotpAuthenticator = await authService.CreateOtpAuthenticator(user);
                await otpAuthenticatorRepository.AddAsync(createdotpAuthenticator);

                string base32SecretKey = await authService.ConvertOtpSecretKeyToString(createdotpAuthenticator.SecretKey);

                EnabledOtpAuthenticatorResponse response = new()
                {
                    SecretKey= base32SecretKey,
                    SecketKeyUrl=$"otpauth://totp/{request.SecretKeyLabel}?secret={base32SecretKey}&issuer{request.SecretKeyIssuer}"
                };

                return response;

            }
        }


    }
}
