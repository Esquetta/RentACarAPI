using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.RentDetails.Rules
{
    public class RentDetailBusinessRules
    {
        private readonly IRentDetailRepository rentDetailRepository;
        public RentDetailBusinessRules(IRentDetailRepository rentDetailRepository)
        {
            this.rentDetailRepository = rentDetailRepository;
        }

        public async Task<RentDetail> CheckRentDetailByIdAndCarId(int id,int carId)
        {
            RentDetail rentDetail = await rentDetailRepository.GetAsync(x => x.RentId==id && x.CarId==carId);
            if (rentDetail == null) throw new BusinessException("Rent not exists.");
            return rentDetail;
        }
    }
}
