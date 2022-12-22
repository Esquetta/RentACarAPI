using Application.Featues.OperationClaims.Commands.CreateOperationClaim;
using Application.Featues.OperationClaims.Commands.UpdateOperationClaim;
using Application.Featues.OperationClaims.Dtos;
using Application.Featues.OperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.OperationClaims.Profiles
{
    public class Profiles:Profile
    {
        public Profiles()
        {

            CreateMap<OperationClaim, CreatedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, CreateOperationClaimCommand>().ReverseMap();


            CreateMap<OperationClaim,UpdatedOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, UpdateOperationClaimCommand>().ReverseMap();


            CreateMap<OperationClaim,DeletedOperationClaimDto>().ReverseMap();

            CreateMap<OperationClaim,OperationClaimListViewDto>().ReverseMap();
            CreateMap<IPaginate<OperationClaim>, OperationClaimListViewModel>().ReverseMap();
        }
    }
}
