using Application.Featues.Auth.Commands.Register;
using Application.Featues.Auth.Dtos;
using Application.Featues.Auths.Dtos;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Auths.Profiles
{
    public  class Profiles:Profile
    {
        public Profiles()
        {
            

            CreateMap<User, UserForRegisterDto>().ReverseMap();
          
            CreateMap<RefreshToken, RevokedDto>().ReverseMap();
        }
    }
}
