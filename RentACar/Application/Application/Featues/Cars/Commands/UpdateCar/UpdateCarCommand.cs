using Application.Featues.Cars.Dtos;
using Application.Featues.Cars.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Cars.Commands.UpdateCar
{
    public class UpdateCarCommand:IRequest<UpdatedCarDto>
    {
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int? CarModelId { get; set; }
        public DateTime ProductionDate { get; set; }
        public decimal Price { get; set; }
        public int HorsePower { get; set; }
        public int CarColorId { get; set; }
        public int GearBoxId { get; set; }
        public int FuelId { get; set; }
        public int Miles { get; set; }
        public string Description { get; set; }
        public bool For_Rent { get; set; }

        public class UpdateCarCommandHandler:IRequestHandler<UpdateCarCommand, UpdatedCarDto>
        {
            private readonly ICarRepository carRepository;
            private readonly IMapper mapper;
            public UpdateCarCommandHandler(ICarRepository carRepository,IMapper mapper)
            {
                this.mapper = mapper;
                this.carRepository = carRepository;
                
            }

            public async Task<UpdatedCarDto> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
            {

                Car car = mapper.Map<Car>(request);

                Car updatedCar = await carRepository.UpdateAsync(car);

                UpdatedCarDto updatedCarDto = mapper.Map<UpdatedCarDto>(updatedCar);

                return updatedCarDto;
            }
        }
    }
}
