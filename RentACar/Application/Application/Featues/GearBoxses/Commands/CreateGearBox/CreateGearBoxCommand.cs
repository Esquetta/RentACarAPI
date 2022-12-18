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

namespace Application.Featues.GearBoxses.Commands.CreateGearBox
{
    public class CreateGearBoxCommand:IRequest<CreatedGearBoxDto>
    {
        
        public string GearType { get; set; }
        public int Speed { get; set; }


        public class CreateGearBoxCommandHandler : IRequestHandler<CreateGearBoxCommand, CreatedGearBoxDto>
        {
            private readonly IGearBoxRepository gearBoxRepository;
            private readonly IMapper mapper;
            private readonly GearBoxBusinessRules gearBoxBusinessRules;
            public CreateGearBoxCommandHandler(IGearBoxRepository gearBoxRepository,GearBoxBusinessRules gearBoxBusinessRules,IMapper mapper)
            {
                this.gearBoxRepository= gearBoxRepository;
                this.mapper= mapper;
                this.gearBoxBusinessRules= gearBoxBusinessRules;
            }
                
            public async Task<CreatedGearBoxDto> Handle(CreateGearBoxCommand request, CancellationToken cancellationToken)
            {
                await gearBoxBusinessRules.GearBoxCannotBeDuplicatedWhenInserted(request.GearType,request.Speed);

                GearBox gearBox = mapper.Map<GearBox>(request);

                GearBox createdGearBox = await gearBoxRepository.AddAsync(gearBox);

                CreatedGearBoxDto createdGearBoxDto = mapper.Map<CreatedGearBoxDto>(createdGearBox);

                return createdGearBoxDto;

            }
        }
    }
}
