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

namespace Application.Featues.OperationClaims.Commands.DeleteOperationClaim
{
    public class DeleteOperationClaimCommand : IRequest<DeletedOperationClaimDto>
    {
        public int Id { get; set; }


        public class DeleteOperationClaimCommandHandler : IRequestHandler<DeleteOperationClaimCommand, DeletedOperationClaimDto>
        {
            private readonly IOperationClaimRepository operationClaimRepository;
            private readonly IMapper mapper;
            private readonly OperationClaimBusinessRules operationClaimBusinessRules;
            public DeleteOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                this.operationClaimRepository = operationClaimRepository;
                this.mapper = mapper;
                this.operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<DeletedOperationClaimDto> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
            {
                OperationClaim operationClaim = await operationClaimBusinessRules.OperationClaimCheckById(request.Id);

                OperationClaim deletedOperationClaim = await operationClaimRepository.DeleteAsync(operationClaim);

                DeletedOperationClaimDto deletedOperationClaimDto = mapper.Map<DeletedOperationClaimDto>(deletedOperationClaim);

                return deletedOperationClaimDto;
            }
        }
    }
}
