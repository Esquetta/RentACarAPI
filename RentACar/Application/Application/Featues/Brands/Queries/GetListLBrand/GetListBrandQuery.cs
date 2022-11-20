﻿using Application.Featues.Brands.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Brands.Queries.GetListLBrand
{
    public class GetListBrandQuery:IRequest<BrandListViewModel>
    {
        public PageRequest  PageRequest { get; set; }


        public class GetListBrandQueryHandler:IRequestHandler<GetListBrandQuery,BrandListViewModel>
        {
            private readonly IBrandRepository gearBoxRepository;
            private readonly IMapper mapper;
            public GetListBrandQueryHandler(IBrandRepository gearBoxRepository, IMapper mapper)
            {
                this.gearBoxRepository = gearBoxRepository;
                this.mapper = mapper;
            }

            public async Task<BrandListViewModel> Handle(GetListBrandQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Brand> paginate = await gearBoxRepository.GetListAsync(index:request.PageRequest.Page,size:request.PageRequest.PageSize);

                BrandListViewModel brandListViewModel = mapper.Map<BrandListViewModel>(paginate);

                return brandListViewModel;
            }
        }
    }
}
