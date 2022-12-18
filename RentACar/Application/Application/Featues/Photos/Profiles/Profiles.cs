using Application.Featues.Cars.Dtos;
using Application.Featues.Photos.Commands.CreatePhoto;
using Application.Featues.Photos.Commands.UpdatePhoto;
using Application.Featues.Photos.Dtos;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Photos.Profiles
{
    public class Profiles:Profile
    {
        public Profiles()
        {
            CreateMap<Photo,CreatePhotoCommand>().ReverseMap();
            CreateMap<Photo,CreatedPhotoDto>().ReverseMap();


            CreateMap<Photo, DeletedPhotoDto>().ReverseMap();

            CreateMap<Photo, UpdatePhotoCommand>().ReverseMap();
            CreateMap<Photo,UpdatedPhotoDto>().ReverseMap();

            CreateMap<Photo, PhotoListViewDto>().ReverseMap();
        }
    }
}
