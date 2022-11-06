using Application.Featues.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommand:IRequest<UpdatedBrandDto>
    {
        public int Id { get; set; }
        public string BrandName { get; set; }

        public class UpdateBrandCommandHandler:IRequestHandler<UpdateBrandCommand,UpdatedBrandDto>
        {
            private readonly IBrandRepository brandRepository;
            private readonly IMapper mapper;
            private readonly BrandBusinessRules brandBusinessRules;
            public UpdateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
            {
                this.brandRepository = brandRepository;
                this.mapper = mapper;
                this.brandBusinessRules = brandBusinessRules;
            }

            public async Task<UpdatedBrandDto> Handle(UpdateBrandCommand request, CancellationToken cancellationToken)
            {
                await brandBusinessRules.BrandCheckById(request.Id);

                Brand brand = mapper.Map<Brand>(request);

                Brand updatedBrand = await brandRepository.UpdateAsync(brand);

                UpdatedBrandDto updatedBrandDto = mapper.Map<UpdatedBrandDto>(updatedBrand);

                return updatedBrand;
            }
        }
    }
}
