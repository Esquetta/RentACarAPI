using Application.Featues.Auth.Dtos;
using Application.Featues.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Featues.Auths.Commands.Refresh
{
    public class RefreshCommand : IRequest<RefreshTokenDto>
    {
        public string RefreshToken { get; set; }
        public string IpAddress { get; set; }

        public class RefreshCommandHandler : IRequestHandler<RefreshCommand, RefreshTokenDto>
        {

            private readonly IRefreshTokenRepository refreshTokenRepository;
            private readonly IAuthService authService;
            private readonly IUserRepository userRepository;
            private readonly AuthBusinessRules authBusinessRules;
            public RefreshCommandHandler(IRefreshTokenRepository refreshTokenRepository, IAuthService authService, IUserRepository userRepository, AuthBusinessRules authBusinessRules)
            {
                this.refreshTokenRepository = refreshTokenRepository;
                this.authService = authService;
                this.userRepository = userRepository;
                this.authBusinessRules = authBusinessRules;
            }

            public async Task<RefreshTokenDto> Handle(RefreshCommand request, CancellationToken cancellationToken)
            {
                RefreshToken? refreshToken = await refreshTokenRepository.GetAsync(x => x.Token == request.RefreshToken
                , include: x => x.Include(x => x.User));

                await authBusinessRules.RefreshTokenShouldBeExists(refreshToken);

                if (refreshToken!.Revoked != null)
                    await authService.RevokeDescendantRefreshTokens(refreshToken, request.IpAddress, "Tried to use inactive refresh token.");
                await authBusinessRules.RefreshTokenShouldBeActive(refreshToken);

                AccessToken createdAccessToken = await authService.CreateAccessToken(refreshToken.User);
                RefreshToken createdRefreshToken = await authService.RotateRefreshToken(refreshToken.User, refreshToken, request.IpAddress);

                return new RefreshTokenDto() { AccessToken = createdAccessToken, RefreshToken = createdRefreshToken };


            }
        }

    }
}
