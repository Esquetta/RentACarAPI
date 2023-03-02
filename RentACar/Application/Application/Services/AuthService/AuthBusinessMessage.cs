using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.AuthService
{
    public static  class AuthBusinessMessage
    {
        public const string AuthenticatorCodeSubject = "You have to enter code for login - RentACar";
        public const string InvalidAuthenticatorCode = "Invlaid code.";
        public const string UserNotFound = "User not found.";
        public const string InvlaidPassword = "Invlaid password";
        public const string RefreshTokenNotFound = "Refresh token not found";
        public const string RefreshTokenNotActive = "Refresh Token not active";
        public const string UserHasAuthenticator = "User has authenticator";
        public static string AuthenticatorCodeTextBody(string authenticatorCode)
            => $"Your Two factor authcode: {authenticatorCode.Substring(startIndex: 0, length: 3)} {authenticatorCode.Substring(3)}";
    }

}

