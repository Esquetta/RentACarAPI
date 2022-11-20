﻿using Application.Featues.Brands.Dtos;
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

namespace Application.Featues.Brands.Commands.DeleteBrand
{
    public class DeleteBrandCommand:IRequest<DeletedBrandDto>
    {
        public int Id { get; set; }


       public class DeleteBrandCommandHandler:IRequestHandler<DeleteBrandCommand, DeletedBrandDto>
        {
            private readonly IBrandRepository gearBoxRepository;
            private readonly IMapper mapper;
            private readonly BrandBusinessRules brandBusinessRules;
            public DeleteBrandCommandHandler(IBrandRepository gearBoxRepository,IMapper mapper,BrandBusinessRules brandBusinessRules)
            {
                this.mapper = mapper;
                this.brandBusinessRules = brandBusinessRules;
                this.gearBoxRepository = gearBoxRepository;
            }

            public async Task<DeletedBrandDto> Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
            {
                await brandBusinessRules.BrandCheckById(request.Id);

                Brand brand = await gearBoxRepository.GetAsync(x => x.Id == request.Id);

                Brand DeletedBrand = await gearBoxRepository.DeleteAsync(brand);


                DeletedBrandDto deletedBrand = mapper.Map<DeletedBrandDto>(DeletedBrand);

                return deletedBrand;


            }
        }
    }
}
