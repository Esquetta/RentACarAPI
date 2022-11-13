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
    public class UpdateFuelCommand:IRequest<UpdatedFuelDto>
    {
        public int Id { get; set; }
        public string FuelType { get; set; }


        public class UpdateFuelCommandHandler : IRequestHandler<UpdateFuelCommand, UpdatedFuelDto>
        {
            private readonly IMapper mapper;
            private readonly IFuelRepository fuelRepository;
            private readonly FuelBusinessRules fuelBusinessRules;

            public UpdateFuelCommandHandler(IMapper mapper, IFuelRepository fuelRepository,FuelBusinessRules fuelBusinessRules)
            {
                this.fuelBusinessRules= fuelBusinessRules;
                this.mapper = mapper;
                this.fuelRepository = fuelRepository;
            }

            public async Task<UpdatedFuelDto> Handle(UpdateFuelCommand request, CancellationToken cancellationToken)
            {
                await fuelBusinessRules.FuelCannotBeDuplicatedWhenUpdated(request.FuelType);
                Fuel fuel = mapper.Map<Fuel>(request);
                Fuel updatedFuel = await fuelRepository.DeleteAsync(fuel);

                UpdatedFuelDto deletedFuelDto = mapper.Map<UpdatedFuelDto>(updatedFuel);

                return deletedFuelDto;
            }
        }
    }
}
