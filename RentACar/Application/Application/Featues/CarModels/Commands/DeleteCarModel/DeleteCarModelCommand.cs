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

namespace Application.Featues.CarModels.Commands.DeleteCarModel
{
    public class DeleteCarModelCommand:IRequest<DeletedCarModelDto>
    {
        public int Id { get; set; }

        public class DeleteCarModelCommandHandler:IRequestHandler<DeleteCarModelCommand,DeletedCarModelDto>
        {
            private readonly ICarModelRepository carModelRepository;
            private readonly CarModelBusinessRules carModelBusinessRules;
            private readonly IMapper mapper;

            public DeleteCarModelCommandHandler(ICarModelRepository carModelRepository,CarModelBusinessRules carModelBusinessRules,IMapper mapper)
            {
                this.mapper = mapper;
                this.carModelRepository = carModelRepository;
                this.carModelBusinessRules = carModelBusinessRules;
            }

            public async Task<DeletedCarModelDto> Handle(DeleteCarModelCommand request, CancellationToken cancellationToken)
            {
                CarModel carModel = await carModelBusinessRules.IsCarModelExists(request.Id);

                CarModel deletedCarModel = await carModelRepository.DeleteAsync(carModel);

                DeletedCarModelDto deletedCarModelDto = mapper.Map<DeletedCarModelDto>(deletedCarModel);

                return deletedCarModelDto;
            }
        }
    }
}
