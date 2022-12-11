using Application.Featues.Cars.Commands.CreateCar;
using Application.Featues.Cars.Commands.UpdateCar;
using Application.Featues.Cars.Dtos;
using Application.Featues.Cars.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Cars.Profiles
{
    public  class Profiles:Profile
    {
        public Profiles()
        {
            CreateMap<CreateCarCommand, Car>().ReverseMap();
            CreateMap<CreatedCarDto, Car>().ReverseMap();

            CreateMap<DeletedCarDto, Car>().ReverseMap();

            CreateMap<UpdatedCarDto,Car>().ReverseMap();
            CreateMap<UpdateCarCommand,Car>().ReverseMap();


            CreateMap<Car,CarListViewDto>().ForMember(x=>x.BrandName,src=>src.MapFrom(opt=>opt.Brand.BrandName))
                .ForMember(x => x.CarColor, src => src.MapFrom(opt => opt.CarColor.Color))
                .ForMember(x => x.Fuel, src => src.MapFrom(opt => opt.Fuel.FuelType))
                .ForMember(x => x.GearBox, src => src.MapFrom(opt => opt.GearBox.GearType))
                .ForMember(x => x.CarModelName, src => src.MapFrom(opt => opt.CarModel.ModelName))
                .ReverseMap();
            CreateMap<IPaginate<Car>,CarListViewModel>().ReverseMap();

        }
    }
}
