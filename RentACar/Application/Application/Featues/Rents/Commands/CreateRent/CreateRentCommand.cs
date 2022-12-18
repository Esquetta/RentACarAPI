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

namespace Application.Featues.Rents.Commands.CreateRent
{
    public class CreateRentCommand : IRequest<CreatedRentDto>
    {
        public DateTime DateOfIssue { get; set; }
        public DateTime ReturnDate { get; set; }
        public int userId { get; set; }
        public bool IsFinished { get; set; }
        public int CarId { get; set; }
        public decimal Price { get; set; }

        public class CreateRentCommandHandler : IRequestHandler<CreateRentCommand, CreatedRentDto>
        {
            private readonly IRentRepository rentRepository;
            private readonly IMapper mapper;
            public CreateRentCommandHandler(IRentRepository rentRepository, IMapper mapper)
            {
                this.rentRepository = rentRepository;
                this.mapper = mapper;
            }

            public async Task<CreatedRentDto> Handle(CreateRentCommand request, CancellationToken cancellationToken)
            {
                Rent rent = new()
                {
                    IsFinished = false,
                    ReturnDate = request.ReturnDate,
                    userId = request.userId,
                    DateOfIssue = request.DateOfIssue,
                };
                
                Rent createdRent = await rentRepository.AddAsync(rent);
            }
        }
    }
}
