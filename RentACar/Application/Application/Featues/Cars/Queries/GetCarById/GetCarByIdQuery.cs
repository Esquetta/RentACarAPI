using Application.Featues.Brands.Queries.GetListLBrand;
using Application.Featues.Cars.Dtos;
using Application.Featues.Cars.Models;
using Application.Featues.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Cars.Queries.GetCarById
{
    public class GetCarByIdQuery:IRequest<CarListViewModel>
    {
        public int Id { get; set; }

        public class GetCarByIdQueryHandler:IRequestHandler<GetCarByIdQuery, CarListViewModel>
        {
            private readonly ICarRepository carRepository;
            private readonly IMapper mapper;
            private readonly CarBusinessRules carBusinessRules;
            public GetCarByIdQueryHandler(ICarRepository carRepository,IMapper mapper,CarBusinessRules carBusinessRules)
            {
                this.mapper= mapper;
                this.carRepository= carRepository;
                this.carBusinessRules= carBusinessRules;
            }

            public async Task<CarListViewModel> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
            {
                await carBusinessRules.CarCheckById(request.Id);
                IPaginate<Car> paginate = await carRepository.GetListAsync(
                    include: x => x.Include(x => x.Brand).Include(x => x.CarColor).Include(x => x.GearBox).Include(x => x.Fuel).Include(x => x.CarModel).Include(x => x.Photos),
                    predicate:x=>x.Id==request.Id);

                CarListViewModel carListViewModel = mapper.Map<CarListViewModel>(paginate);

                return carListViewModel;
            }
        }
    }
}
