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


            CreateMap<RentDetail, RentDetailListViewDto>().ForMember(x => x.FirstName, src => src.MapFrom(opt => opt.Rent.Customer.FirstName))
                .ForMember(x => x.LastName, src => src.MapFrom(opt => opt.Rent.Customer.LastName))
                .ForMember(x=>x.DateOfIssue,src=>src.MapFrom(opt=>opt.Rent.DateOfIssue))
                .ForMember(x=>x.ReturnDate,src=>src.MapFrom(opt=>opt.Rent.ReturnDate));
                

            
                
        }
    }
}
