using Application.Featues.Auths.Dtos;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.JWT;

namespace Application.Featues.Auth.Dtos
{
    public class LoggedUserDto
    {
        public AccessToken? AccessToken { get; set; }
        public CreatedRefreshTokenDTO? RefreshToken { get; set; }
        public AuthenticatorType? RequiredAuthenticatorType { get; set; }

        public class LoggedHttpResponse
        {
            public AccessToken? AccessToken { get; set; }
            public AuthenticatorType? RequiredAuthenticatorType { get; set; }
        }

        public LoggedHttpResponse ToHttpResponse()
        {
            return new()
            {
                AccessToken = AccessToken,
                RequiredAuthenticatorType = RequiredAuthenticatorType
            };
        }
    }
}
