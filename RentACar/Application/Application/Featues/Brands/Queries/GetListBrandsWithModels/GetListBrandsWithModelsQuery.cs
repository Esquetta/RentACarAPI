using Application.Featues.Brands.Dtos;
using Application.Featues.Brands.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Brands.Queries.GetListBrandsWithModels
{
    public class GetListBrandsWithModelsQuery:IRequest<BrandModelsListViewModel>
    {
        public PageRequest PageRequest { get; set; }


        public class GetListBrandsWithModelsQueryHandler:IRequestHandler<GetListBrandsWithModelsQuery, BrandModelsListViewModel>
        {
            private readonly IMapper mapper;
            private readonly IBrandRepository gearBoxRepository;
            public GetListBrandsWithModelsQueryHandler(IMapper mapper, IBrandRepository gearBoxRepository)
            {
                this.mapper = mapper;
                this.gearBoxRepository = gearBoxRepository;
            }

            public async Task<BrandModelsListViewModel> Handle(GetListBrandsWithModelsQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Brand> paginate = await gearBoxRepository.GetListAsync(include:x=>x.Include(x=>x.CarModels),index:request.PageRequest.Page,size:request.PageRequest.PageSize);

                BrandModelsListViewModel brandModelsListViewModel = mapper.Map<BrandModelsListViewModel>(paginate);

                return brandModelsListViewModel; 
                     
            }
        }
    }
}
