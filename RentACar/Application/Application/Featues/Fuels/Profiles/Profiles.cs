using Application.Featues.Brands.Dtos;
using Application.Featues.Brands.Models;
using Application.Featues.Fuels.Commands.CreateFuel;
using Application.Featues.Fuels.Commands.DeleteFuel;
using Application.Featues.Fuels.Dtos;
using Application.Featues.Fuels.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Fuels.Profiles
{
    public class Profiles: Profile
    {
        public Profiles()
        {

            CreateMap<Fuel, CreatedFuelDto>().ReverseMap();
            CreateMap<Fuel, CreateFuelCommand>().ReverseMap();

            CreateMap<Fuel, DeleteFuelCommand>().ReverseMap();
            CreateMap<Fuel, DeletedFuelDto>().ReverseMap();

            CreateMap<Fuel, UpdateFuelCommand>().ReverseMap();
            CreateMap<Fuel, UpdatedFuelDto>().ReverseMap();

            CreateMap<Fuel, FuelListViewDto>().ReverseMap();
            CreateMap<IPaginate<Fuel>, FuelListViewModel>().ReverseMap();
        }
    }
}
