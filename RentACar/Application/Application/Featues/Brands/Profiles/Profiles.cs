using Application.Featues.Brands.Commands.CreateBrand;
using Application.Featues.Brands.Dtos;
using AutoMapper;
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
        }
    }
}
