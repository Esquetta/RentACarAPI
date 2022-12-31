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

namespace Application.Featues.RentDetails.Commands.CreateRentDetail
{
    public class CreateRentDetailCommand:IRequest<CreatedRentDetailDto>
    {
        public int RentId { get; set; }
        public int CarId { get; set; }
        public decimal Price { get; set; }

        public class CreatRentDetailCommandHandler:IRequestHandler<CreateRentDetailCommand, CreatedRentDetailDto>
        {
            private readonly IRentDetailRepository rentDetailRepository;
            private IMapper mapper;
            public CreatRentDetailCommandHandler(IRentDetailRepository rentDetailRepository, IMapper mapper)
            {
                this.rentDetailRepository = rentDetailRepository;
                this.mapper = mapper;
            }

            public async Task<CreatedRentDetailDto> Handle(CreateRentDetailCommand request, CancellationToken cancellationToken)
            {
                RentDetail rentDetail = mapper.Map<RentDetail>(request);

                RentDetail createdRentDetail = await rentDetailRepository.AddAsync(rentDetail);

                CreatedRentDetailDto createdRentDetailDto = mapper.Map<CreatedRentDetailDto>(createdRentDetail);

                return createdRentDetailDto;
            }
        }
    }
}
