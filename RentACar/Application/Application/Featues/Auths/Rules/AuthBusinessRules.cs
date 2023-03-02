using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
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
    }
}
