using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Rents.Rules
{
    public class RentBusinessRules
    {
        private readonly IRentRepository rentRepository;
        public RentBusinessRules(IRentRepository rentRepository)
        {
            this.rentRepository = rentRepository;
        }
        public async Task<Rent> RentCheckById(int id)
        {
            Rent rent = await rentRepository.GetAsync(x => x.Id == id);
            if (rent == null) throw new BusinessException("Rent not exists.");

            return rent;
        }
    }
}
