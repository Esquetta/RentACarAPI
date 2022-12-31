using Application.Featues.RentDetails.Commands.CreateRentDetail;
using Application.Featues.RentDetails.Commands.UpdateRentDetail;
using Application.Featues.RentDetails.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.RentDetails.Profiles
{
    public class Profiles:Profile
    {
        public Profiles()
        {
            CreateMap<RentDetail, CreateRentDetailCommand>().ReverseMap();
            CreateMap<RentDetail, CreatedRentDetailDto>().ReverseMap();


            CreateMap<RentDetail, UpdateRentDetailCommand>().ReverseMap();
            CreateMap<RentDetail, UpdatedRentDetailDto>().ReverseMap();
            


            CreateMap<RentDetail, DeletedRentDetailDto>().ReverseMap();
        }
    }
}
