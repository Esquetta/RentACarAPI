using Application.Featues.CarModels.Dtos;
using Application.Featues.CarModels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.CarModels.Commands.UpdateCarModel
{
    public class UpdateCarModelCommand:IRequest<UpdatedCarModelDto>
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public int BrandId { get; set; }


        public class UpdateCarModelCommandHandler:IRequestHandler<UpdateCarModelCommand,UpdatedCarModelDto>
        {
            private readonly ICarModelRepository carModelRepository;
            private readonly IMapper mapper;
            private readonly CarModelBusinessRules carModelBusinessRules;
            public UpdateCarModelCommandHandler(ICarModelRepository carModelRepository, IMapper mapper, CarModelBusinessRules carModelBusinessRules)
            {
                this.carModelRepository = carModelRepository;
                this.mapper = mapper;
                this.carModelBusinessRules = carModelBusinessRules;
            }

            public async Task<UpdatedCarModelDto> Handle(UpdateCarModelCommand request, CancellationToken cancellationToken)
            {
                await carModelBusinessRules.CarColorCannotBeDuplicatedWhenUpdated(request.ModelName);

                CarModel carModel = mapper.Map<CarModel>(request);

                CarModel updatedCarModel = await carModelRepository.UpdateAsync(carModel);

                UpdatedCarModelDto updatedCarModelDto= mapper.Map<UpdatedCarModelDto>(updatedCarModel);

                return updatedCarModelDto;
            }
        }
    }
}
