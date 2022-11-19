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

namespace Application.Featues.CarColors.Commands.DeleteCarColor
{
    public class DeleteCarColorCommand : IRequest<DeletedCarColorDto>
    {
        public int Id { get; set; }

        public class DeleteCarColorCommandHandler : IRequestHandler<DeleteCarColorCommand, DeletedCarColorDto>
        {
            private readonly ICarColorRepository carColorRepository;
            private readonly CarColorBusinessRules carColorBusinessRules;
            private readonly IMapper mapper;
            public DeleteCarColorCommandHandler(ICarColorRepository carColorRepository, CarColorBusinessRules carColorBusinessRules, IMapper mapper)
            {
                this.carColorRepository = carColorRepository;
                this.carColorBusinessRules = carColorBusinessRules;
                this.mapper = mapper;
            }

            public async Task<DeletedCarColorDto> Handle(DeleteCarColorCommand request, CancellationToken cancellationToken)
            {
               CarColor carColor= await carColorBusinessRules.IsCarColorExists(request.Id);

                CarColor deletedCarColor = await carColorRepository.DeleteAsync(carColor);

                DeletedCarColorDto deletedCarColorDto = mapper.Map<DeletedCarColorDto>(deletedCarColor);

                return deletedCarColorDto;
            }
        }
    }
}
