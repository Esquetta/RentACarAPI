using Application.Featues.Cars.Dtos;
using Application.Featues.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Cars.Commands.CreateCar
{
    public class CreateCarCommand :IRequest<CreatedCarDto>     
    {
        public int BrandId { get; set; }
        public int? CarModelId { get; set; }
        public short ProductionDate { get; set; }
        public double Price { get; set; }
        public int HorsePower { get; set; }
        public int CarColorId { get; set; }
        public int GearBoxId { get; set; }
        public int FuelId { get; set; }
        public int Miles { get; set; }
        public string Description { get; set; }
        public CarState CarState { get; set; }

        public class CreateCarCommandHandler:IRequestHandler<CreateCarCommand, CreatedCarDto>
        {
            private readonly ICarRepository carRepository;
            private readonly IMapper mapper;
            private readonly CarBusinessRules carBusinessRules;
            

            public CreateCarCommandHandler(ICarRepository carRepository,IMapper mapper,CarBusinessRules carBusinessRules)
            {
                this.carRepository = carRepository;
                this.mapper = mapper;
                this.carBusinessRules=carBusinessRules;
            }

            public async Task<CreatedCarDto> Handle(CreateCarCommand request, CancellationToken cancellationToken)
            {
                Car car = mapper.Map<Car>(request);

                Car createdCar = await carRepository.AddAsync(car);

                CreatedCarDto createdCarDto = mapper.Map<CreatedCarDto>(createdCar);

                return createdCarDto;
            }
        }
    }
}
