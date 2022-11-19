using Application.Featues.CarColors.Models;
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

namespace Application.Featues.CarColors.Queries.GetlistCarColors
{
    public class GetListCarColorQuery:IRequest<CarColorListViewModel>
    {
        public PageRequest PageRequest { get; set; }


        public class GetListCarColorQueryHandler:IRequestHandler<GetListCarColorQuery,CarColorListViewModel>
        {

            private readonly ICarColorRepository carColorRepository;
            private readonly IMapper mapper;
            public GetListCarColorQueryHandler(ICarColorRepository carColorRepository, IMapper mapper)
            {
                this.carColorRepository = carColorRepository;
                this.mapper = mapper;
            }

            public async Task<CarColorListViewModel> Handle(GetListCarColorQuery request, CancellationToken cancellationToken)
            {
                IPaginate<CarColor> paginate = await carColorRepository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize);

                CarColorListViewModel carColorListViewModel = mapper.Map<CarColorListViewModel>(paginate);

                return carColorListViewModel;
            }
        }
    }
}
