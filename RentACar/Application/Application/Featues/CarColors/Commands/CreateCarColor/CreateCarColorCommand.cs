using Application.Featues.Brands.Dtos;
using Application.Featues.Brands.Rules;
using Application.Featues.CarColors.Dtos;
using Application.Featues.CarColors.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.CarColors.Commands.CreateCarColor
{
    public class CreateCarColorCommand:IRequest<CreatedCarColorDto>
    {
        public string Color { get; set; }

        public class CreateCarColorCommandHandler:IRequestHandler<CreateCarColorCommand, CreatedCarColorDto>
        {
            private readonly ICarColorRepository carColorRepository;
            private readonly CarColorBusinessRules carColorBusinessRules;
            private readonly IMapper mapper;
            public CreateCarColorCommandHandler(ICarColorRepository carColorRepository, CarColorBusinessRules carColorBusinessRules, IMapper mapper)
            {
                this.carColorRepository = carColorRepository;
                this.carColorBusinessRules = carColorBusinessRules;
                this.mapper = mapper;
            }

            public async Task<CreatedCarColorDto> Handle(CreateCarColorCommand request, CancellationToken cancellationToken)
            {
                await carColorBusinessRules.CarColorCannotBeDuplicatedWhenInserted(request.Color);

                CarColor carColor = mapper.Map<CarColor>(request);

                CarColor addedCarColor = await carColorRepository.AddAsync(carColor);

                CreatedCarColorDto createdCarColor = mapper.Map<CreatedCarColorDto>(addedCarColor);

                return createdCarColor;
            }
        }
    }
}
