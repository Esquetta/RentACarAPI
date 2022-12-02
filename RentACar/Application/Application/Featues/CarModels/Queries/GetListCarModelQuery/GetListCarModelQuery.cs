using Application.Featues.CarModels.Models;
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

namespace Application.Featues.CarModels.Queries.GetListCarModelQuery
{
    public class GetListCarModelQuery:IRequest<CarModelListViewModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListCarModelQueryHandler:IRequestHandler<GetListCarModelQuery,CarModelListViewModel>
        {
            private readonly ICarModelRepository carModelRepository;
            private readonly IMapper mapper;
            public GetListCarModelQueryHandler(ICarModelRepository carModelRepository, IMapper mapper)
            {
                this.mapper = mapper;
                this.carModelRepository = carModelRepository;
            }

            public async Task<CarModelListViewModel> Handle(GetListCarModelQuery request, CancellationToken cancellationToken)
            {
                IPaginate<CarModel> paginate = await carModelRepository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize);

                CarModelListViewModel carModelListViewModel  =mapper.Map<CarModelListViewModel>(paginate);

                return carModelListViewModel;
            }
        }
    }
}
