﻿using Application.Services.AuthService;
using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IUserRepository userRepository;
        public AuthBusinessRules(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task IsUserExist(string email)
        {
            User user = await userRepository.GetAsync(x => x.Email == email);
            if (user != null) throw new BusinessException("Email taken  try new one.");
        }
        public async Task UserCheckForLogin(string email)
        {
            User user = await userRepository.GetAsync(x => x.Email == email);
            if (user == null) throw new BusinessException("Invalid username or password.");
        }
        public Task UserShouldBeExist(User? user)
        {
            if (user == null)
                throw new BusinessException(AuthBusinessMessage.UserNotFound);

            return Task.CompletedTask;
        }
        public Task UserPasswordCheck(User user, string password)
        {
            bool result = HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);

            if (result)
                throw new BusinessException(AuthBusinessMessage.InvlaidPassword);

            return Task.CompletedTask;
        }

        public Task RefreshTokenCheck(RefreshToken? refreshToken)
        {
            if (refreshToken == null)
                throw new BusinessException(AuthBusinessMessage.RefreshTokenNotFound);

            return Task.CompletedTask;
        }
        public Task IsRefreshTokenActive(RefreshToken refreshToken)
        {
            if (refreshToken.Revoked != null || (refreshToken.Revoked == null && refreshToken.Expires < DateTime.UtcNow))
                throw new BusinessException(AuthBusinessMessage.RefreshTokenNotActive);
            return Task.CompletedTask;
        }

        public Task NoneAuthentiactorCheck(User user)
        {
            if (user.AuthenticatorType is not AuthenticatorType.None)
                throw new BusinessException(AuthBusinessMessage.UserHasAuthenticator);
            return Task.CompletedTask;
        }
        public Task EmailAuthenticatorCheck(EmailAuthenticator emailAuthenticator)
        {
            if (emailAuthenticator is null)
                throw new BusinessException("Email authenticator not found.");
            return Task.CompletedTask;
        }
    }
}
