using Application.Featues.Brands.Dtos;
using Application.Featues.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Logging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Brands.Commands.CreateBrand
{
    public class CreateBrandCommand:IRequest<CreatedBrandDto>,ILoggableRequest
    {

        public string BrandName { get; set; }


       public class CreateBrandCommandHandler:IRequestHandler<CreateBrandCommand,CreatedBrandDto>
        {
            private readonly IMapper mapper;
            private readonly IBrandRepository brandRepository;
            private readonly BrandBusinessRules brandBusinessRules;
            public CreateBrandCommandHandler(IMapper mapper,IBrandRepository brandRepository, BrandBusinessRules brandBusinessRules)
            {
                this.mapper = mapper;
                this.brandBusinessRules = brandBusinessRules;
                this.brandRepository = brandRepository;
            }

            public async Task<CreatedBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {

                await brandBusinessRules.BrandNameCannotBeDuplicatedWhenInserted(request.BrandName);

                Brand brand = mapper.Map<Brand>(request);

                Brand addedBrand= await brandRepository.AddAsync(brand);

                CreatedBrandDto createdBrand = mapper.Map<CreatedBrandDto>(addedBrand);

                return createdBrand;
               
            }
        }
    }
}
