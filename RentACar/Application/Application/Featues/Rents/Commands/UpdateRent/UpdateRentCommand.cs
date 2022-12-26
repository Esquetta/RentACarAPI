using Application.Featues.Rents.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Rents.Commands.UpdateRent
{
    public class UpdateRentCommand : IRequest<UpdatedRentDto>
    {
        public DateTime DateOfIssue { get; set; }
        public DateTime ReturnDate { get; set; }
        public int userId { get; set; }
        public bool IsFinished { get; set; }

        public class UpdateRentCommandHandler : IRequestHandler<UpdateRentCommand, UpdatedRentDto>
        {
            private readonly IRentRepository rentRepository;
            private readonly IMapper mapper;
            public UpdateRentCommandHandler(IRentRepository rentRepository, IMapper mapper)
            {
                this.mapper = mapper;
                this.rentRepository = rentRepository;
            }

            public async Task<UpdatedRentDto> Handle(UpdateRentCommand request, CancellationToken cancellationToken)
            {
                Rent rent = mapper.Map<Rent>(request);

                Rent updatedRent = await rentRepository.UpdateAsync(rent);

                UpdatedRentDto updatedRentDto = mapper.Map<UpdatedRentDto>(updatedRent);

                return updatedRentDto;

            }
        }
    }
}
