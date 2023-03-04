using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Mailing;
using Core.Persistence.Paging;
using Core.Security.EmailAuthenticator;
using Core.Security.Entities;
using Core.Security.JWT;
using Core.Security.OtpAuthenticator;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.AuthService
{
    public class AuthManager : IAuthService
    {
        private readonly IRefreshTokenRepository refreshTokenRepository;
        private readonly ITokenHelper tokenHelper;
        private readonly IUserOperationClaimRepository userOperationClaimRepository;
        private readonly IEmailAuthenticatorHelper emailAuthenticatorHelper;
        private readonly IEmailAuthenticatorRepository emailAuthenticatorRepository;
        private readonly IMailService mailService;
        private readonly IOtpAuthenticatorRepository otpAuthenticatorRepository;
        private readonly IOtpAuthenticatorHelper otpAuthenticatorHelper;
        public AuthManager(IRefreshTokenRepository refreshTokenRepository, ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository,
            IEmailAuthenticatorHelper emailAuthenticatorHelper, IEmailAuthenticatorRepository emailAuthenticatorRepository, IMailService mailService, IOtpAuthenticatorRepository otpAuthenticatorRepository, IOtpAuthenticatorHelper otpAuthenticatorHelper)
        {
            this.refreshTokenRepository = refreshTokenRepository;
            this.tokenHelper = tokenHelper;
            this.userOperationClaimRepository = userOperationClaimRepository;
            this.otpAuthenticatorHelper = otpAuthenticatorHelper;
            this.otpAuthenticatorRepository = otpAuthenticatorRepository;
            this.mailService = mailService;
            this.emailAuthenticatorRepository = emailAuthenticatorRepository;
            this.emailAuthenticatorHelper = emailAuthenticatorHelper;
        }

        public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
        {
            RefreshToken addedRefreshToken = await refreshTokenRepository.AddAsync(refreshToken);
            return addedRefreshToken;
        }

        public Task<string> ConvertOtpSecretKeyToString(byte[] secretBytes)
        {
           return  otpAuthenticatorHelper.ConvertSecretKeyToString(secretBytes);
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            IPaginate<UserOperationClaim> userOperationClaims = await userOperationClaimRepository.GetListAsync(x => x.UserId == user.Id
            , include: x => x.Include(x => x.OperationClaim));
            List<OperationClaim> claims = userOperationClaims.Items.Select(x => new OperationClaim { Id = x.OperationClaim.Id, Name = x.OperationClaim.Name }).ToList();
            AccessToken accessToken = tokenHelper.CreateToken(user, claims);
            return accessToken;
        }

        public async Task<EmailAuthenticator> CreateEmailAuthenticator(User user)
        {
            return new EmailAuthenticator()
            {
                UserId = user.Id,
                ActivationKey = await emailAuthenticatorHelper.CreateEmailActivationKey(),
                IsVerified = false
            };
        }

        public async Task<OtpAuthenticator> CreateOtpAuthenticator(User user)
        {
            return new OtpAuthenticator()
            {
                UserId=user.Id,
                IsVerified= false,
                SecretKey=await otpAuthenticatorHelper.GenerateSecretKey()
            };
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
            RefreshToken childRefreshToken = (await refreshTokenRepository.GetAsync(rt => token.ReplacedByToken == rt.Token))!;
            if (childRefreshToken == null) throw new BusinessException("Couldn't find child token for this current token.");


            if (childRefreshToken.Revoked == null) await RevokeRefreshToken(childRefreshToken, ipAddress, reason);
            else await RevokeDescendantRefreshTokens(childRefreshToken, ipAddress, reason);
        }

        public async Task RevokeRefreshToken(RefreshToken refreshToken, string IpAddress, string reason, string? replacedByToken = null)
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
            await RevokeRefreshToken(refreshToken,ipAddress,"New Refresh Token Created.", newToken.Token);
            await AddRefreshToken(newToken);
            return newToken;
        }

        public async Task SendAuthenticatorCode(User user)
        {
            switch (user.AuthenticatorType)
            {
                case Core.Security.Enums.AuthenticatorType.Email:
                    await sendAuthenticatorCodeWithEmail(user);
                    break;

            }
        }

        private async Task sendAuthenticatorCodeWithEmail(User user)
        {
            EmailAuthenticator emailAuthenticator = await emailAuthenticatorRepository.GetAsync(x => x.UserId == user.Id);
            string authCode = await emailAuthenticatorHelper.CreateEmailActivationCode();

            emailAuthenticator.ActivationKey=authCode;

            await emailAuthenticatorRepository.UpdateAsync(emailAuthenticator);

            Mail mail = new() {
            
                ToFullName=$"{user.FirstName} {user.LastName}",
                ToEmail=user.Email,
                Subject=AuthBusinessMessage.AuthenticatorCodeSubject,
                TextBody=AuthBusinessMessage.AuthenticatorCodeTextBody(authCode)

            };

            mailService.SendMail(mail);

        }

        public async Task VerifyAuthenticatorCode(User user, string code)
        {
            switch (user.AuthenticatorType)
            {

                case Core.Security.Enums.AuthenticatorType.Email:
                    await verifyEmailAuthenticatorCode(user,code);
                    break;
                case Core.Security.Enums.AuthenticatorType.Otp:
                    await verifyOtpAuthenticatorCode(user, code);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private async Task verifyOtpAuthenticatorCode(User user, string codeToVerify)
        {
            OtpAuthenticator otpAuthenticator = await otpAuthenticatorRepository.GetAsync(x=>x.UserId==user.Id);

            bool result = await otpAuthenticatorHelper.VerifyCode(otpAuthenticator.SecretKey, codeToVerify);

            if (!result)
                throw new BusinessException(AuthBusinessMessage.InvalidAuthenticatorCode);
        }

        private async Task verifyEmailAuthenticatorCode(User user, string code)
        {
            EmailAuthenticator emailAuthenticator = await emailAuthenticatorRepository.GetAsync(x=>x.UserId==user.Id);

            if(emailAuthenticator.ActivationKey!=null)
                throw new BusinessException(AuthBusinessMessage.InvalidAuthenticatorCode);

            await emailAuthenticatorRepository.UpdateAsync(emailAuthenticator);


        }
    }
}
