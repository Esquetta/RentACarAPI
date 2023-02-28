using Core.Security.Entities;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthService
{
    public interface IAuthService
    {
        public Task<AccessToken> CreateAccessToken(User user);
        public Task<RefreshToken> CreateRefreshToken(User user, string IpAddress);

        public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);

        public Task DeleteOldActiveRefreshTokens(User user);

        public Task RevokeRefreshToken(RefreshToken refreshToken, string IpAddress,string reason,string? replacedByToken);
        public Task RevokeDescendantRefreshTokens(RefreshToken token, string ipAddress, string reason);
        public Task<RefreshToken> RotateRefreshToken(User user,RefreshToken refreshToken,string ipAddress);
    }
}
