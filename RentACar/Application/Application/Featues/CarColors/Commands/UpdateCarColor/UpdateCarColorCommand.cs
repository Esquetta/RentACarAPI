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

namespace Application.Featues.CarColors.Commands.UpdateCarColor
{
    public class UpdateCarColorCommand:IRequest<UpdatedCarColorDto>
    {
        public int Id { get; set; }
        public string Color { get; set; }

        public class UpdateCarColorCommandHandler : IRequestHandler<UpdateCarColorCommand, UpdatedCarColorDto>
        {

            private readonly ICarColorRepository carColorRepository;
            private readonly IMapper mapper;
            private readonly CarColorBusinessRules carColorBusinessRules;
            public UpdateCarColorCommandHandler(ICarColorRepository carColorRepository, IMapper mapper, CarColorBusinessRules carColorBusinessRules)
            {
                this.carColorRepository = carColorRepository;
                this.mapper = mapper;
                this.carColorBusinessRules = carColorBusinessRules;
            }

            public async Task<UpdatedCarColorDto> Handle(UpdateCarColorCommand request, CancellationToken cancellationToken)
            {
                await carColorBusinessRules.CarColorCannotBeDuplicatedWhenUpdated(request.Color);

                CarColor carColor = mapper.Map<CarColor>(request);

                CarColor updatedCarColor = await carColorRepository.UpdateAsync(carColor);

                UpdatedCarColorDto updatedCarColorDto = mapper.Map<UpdatedCarColorDto>(updatedCarColor);

                return updatedCarColorDto;
            }
        }
    }
}
