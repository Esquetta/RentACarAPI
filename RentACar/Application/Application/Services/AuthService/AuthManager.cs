using Application.Services.Repositories;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.JWT;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthService
{
    public class AuthManager : IAuthService
    {
        private readonly IRefreshTokenRepository refreshTokenRepository;
        private readonly ITokenHelper tokenHelper;
        private readonly IUserOperationClaimRepository userOperationClaimRepository;
        public AuthManager(IRefreshTokenRepository refreshTokenRepository, ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository)
        {
            this.refreshTokenRepository = refreshTokenRepository;
            this.tokenHelper = tokenHelper;
            this.userOperationClaimRepository = userOperationClaimRepository;
        }

        public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
        {
            RefreshToken addedRefreshToken = await refreshTokenRepository.AddAsync(refreshToken);
            return addedRefreshToken;
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            IPaginate<UserOperationClaim> userOperationClaims = await userOperationClaimRepository.GetListAsync(x=>x.UserId==user.Id
            ,include:x=>x.Include(x=>x.OperationClaim));
            List<OperationClaim> claims = userOperationClaims.Items.Select(x => new OperationClaim {Id=x.OperationClaim.Id,Name=x.OperationClaim.Name }).ToList();
            AccessToken accessToken = tokenHelper.CreateToken(user, claims);
            return accessToken;
        }

        public async Task<RefreshToken> CreateRefreshToken(User user, string IpAddress)
        {
            RefreshToken refreshToken = tokenHelper.CreateRefreshToken(user, IpAddress);
            return refreshToken;
        }
    }
}
