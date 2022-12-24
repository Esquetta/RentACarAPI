using Application.Featues.Auth.Dtos;
using Application.Featues.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Auth.Commands.Register
{
    public class RegisterCommand:IRequest<RefreshTokenDto>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }

        public string IpAddress { get; set; }


        public class RegisterCommandHandler:IRequestHandler<RegisterCommand, RefreshTokenDto>
        {
            private readonly IMapper mapper;
            private readonly IUserRepository userRepository;
            private readonly IAuthService authService;
            private readonly AuthBusinessRules authBusinessRules;
            public RegisterCommandHandler(IMapper mapper, IUserRepository userRepository, IAuthService authService, AuthBusinessRules authBusinessRules)
            {
                this.mapper = mapper;
                this.userRepository = userRepository;
                this.authService = authService;
                this.authBusinessRules = authBusinessRules;
            }

            public async Task<RefreshTokenDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                await authBusinessRules.IsUserExist(request.UserForRegisterDto.Email);

                byte[] hash, salt;
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password,out hash,out salt);

                User mappedUser =  mapper.Map<User>(request.UserForRegisterDto);

                mappedUser.PasswordHash = hash;
                mappedUser.PasswordSalt= salt;
                
                User createdUser = await userRepository.AddAsync(mappedUser);

                AccessToken accessToken = await authService.CreateAccessToken(createdUser);
                RefreshToken createdRefreshToken = await authService.CreateRefreshToken(createdUser, request.IpAddress);


                RefreshToken addedRefreshToken = await authService.AddRefreshToken(createdRefreshToken);


                RefreshTokenDto refreshTokenDto = new()
                {
                    AccessToken = accessToken,
                    RefreshToken = addedRefreshToken,
                };

                return refreshTokenDto;
            }
        }
    }
}
