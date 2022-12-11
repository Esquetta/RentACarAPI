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

namespace Application.Featues.Cars.Commands.DeleteCar
{
    public class DeleteCarCommand : IRequest<DeletedCarDto>
    {
        public int Id { get; set; }


        public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, DeletedCarDto>
        {
            private readonly ICarRepository carRepository;
            private readonly IMapper mapper;
            private readonly CarBusinessRules carBusinessRules;
            public DeleteCarCommandHandler(ICarRepository carRepository, IMapper mapper, CarBusinessRules carBusinessRules)
            {
                this.carRepository = carRepository;
                this.mapper = mapper;
                this.carBusinessRules = carBusinessRules;
            }

            public async Task<DeletedCarDto> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
            {
                Car car = await carBusinessRules.CarCheckById(request.Id);

                Car deletedCar = await carRepository.DeleteAsync(car);

                DeletedCarDto deletedCarDto = mapper.Map<DeletedCarDto>(deletedCar);

                return deletedCarDto;
            }
        }
    }
}
