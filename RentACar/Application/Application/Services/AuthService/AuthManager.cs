using Core.Security.Entities;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthService
{
    public class AuthManager : IAuthService
    {
        public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<AccessToken> CreateAccessToken(User user)
        {
            throw new NotImplementedException();
        }

        public Task<RefreshToken> CreateRefreshToken(User user, string IpAddress)
        {
            throw new NotImplementedException();
        }
    }
}
