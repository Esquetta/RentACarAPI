using Application.Featues.Auths.Dtos;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;

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
