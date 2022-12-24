using Application.Featues.UserOperationClaims.Commands.CreateUserOperatinoClaimCommand;
using Application.Featues.UserOperationClaims.Commands.UpdateUserOperationClaim;
using Application.Featues.UserOperationClaims.Dtos;
using Application.Featues.UserOperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.UserOperationClaims.Profiles
{
    public class Profiles:Profile
    {
        public Profiles()
        {
            CreateMap<UserOperationClaim, CreateUserOperationClaimCommand>().ReverseMap();
            CreateMap<UserOperationClaim,CreatedUserOperationClaimDto>().ReverseMap();


            CreateMap<UserOperationClaim, DeletedUserOperationClaimDto>().ReverseMap();
            CreateMap<UserOperationClaim, DeleteUserOperationClaimCommand>().ReverseMap();


            CreateMap<UserOperationClaim,UserOperationClaimListViewDto>().ReverseMap();
            CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimListViewModel>().ReverseMap();
        }
    }
}
