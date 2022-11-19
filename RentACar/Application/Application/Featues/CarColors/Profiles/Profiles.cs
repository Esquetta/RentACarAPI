using Application.Featues.CarColors.Commands.CreateCarColor;
using Application.Featues.CarColors.Commands.UpdateCarColor;
using Application.Featues.CarColors.Dtos;
using Application.Featues.CarColors.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.CarColors.Profiles
{
    public class Profiles:Profile
    {
        public Profiles()
        {
            CreateMap<CreateCarColorCommand, CarColor>().ReverseMap();
            CreateMap<CreatedCarColorDto, CarColor>().ReverseMap();

            CreateMap<DeletedCarColorDto,CarColor>().ReverseMap();

            CreateMap<UpdatedCarColorDto, CarColor>().ReverseMap();
            CreateMap<UpdateCarColorCommand, CarColor>().ReverseMap();


            CreateMap<CarColorListDto, CarColor>().ReverseMap();
            CreateMap<IPaginate<CarColor>,CarColorListViewModel>().ReverseMap();
        }
    }
}
