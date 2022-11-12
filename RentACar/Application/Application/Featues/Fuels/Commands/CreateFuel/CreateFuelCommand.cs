using Application.Featues.Brands.Rules;
using Application.Featues.Fuels.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Fuels.Commands.CreateFuel
{
    public class CreateFuelCommand:IRequest<CreatedFuelDto>
    {
        public string FuelType { get; set; }


        public class CreateFuelCommandHandler:IRequestHandler<CreateFuelCommand, CreatedFuelDto>
        {
            private readonly IMapper mapper;
            private readonly IFuelRepository fuelRepository;
            private readonly BrandBusinessRules brandBusinessRules;
            public CreateFuelCommandHandler(IMapper mapper,IFuelRepository fuelRepository,BrandBusinessRules brandBusinessRules)
            {
                this.mapper = mapper;
                this.brandBusinessRules = brandBusinessRules;
                this.fuelRepository = fuelRepository;
            }

            public async Task<CreatedFuelDto> Handle(CreateFuelCommand request, CancellationToken cancellationToken)
            {
                await brandBusinessRules.BrandNameCannotBeDuplicatedWhenInserted(request.FuelType);

                Fuel fuel = mapper.Map<Fuel>(request);

                Fuel addedFuel=await fuelRepository.AddAsync(fuel);

                CreatedFuelDto createdFuelDto = mapper.Map<CreatedFuelDto>(addedFuel);

                return createdFuelDto;


            }
        }
    }
}
