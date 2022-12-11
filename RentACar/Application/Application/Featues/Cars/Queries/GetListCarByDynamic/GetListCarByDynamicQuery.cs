using Application.Featues.Cars.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Cars.Queries.GetListCarByDynamic
{
    public class GetListCarByDynamicQuery:IRequest<CarListViewModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListCarByDynamicQueryHandler:IRequestHandler<GetListCarByDynamicQuery, CarListViewModel>
        {
            private readonly ICarRepository carRepository;
            private readonly IMapper mapper;
            public GetListCarByDynamicQueryHandler(ICarRepository carRepository, IMapper mapper)
            {
                this.carRepository = carRepository;
                this.mapper = mapper;
            }

            public async Task<CarListViewModel> Handle(GetListCarByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Car> paginate = await carRepository.
                    GetListByDynamicAsync(request.Dynamic,
                    include:x => x.Include(x => new { x.Brand, x.CarColor, x.CarModel, x.Fuel, x.GearBox, x.Photos }),
                    size:request.PageRequest.PageSize,
                    index:request.PageRequest.Page);

                CarListViewModel carListViewModel = mapper.Map<CarListViewModel>(paginate);

                return carListViewModel;
            }
        }
    }
}
