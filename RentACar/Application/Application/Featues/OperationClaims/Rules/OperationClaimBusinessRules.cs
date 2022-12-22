using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository operationClaimRepository;
        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            this.operationClaimRepository= operationClaimRepository;
        }
        public async Task OperationClaimCannotBeDuplicatedWhenInserted(string name)
        {
            OperationClaim operationClaim = await operationClaimRepository.GetAsync(x => x.Name == name);
            if (operationClaim != null) throw new BusinessException("OperationClaim exists.");
        }
        public async Task OperationClaimCannotBeDuplicatedWhenUpdated(string name)
        {
            OperationClaim operationClaim = await operationClaimRepository.GetAsync(x => x.Name == name);
            if (operationClaim != null) throw new BusinessException("OperationClaim  exists.");
        }
        public async Task<OperationClaim> OperationClaimCheckById(int id)
        {
            OperationClaim operationClaim = await operationClaimRepository.GetAsync(x => x.Id == id);
            if (operationClaim == null) throw new BusinessException("OperationClaim not exists.");

            return operationClaim;
        }
    }
}
