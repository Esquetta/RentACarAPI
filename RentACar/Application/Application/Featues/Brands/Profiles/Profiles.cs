﻿using Application.Featues.Brands.Commands.CreateBrand;
using Application.Featues.Brands.Commands.UpdateBrand;
using Application.Featues.Brands.Dtos;
using Application.Featues.Brands.Models;
using Application.Featues.CarModels.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Brands.Profiles
{
    public class Profiles:Profile
    {
        public Profiles()
        {
            CreateMap<CreateBrandCommand, Brand>().ReverseMap();
            CreateMap<CreatedBrandDto, Brand>().ReverseMap();

            CreateMap<DeletedBrandDto, Brand>().ReverseMap();

            CreateMap<UpdateBrandCommand, Brand>().ReverseMap();
            CreateMap<UpdatedBrandDto, Brand>().ReverseMap();
            

            CreateMap<BrandListViewDto, Brand>().ReverseMap();
            CreateMap<IPaginate<Brand>, BrandListViewModel>().ReverseMap();

            CreateMap<CarModelListViewDto, Model>().ReverseMap();
            CreateMap<BrandModelsListViewDto, Brand>().ReverseMap();
            CreateMap<IPaginate<Brand>, BrandModelsListViewModel>().ReverseMap();
        }
    }
}
