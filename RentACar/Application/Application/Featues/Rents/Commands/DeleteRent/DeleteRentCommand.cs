using Application.Featues.Rents.Dtos;
using Application.Featues.Rents.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Rents.Commands.DeleteRent
{
    public class DeleteRentCommand:IRequest<DeletedRentDto>
    {
        public int Id { get; set; }


        public class DeleteRentCommandHandler:IRequestHandler<DeleteRentCommand, DeletedRentDto>
        {
            private readonly IRentRepository rentRepository;
            private readonly IMapper mapper;
            private readonly RentBusinessRules rentBusinessRules;
            public DeleteRentCommandHandler(IRentRepository rentRepository, IMapper mapper,RentBusinessRules rentBusinessRules)
            {
                this.rentBusinessRules = rentBusinessRules;
                this.rentRepository = rentRepository;
                this.mapper = mapper;
            }

            public  async Task<DeletedRentDto> Handle(DeleteRentCommand request, CancellationToken cancellationToken)
            {
                var rent =  await rentBusinessRules.RentCheckById(request.Id);

                Rent deletedRent = await rentRepository.DeleteAsync(rent);

                DeletedRentDto deletedRentDto = mapper.Map<DeletedRentDto>(deletedRent);

                return deletedRentDto;

            }
        }

    }
}
