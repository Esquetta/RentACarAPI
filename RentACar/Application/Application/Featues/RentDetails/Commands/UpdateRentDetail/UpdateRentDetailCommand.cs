using Application.Featues.RentDetails.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.RentDetails.Commands.UpdateRentDetail
{
    public class UpdateRentDetailCommand:IRequest<UpdatedRentDetailDto>
    {
        public int RentId { get; set; }
        public int CarId { get; set; }
        public decimal Price { get; set; }

        public class UpdateRentDetailCommandHandler:IRequestHandler<UpdateRentDetailCommand, UpdatedRentDetailDto>
        {
            private readonly IRentDetailRepository rentDetailRepository;
            private readonly IMapper mapper;
            public UpdateRentDetailCommandHandler(IRentDetailRepository rentDetailRepository, IMapper mapper)
            {
                this.rentDetailRepository = rentDetailRepository;
                this.mapper = mapper;
            }

            public async Task<UpdatedRentDetailDto> Handle(UpdateRentDetailCommand request, CancellationToken cancellationToken)
            {
                RentDetail rentDetail = mapper.Map<RentDetail>(request);

                RentDetail updatedRentDetail = await rentDetailRepository.UpdateAsync(rentDetail);

                UpdatedRentDetailDto updatedRentDetailDto = mapper.Map<UpdatedRentDetailDto>(updatedRentDetail);

                return updatedRentDetailDto;


            }
        }
    }
}
