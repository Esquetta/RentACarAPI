using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.CarModels.Rules
{
    public class CarModelBusinessRules
    {
        private readonly ICarModelRepository carModelRepository;
        public CarModelBusinessRules(ICarModelRepository carModelRepository)
        {
            this.carModelRepository = carModelRepository;
        }
        public async Task CarColorCannotBeDuplicatedWhenInserted(string modelName)
        {
            CarModel carModel = await carModelRepository.GetAsync(x => x.ModelName == modelName);
            if (carModel != null) throw new BusinessException("CarModel exist.");
        }
        public async Task CarColorCannotBeDuplicatedWhenUpdated(string modelName)
        {
            CarModel carModel = await carModelRepository.GetAsync(x => x.ModelName == modelName);
            if (carModel != null) throw new BusinessException("CarModel exist.");
        }

        public async Task<CarModel> IsCarModelExists(int id)
        {
            CarModel carModel = await carModelRepository.GetAsync(x => x.Id == id);
            if (carModel == null) throw new BusinessException("CarModel not exists.");

            return carModel;

        }
    }
}
