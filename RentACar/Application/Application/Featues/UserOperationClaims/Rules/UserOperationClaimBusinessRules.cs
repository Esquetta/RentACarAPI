using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository operationClaimRepository;
        private readonly IUserRepository userRepository;
        private readonly IUserOperationClaimRepository userOperationClaimRepository;
        public UserOperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository, IUserRepository userRepository, IUserOperationClaimRepository userOperationClaimRepository)
        {
            this.operationClaimRepository = operationClaimRepository;
            this.userRepository = userRepository;
            this.userOperationClaimRepository = userOperationClaimRepository;
        }
        public async Task IsOperationExist(int operationId)
        {
            OperationClaim result = await operationClaimRepository.GetAsync(x => x.Id == operationId);
            if (result == null) throw new BusinessException("Operation is invlaid");
        }
        public async Task IsUserExist(int userId)
        {
            User result = await userRepository.GetAsync(x => x.Id == userId);
            if (result == null) throw new BusinessException("User not found");
        }

        public async Task UserOperationClaimCannotBeDublicatedWhenInserted(int userId, int operationId)
        {
            UserOperationClaim result = await userOperationClaimRepository.GetAsync(x => x.OperationClaimId == operationId && x.UserId == userId);
            if (result != null) throw new BusinessException("Values already in database.");
        }
    }
}
