using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Fuels.Rules
{
    public class FuelBusinessRules
    {
        private readonly IFuelRepository fuelRepository;
        public FuelBusinessRules(IFuelRepository fuelRepository)
        {
            this.fuelRepository = fuelRepository;
        }

        public async Task FuelCannotBeDuplicatedWhenInserted(string fuelName)
        {
            Fuel fuel = await fuelRepository.GetAsync(x=>x.FuelType==fuelName);
            if (fuel == null) throw new BusinessException("Fuel exist."); 
        }
        public async Task FuelCannotBeDuplicatedWhenUpdated(string fuelName)
        {
            Fuel fuel = await fuelRepository.GetAsync(x => x.FuelType == fuelName);
            if (fuel == null) throw new BusinessException("Fuel exist.");
        }

        public async Task<Fuel> IsFuelExists(int id)
        {
            Fuel fuel = await fuelRepository.GetAsync(x => x.Id == id);
            if (fuel == null) throw new BusinessException("Fuel not exists.");

            return fuel;

        }
    }
}
