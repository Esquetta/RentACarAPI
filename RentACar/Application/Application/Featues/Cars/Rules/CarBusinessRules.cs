using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.Cars.Rules
{
    public class CarBusinessRules
    {
        private readonly ICarRepository carRepository;
        public CarBusinessRules(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }     
        public async Task<Car> CarCheckById(int id)
        {
            Car car = await carRepository.GetAsync(x => x.Id == id);
            if (car == null) throw new BusinessException("Car not exists.");

            return car;
        }
    }
}
