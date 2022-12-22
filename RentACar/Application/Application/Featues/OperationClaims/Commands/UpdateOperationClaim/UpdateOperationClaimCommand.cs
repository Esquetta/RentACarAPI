using Application.Featues.OperationClaims.Dtos;
using Application.Featues.OperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.OperationClaims.Commands.UpdateOperationClaim
{
    public class UpdateOperationClaimCommand:IRequest<UpdatedOperationClaimDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateOperationClaimCommandHandler:IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimDto>
        {
            private readonly IOperationClaimRepository operationClaimRepository;
            private readonly OperationClaimBusinessRules operationClaimBusinessRules;
            private readonly IMapper mapper;
            public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, OperationClaimBusinessRules operationClaimBusinessRules, IMapper mapper)
            {
                this.operationClaimRepository = operationClaimRepository;
                this.operationClaimBusinessRules = operationClaimBusinessRules;
                this.mapper = mapper;
            }

            public async Task<UpdatedOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await operationClaimBusinessRules.OperationClaimCannotBeDuplicatedWhenUpdated(request.Name);

                OperationClaim operationClaim = mapper.Map<OperationClaim>(request.Name);

                OperationClaim updatedOperationClaim = await operationClaimRepository.UpdateAsync(operationClaim);

                UpdatedOperationClaimDto updatedOperationClaimDto = mapper.Map<UpdatedOperationClaimDto>(updatedOperationClaim);

                return updatedOperationClaimDto;
            }
        }
    }
}
