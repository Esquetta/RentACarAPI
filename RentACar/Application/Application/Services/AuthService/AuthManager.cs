using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Core.Security.JWT;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core.Tokenizer;
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

        public async Task DeleteOldActiveRefreshTokens(User user)
        {
            ICollection<RefreshToken> oldActiveRefreshTokens = await refreshTokenRepository.GetAllOldActiveRefreshTokenAsync(user, tokenHelper.RefreshTokenTTLOption);

            await refreshTokenRepository.DeleteRangeAsync(oldActiveRefreshTokens.ToList());
           
        }

        public async Task RevokeDescendantRefreshTokens(RefreshToken token, string ipAddress, string reason)
        {
            RefreshToken childRefreshToken = (await refreshTokenRepository.GetAsync(rt=>token.ReplacedByToken==rt.Token))!;
            if (childRefreshToken == null) throw new BusinessException("Couldn't find child token for this current token.");


            if (childRefreshToken.Revoked == null) await RevokeRefreshToken(childRefreshToken, ipAddress, reason);
            else await RevokeDescendantRefreshTokens(childRefreshToken, ipAddress, reason);
        }

        public async Task RevokeRefreshToken(RefreshToken refreshToken, string IpAddress, string reason, string? replacedByToken=null)
        {
            refreshToken.RevokedByIp = IpAddress;
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.ReasonRevoked = reason;
            refreshToken.ReplacedByToken = replacedByToken;
            await refreshTokenRepository.UpdateAsync(refreshToken);
        }

        public async Task<RefreshToken> RotateRefreshToken(User user, RefreshToken refreshToken, string ipAddress)
        {
            RefreshToken newToken = tokenHelper.CreateRefreshToken(user, ipAddress);
            await RevokeRefreshToken(refreshToken, "New Refresh Token Created.", newToken.Token);
            await AddRefreshToken(newToken);
            return newToken;
        }
    }
}
