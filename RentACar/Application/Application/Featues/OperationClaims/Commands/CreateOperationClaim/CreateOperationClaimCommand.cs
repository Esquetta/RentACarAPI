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

namespace Application.Featues.OperationClaims.Commands.CreateOperationClaim
{
    public class CreateOperationClaimCommand : IRequest<CreatedOperationClaimDto>
    {
        public string Name { get; set; }
        public class CreateOperationClaimCommandHandler : IRequestHandler<CreateOperationClaimCommand, CreatedOperationClaimDto>
        {
            private readonly IOperationClaimRepository operationClaimRepository;
            private readonly OperationClaimBusinessRules operationClaimBusinessRules;
            private readonly IMapper mapper;
            public CreateOperationClaimCommandHandler(IOperationClaimRepository operationClaim,OperationClaimBusinessRules operationClaimBusinessRules,IMapper mapper)
            {
                this.mapper = mapper;
                this.operationClaimBusinessRules = operationClaimBusinessRules;
                this.operationClaimRepository = operationClaimRepository;
            }

            public async Task<CreatedOperationClaimDto> Handle(CreateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await operationClaimBusinessRules.OperationClaimCannotBeDuplicatedWhenInserted(request.Name);

                OperationClaim operationClaim = mapper.Map<OperationClaim>(request);

                OperationClaim createdOperationClaim = await operationClaimRepository.AddAsync(operationClaim);

                CreatedOperationClaimDto createdOperationClaimDto = mapper.Map<CreatedOperationClaimDto>(createdOperationClaim);

                return createdOperationClaimDto;
            }
        }
    }
}
