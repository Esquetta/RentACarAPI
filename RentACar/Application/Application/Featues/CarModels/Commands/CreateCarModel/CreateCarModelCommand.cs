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

namespace Application.Featues.CarModels.Commands.CreateCarModel
{
    public class CreateCarModelCommand:IRequest<CreatedCarModelDto>
    {
        public string ModelName { get; set; }
        public int BrandId { get; set; }

        public class CreateCarModelCommandHandler:IRequestHandler<CreateCarModelCommand,CreatedCarModelDto>
        {
            private readonly ICarModelRepository carModelRepository;
            private readonly IMapper mapper;
            private readonly CarModelBusinessRules carModelBusinessRules;
            public CreateCarModelCommandHandler(ICarModelRepository carModelRepository, IMapper mapper, CarModelBusinessRules carModelBusinessRules)
            {
                this.carModelRepository = carModelRepository;
                this.mapper = mapper;
                this.carModelBusinessRules = carModelBusinessRules;
            }

            public async Task<CreatedCarModelDto> Handle(CreateCarModelCommand request, CancellationToken cancellationToken)
            {
                await carModelBusinessRules.CarColorCannotBeDuplicatedWhenInserted(request.ModelName);

                Model carModel = mapper.Map<Model>(request);

                Model createdCarModel = await carModelRepository.AddAsync(carModel);

                CreatedCarModelDto createdCarModelDto= mapper.Map<CreatedCarModelDto>(createdCarModel);

                return createdCarModelDto;
                     
            }
        }
    }
}
