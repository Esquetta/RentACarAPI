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

        public Task<EmailAuthenticator> CreateEmailAuthenticator(User user);

        public Task<OtpAuthenticator> CreateOtpAuthenticator(User user);

        public Task<string> ConvertOtpSecretKeyToString(byte[] secretBytes);

        public Task SendAuthenticatorCode(User user);

        public Task VerifyAuthenticatorCode(User user,string code);
    }
}
