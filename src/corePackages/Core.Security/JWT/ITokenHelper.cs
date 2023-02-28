using Core.Security.Entities;

namespace Core.Security.JWT;

public interface ITokenHelper
{
    int  RefreshTokenTTLOption { get; }
    AccessToken CreateToken(User user, IList<OperationClaim> operationClaims);

    RefreshToken CreateRefreshToken(User user, string ipAddress);
}