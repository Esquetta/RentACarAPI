using Application.Featues.Rents.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Featues.Rents.Commands.CreateRent
{
    public class CreateRentCommand : IRequest<CreatedRentDto>
    {
        public DateTime DateOfIssue { get; set; }
        public DateTime ReturnDate { get; set; }
        public int userId { get; set; }
        public bool IsFinished { get; set; } = false;

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
                Rent rent = mapper.Map<Rent>(request);

                Rent createdRent = await rentRepository.AddAsync(rent);

                CreatedRentDto createdRentDto = mapper.Map<CreatedRentDto>(createdRent);


                return createdRentDto;


            }
        }
    }
}
