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

namespace Application.Featues.GearBoxses.Commands.DeleteGearBox
{
    public class DeleteGearBoxCommand : IRequest<DeletedGearBoxDto>
    {
        public int Id { get; set; }


        public class DeleteGearBoxCommandHandler : IRequestHandler<DeleteGearBoxCommand, DeletedGearBoxDto>
        {
            private readonly IGearBoxRepository gearBoxRepository;
            private readonly GearBoxBusinessRules gearBoxBusinessRules;
            private readonly IMapper mapper;

            public DeleteGearBoxCommandHandler(IGearBoxRepository gearBoxRepository, GearBoxBusinessRules gearBoxBusinessRules, IMapper mapper)
            {
                this.mapper = mapper;
                this.gearBoxRepository = gearBoxRepository;
                this.gearBoxBusinessRules = gearBoxBusinessRules;
            }

            public async Task<DeletedGearBoxDto> Handle(DeleteGearBoxCommand request, CancellationToken cancellationToken)
            {
                GearBox gearBox = await gearBoxBusinessRules.GearBoxCheckById(request.Id);


                GearBox deletedGearBox = await gearBoxRepository.DeleteAsync(gearBox);

                DeletedGearBoxDto deletedGearBoxDto = mapper.Map<DeletedGearBoxDto>(deletedGearBox);
                return deletedGearBoxDto;
            }
        }
    }


}
