using Application.Featues.Auths.Dtos;
using Application.Featues.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Auths.Commands.Revoke
{
    public class RevokeCommand:IRequest<RevokedDto>
    {
        public string Token { get; set; }
        public string IpAddress { get; set; }


        public class RevokeCommandHandler:IRequestHandler<RevokeCommand,RevokedDto>
        {
            private readonly IRefreshTokenRepository refreshTokenRepository;
            private readonly AuthBusinessRules authBusinessRules;
            private readonly IAuthService authService;
            private readonly IMapper mapper;

            public RevokeCommandHandler(IRefreshTokenRepository refreshTokenRepository,AuthBusinessRules authBusinessRules,IAuthService authService,IMapper mapper)
            {
                this.authService = authService;
                this.authBusinessRules = authBusinessRules;
                this.refreshTokenRepository= refreshTokenRepository;
                this.mapper = mapper;
            }

            public async Task<RevokedDto> Handle(RevokeCommand request, CancellationToken cancellationToken)
            {
                RefreshToken? refreshToken = await refreshTokenRepository.GetAsync(x => x.Token == request.Token);

                await authBusinessRules.RefreshTokenShouldBeExists(refreshToken);

                await authBusinessRules.RefreshTokenShouldBeActive(refreshToken);


                await authService.RevokeRefreshToken(refreshToken, request.IpAddress, "Refresh token revoked by manual",null);

                RevokedDto revokedDto = mapper.Map<RevokedDto>(refreshToken);

                return revokedDto;
            }
        }
    }
}
