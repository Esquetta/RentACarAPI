using Application.Featues.Brands.Dtos;
using Application.Featues.CarColors.Models;
using Application.Featues.CarModels.Commands;
using Application.Featues.CarModels.Commands.CreateCarModel;
using Application.Featues.CarModels.Commands.UpdateCarModel;
using Application.Featues.CarModels.Dtos;
using Application.Featues.CarModels.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.CarModels.Profiles
{
    public class Profiles:Profile
    {
        public Profiles()
        {
            CreateMap<CarModel, CreatedCarModelDto>().ReverseMap();
            CreateMap<CarModel, CreateCarModelCommand>().ReverseMap();

            CreateMap<CarModel, UpdatedCarModelDto>().ReverseMap();
            CreateMap<CarModel, UpdateCarModelCommand>().ReverseMap();

            CreateMap<CarModel, DeletedCarModelDto>().ReverseMap();

            CreateMap<CarModelListViewDto,CarModel>().ReverseMap();
            CreateMap<CarModelListViewModel, IPaginate<CarModel>>().ReverseMap();

        }
    }
}
