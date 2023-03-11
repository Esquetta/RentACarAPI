using Application.Featues.Auth.Dtos;
using Application.Featues.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Auth.Commands.Login
{
    public class LoginCommand : IRequest<LoggedUserDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string IpAddress { get; set; }


        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedUserDto>
        {
            private readonly IMapper mapper;
            private readonly IUserRepository userRepository;
            private readonly ITokenHelper tokenHelper;
            private readonly IAuthService authService;
            private readonly AuthBusinessRules authBusinessRules;
            public LoginCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper, IAuthService authService, AuthBusinessRules authBusinessRules)
            {
                this.mapper = mapper;
                this.tokenHelper = tokenHelper;
                this.authBusinessRules = authBusinessRules;
                this.userRepository = userRepository;
                this.authService = authService;
            }

            public async Task<LoggedUserDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                await authBusinessRules.UserCheckForLogin(request.UserForLoginDto.Email);


                var user = await userRepository.GetAsync(x => x.Email == request.UserForLoginDto.Email);

                var result = HashingHelper.VerifyPasswordHash(request.UserForLoginDto.Password, user.PasswordHash, user.PasswordSalt);

                if (!result)
                    throw new BusinessException("Invlaid email or password.");

                LoggedUserDto loggedUserDto = new();

                if (user!.AuthenticatorType is not AuthenticatorType.None)
                {
                    if (request.UserForLoginDto.AuthenticatorCode is null)
                    {
                        await authService.SendAuthenticatorCode(user);
                        loggedUserDto.RequiredAuthenticatorType = user.AuthenticatorType;
                        return loggedUserDto;

                    }
                    else
                    {
                        await authService.VerifyAuthenticatorCode(user, request.UserForLoginDto.AuthenticatorCode);
                    }
                }

                AccessToken accessToken = await authService.CreateAccessToken(user);
                await authService.DeleteOldActiveRefreshTokens(user);
                RefreshToken refreshToken = await authService.CreateRefreshToken(user, request.IpAddress);
                await authService.AddRefreshToken(refreshToken);


                loggedUserDto.AccessToken = accessToken;
                loggedUserDto.RefreshToken= refreshToken; ;

                return loggedUserDto;
            }
        }
    }
}
