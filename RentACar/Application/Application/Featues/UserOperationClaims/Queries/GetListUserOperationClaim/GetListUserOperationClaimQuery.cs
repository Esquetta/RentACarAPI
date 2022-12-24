using Application.Featues.UserOperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.UserOperationClaims.Queries.GetListUserOperationClaim
{
    public class GetListUserOperationClaimQuery:IRequest<UserOperationClaimListViewModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListUserOperationClaimQueryHandler:IRequestHandler<GetListUserOperationClaimQuery,UserOperationClaimListViewModel>
        {
            private readonly IMapper mapper;
            private readonly IUserOperationClaimRepository userOperationClaimRepository;
            public GetListUserOperationClaimQueryHandler(IUserOperationClaimRepository userOperationClaimRepository,IMapper mapper )
            {
                this.mapper = mapper;
                this.userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<UserOperationClaimListViewModel> Handle(GetListUserOperationClaimQuery request, CancellationToken cancellationToken)
            {
                IPaginate<UserOperationClaim> paginate = await userOperationClaimRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                UserOperationClaimListViewModel userOperationClaimListViewModel = mapper.Map<UserOperationClaimListViewModel>(paginate);

                return userOperationClaimListViewModel;
            } 
        }
    }
}
