using Application.Featues.Fuels.Models;
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

namespace Application.Featues.Fuels.Queries.GetListFuels
{
    public class GetListFuelQuery:IRequest<FuelListViewModel>
    {
        public PageRequest  PageRequest { get; set; }


        public class GetListFuelQueryHandler:IRequestHandler<GetListFuelQuery, FuelListViewModel>
        {
            private readonly IFuelRepository fuelRepository;
            private readonly IMapper mapper;

            public GetListFuelQueryHandler(IFuelRepository fuelRepository, IMapper mapper)
            {
                this.fuelRepository = fuelRepository;
                this.mapper = mapper;
            }

            public async Task<FuelListViewModel> Handle(GetListFuelQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Fuel> paginate = await fuelRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                FuelListViewModel fuelListViewModel = mapper.Map<FuelListViewModel>(paginate);

                return fuelListViewModel;
            }
        }
    }
}
