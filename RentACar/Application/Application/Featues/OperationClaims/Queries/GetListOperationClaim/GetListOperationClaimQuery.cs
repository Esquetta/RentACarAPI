using Application.Featues.OperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.OperationClaims.Queries.GetListOperationClaimQuery
{
    public class GetListOperationClaimQuery:IRequest<OperationClaimListViewModel>,ISecuredRequest
    {
        public string[] Roles { get; } = { "Admin,Moderator" };
        public PageRequest  PageRequest { get; set; }


        public class GetListOperationClaimQueryHandler:IRequestHandler<GetListOperationClaimQuery,OperationClaimListViewModel>
        {
            private readonly IOperationClaimRepository operationClaimRepository;
            private readonly IMapper mapper;

            public GetListOperationClaimQueryHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper)
            {
                this.operationClaimRepository = operationClaimRepository;
                this.mapper = mapper;
            }

            public async Task<OperationClaimListViewModel> Handle(GetListOperationClaimQuery request, CancellationToken cancellationToken)
            {
                IPaginate<OperationClaim> paginate = await operationClaimRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                OperationClaimListViewModel operationClaimListViewModel = mapper.Map<OperationClaimListViewModel>(paginate);

                return operationClaimListViewModel;
            }
        }

    }
}
