using Application.Featues.Auth.Dtos;
using Application.Featues.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
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
    public class LoginCommand:IRequest<LoggedUserDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }


        public class LoginCommandHandler:IRequestHandler<LoginCommand, LoggedUserDto>
        {
            private readonly IMapper mapper;
            private readonly IUserRepository userRepository;
            private readonly ITokenHelper tokenHelper;
            private readonly IAuthService authService;
            private readonly AuthBusinessRules authBusinessRules;
            public LoginCommandHandler(IUserRepository userRepository,IMapper mapper,ITokenHelper tokenHelper,IAuthService authService,AuthBusinessRules authBusinessRules)
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
                    return null;

                AccessToken accessToken = await authService.CreateAccessToken(user);

                LoggedUserDto loggedUserDto = mapper.Map<LoggedUserDto>(accessToken);

                return loggedUserDto;
            }
        }
    }
}
