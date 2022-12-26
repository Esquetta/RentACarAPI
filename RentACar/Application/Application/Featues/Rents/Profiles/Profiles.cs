using Application.Featues.Rents.Commands.CreateRent;
using Application.Featues.Rents.Commands.UpdateRent;
using Application.Featues.Rents.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Rents.Profiles
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            CreateMap<CreateRentCommand, Rent>().ReverseMap();
            CreateMap<CreatedRentDto, Rent>().ReverseMap();

            CreateMap<UpdatedRentDto, Rent>().ReverseMap();
            CreateMap<UpdateRentCommand, Rent>().ReverseMap();
        }
    }
}
