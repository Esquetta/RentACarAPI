using Application.Featues.RentDetails.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.RentDetails.Queries.GetRentById
{
    public class GetRentByIdQuery:IRequest<RentDetailListViewDto>
    {
        public int Id { get; set; }


        public class GetRentByIdQueryHandler:IRequestHandler<GetRentByIdQuery,RentDetailListViewDto>
        {
            private readonly IMapper mapper;
            private readonly IRentDetailRepository rentDetailRepository;
            public GetRentByIdQueryHandler(IMapper mapper,IRentDetailRepository rentDetailRepository)
            {
                this.rentDetailRepository = rentDetailRepository;
                this.mapper = mapper;
            }

            public async Task<RentDetailListViewDto> Handle(GetRentByIdQuery request, CancellationToken cancellationToken)
            {
                IPaginate<RentDetail> paginate = await rentDetailRepository.GetListAsync(predicate: x => x.RentId == request.Id,
                    include: x => x.Include(x => x.Rent).Include(x => x.Car).Include(x=>x.Car.Brand)
                    .Include(x => x.Car.CarColor).Include(x => x.Car.GearBox).Include(x => x.Car.Fuel)
                    .Include(x => x.Rent.Customer).Include(x => x.Car.CarModel).Include(x => x.Car.Photos));
                //x.Include(x => x.Brand).Include(x => x.CarColor).Include(x => x.GearBox).Include(x => x.Fuel).Include(x => x.CarModel).Include(x => x.Photos)
                RentDetailListViewDto rentDetailListViewDto = mapper.Map<RentDetailListViewDto>(paginate.Items[0]);

                return rentDetailListViewDto;
            }
        }
    }
}
