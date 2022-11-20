using Application.Featues.Brands.Commands.CreateBrand;
using Application.Featues.GearBoxses.Commands.CreateGearBox;
using Application.Featues.GearBoxses.Commands.UpdateGearBox;
using Application.Featues.GearBoxses.Dtos;
using Application.Featues.GearBoxses.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.GearBoxses.Profiles
{
    public class Profiles:Profile
    {
        public Profiles()
        {
            CreateMap<CreatedGearBoxDto, GearBox>().ReverseMap();
            CreateMap<CreateGearBoxCommand,GearBox>().ReverseMap();

            CreateMap<UpdatedGearBoxDto, GearBox>().ReverseMap();
            CreateMap<UpdateGearBoxCommand,GearBox>().ReverseMap();

            CreateMap<DeletedGearBoxDto, GearBox>().ReverseMap();
            

            CreateMap<GearBoxListViewDto, GearBox>().ReverseMap();
            CreateMap<IPaginate<GearBox>, GearBoxListViewModel>().ReverseMap();
        }
    }
}
