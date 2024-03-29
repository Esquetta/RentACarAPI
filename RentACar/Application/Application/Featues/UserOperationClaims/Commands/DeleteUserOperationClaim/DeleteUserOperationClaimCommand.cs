﻿using Application.Featues.UserOperationClaims.Dtos;
using Application.Featues.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.UserOperationClaims.Commands.UpdateUserOperationClaim
{
    public class DeleteUserOperationClaimCommand : IRequest<DeletedUserOperationClaimDto>,ISecuredRequest
    {

        public int OperationClaimId { get; set; }
        public int UserId { get; set; }
        public string[] Roles { get; } = { "Admin,Moderator" };

        public class DeleteUserOperationClaimCommandHandler : IRequestHandler<DeleteUserOperationClaimCommand, DeletedUserOperationClaimDto>
        {
            private readonly IMapper mapper;
            private readonly IUserOperationClaimRepository userOperationClaimRepository;
            private readonly UserOperationClaimBusinessRules userOperationClaimBusinessRules;
            public DeleteUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
            {
                this.mapper = mapper;
                this.userOperationClaimBusinessRules = userOperationClaimBusinessRules;
                this.userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<DeletedUserOperationClaimDto> Handle(DeleteUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await userOperationClaimBusinessRules.IsUserExist(request.UserId);
                await userOperationClaimBusinessRules.IsOperationExist(request.OperationClaimId);

                UserOperationClaim userOperationClaim = mapper.Map<UserOperationClaim>(request);

                UserOperationClaim mustDeleteClaim = await userOperationClaimRepository.GetAsync(x => x.UserId == request.UserId && x.OperationClaimId == request.OperationClaimId);

                UserOperationClaim deletedUserOperationClaim = await userOperationClaimRepository.DeleteAsync(mustDeleteClaim);

                DeletedUserOperationClaimDto deletedUserOperationClaimDto = mapper.Map<DeletedUserOperationClaimDto>(deletedUserOperationClaim);

                return deletedUserOperationClaimDto;
            }
        }
    }
}
