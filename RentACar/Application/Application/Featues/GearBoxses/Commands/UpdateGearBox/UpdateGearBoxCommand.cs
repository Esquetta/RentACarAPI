using Application.Featues.Fuels.Dtos;
using Application.Featues.Fuels.Rules;
using Application.Featues.GearBoxses.Dtos;
using Application.Featues.GearBoxses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.GearBoxses.Commands.UpdateGearBox
{
    public class UpdateGearBoxCommand:IRequest<UpdatedGearBoxDto>
    {
        public int Id { get; set; }
        public string GearType { get; set; }
        public int Speed { get; set; }

        public class UpdateGearBoxCommandHandler:IRequestHandler<UpdateGearBoxCommand, UpdatedGearBoxDto>
        {
            private readonly IGearBoxRepository gearBoxRepository;
            private readonly IMapper mapper;
            private readonly GearBoxBusinessRules gearBoxBusinessRules;
            public UpdateGearBoxCommandHandler(IGearBoxRepository gearBoxRepository, IMapper mappper, GearBoxBusinessRules gearBoxBusinessRules)
            {
                this.gearBoxRepository = gearBoxRepository;
                this.mapper = mappper;
                this.gearBoxBusinessRules = gearBoxBusinessRules;
            }

            public async Task<UpdatedGearBoxDto> Handle(UpdateGearBoxCommand request, CancellationToken cancellationToken)
            {
                await gearBoxBusinessRules.GearBoxCannotBeDuplicatedWhenUpdated(request.GearType,request.Speed);
                GearBox gearBox = mapper.Map<GearBox>(request);
                GearBox updatedGearBox = await gearBoxRepository.UpdateAsync(gearBox);

                UpdatedGearBoxDto deletedFuelDto = mapper.Map<UpdatedGearBoxDto>(updatedGearBox);

                return deletedFuelDto;
            }
        }
    }
}
