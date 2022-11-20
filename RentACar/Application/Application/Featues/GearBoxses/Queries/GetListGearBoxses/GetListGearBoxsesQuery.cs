using Application.Featues.GearBoxses.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.GearBoxses.Queries.GetListGearBoxses
{
    public class GetListGearBoxsesQuery:IRequest<GearBoxListViewModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListGearBoxsesQueryHandler:IRequestHandler<GetListGearBoxsesQuery,GearBoxListViewModel>
        {
            private readonly IGearBoxRepository gearBoxRepository;
            private readonly IMapper mapper;
            public GetListGearBoxsesQueryHandler(IGearBoxRepository gearBoxRepository,IMapper mapper)
            {
                this.mapper = mapper;
                this.gearBoxRepository = gearBoxRepository;
            }

            public async Task<GearBoxListViewModel> Handle(GetListGearBoxsesQuery request, CancellationToken cancellationToken)
            {
                IPaginate<GearBox> paginate = await gearBoxRepository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize);

                GearBoxListViewModel gearBoxListViewModel = mapper.Map<GearBoxListViewModel>(paginate);

                return gearBoxListViewModel;
            }
        }
    }
}
