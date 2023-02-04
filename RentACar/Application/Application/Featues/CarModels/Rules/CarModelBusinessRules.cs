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
            Model carModel = await carModelRepository.GetAsync(x => x.ModelName == modelName);
            if (carModel != null) throw new BusinessException("CarModel exist.");
        }
        public async Task CarColorCannotBeDuplicatedWhenUpdated(string modelName)
        {
            Model carModel = await carModelRepository.GetAsync(x => x.ModelName == modelName);
            if (carModel != null) throw new BusinessException("CarModel exist.");
        }

        public async Task<Model> IsCarModelExists(int id)
        {
            Model carModel = await carModelRepository.GetAsync(x => x.Id == id);
            if (carModel == null) throw new BusinessException("CarModel not exists.");

            return carModel;

        }
    }
}
