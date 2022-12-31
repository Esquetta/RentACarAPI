using Application.Featues.RentDetails.Dtos;
using Application.Featues.RentDetails.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.RentDetails.Commands.DeleteRentDetail
{
    public class DeleteRentDetailCommand:IRequest<DeletedRentDetailDto>
    {
        public int RentId { get; set; }
        public int CarId { get; set; }


        public class DeleteRentDetailCommandHandler:IRequestHandler<DeleteRentDetailCommand, DeletedRentDetailDto>
        {
            private readonly IRentDetailRepository rentDetailRepository;
            private readonly IMapper mapper;
            private readonly RentDetailBusinessRules rentDetailBusinessRules;
            public DeleteRentDetailCommandHandler(IRentDetailRepository rentDetailRepository, IMapper mapper, RentDetailBusinessRules rentDetailBusinessRules)
            {
                this.rentDetailRepository = rentDetailRepository;
                this.mapper = mapper;
                this.rentDetailBusinessRules = rentDetailBusinessRules;
            }

            public async Task<DeletedRentDetailDto> Handle(DeleteRentDetailCommand request, CancellationToken cancellationToken)
            {
                RentDetail rentDetail = await rentDetailBusinessRules.CheckRentDetailByIdAndCarId(request.RentId,request.CarId);

                RentDetail deletedRentDetail = await rentDetailRepository.DeleteAsync(rentDetail);

                DeletedRentDetailDto deletedRentDetailDto = mapper.Map<DeletedRentDetailDto>(deletedRentDetail);

                return deletedRentDetailDto;
            }
        }
    }
}
