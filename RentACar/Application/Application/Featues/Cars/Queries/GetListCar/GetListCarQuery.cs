using Application.Featues.Cars.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Cars.Queries.GetListCar
{
    public class GetListCarQuery:IRequest<CarListViewModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListCarQueryHandler:IRequestHandler<GetListCarQuery, CarListViewModel>
        {
            private readonly ICarRepository carRepository;
            private readonly IMapper mapper;
            public GetListCarQueryHandler(ICarRepository carRepository, IMapper mapper)
            {
                this.carRepository = carRepository;
                this.mapper = mapper;
            }

            public async Task<CarListViewModel> Handle(GetListCarQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Car> paginate = await carRepository.GetListAsync
                    (include: x => x.Include(x =>x.Brand).Include(x=>x.CarColor).Include(x=>x.GearBox).Include(x=>x.Fuel).Include(x=>x.CarModel).Include(x=>x.Photos),
                    index:request.PageRequest.Page,
                    size:request.PageRequest.PageSize);

                CarListViewModel carListViewModel = mapper.Map<CarListViewModel>(paginate);
                

                return carListViewModel;
            }
        }
    }
}
