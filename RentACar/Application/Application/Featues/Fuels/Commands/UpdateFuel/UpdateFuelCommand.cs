using Application.Featues.Fuels.Dtos;
using Application.Featues.Fuels.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Fuels.Commands.DeleteFuel
{
    public class UpdateFuelCommand:IRequest<DeletedFuelDto>
    {
        public int Id { get; set; }


        public class DeleteFuelCommandHandler : IRequestHandler<UpdateFuelCommand, DeletedFuelDto>
        {
            private readonly IMapper mapper;
            private readonly IFuelRepository fuelRepository;
            private readonly FuelBusinessRules fuelBusinessRules;

            public DeleteFuelCommandHandler(IMapper mapper, IFuelRepository fuelRepository,FuelBusinessRules fuelBusinessRules)
            {
                this.fuelBusinessRules= fuelBusinessRules;
                this.mapper = mapper;
                this.fuelRepository = fuelRepository;
            }

            public async Task<DeletedFuelDto> Handle(UpdateFuelCommand request, CancellationToken cancellationToken)
            {
                Fuel fuel = await fuelBusinessRules.IsFuelExists(request.Id);

                Fuel deletedFuel = await fuelRepository.DeleteAsync(fuel);

                DeletedFuelDto deletedFuelDto = mapper.Map<DeletedFuelDto>(deletedFuel);

                return deletedFuelDto;
            }
        }
    }
}
