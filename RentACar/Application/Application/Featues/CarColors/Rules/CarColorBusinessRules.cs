using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Featues.CarColors.Rules
{
    public class CarColorBusinessRules
    {
        private readonly ICarColorRepository carColorRepository;
        public CarColorBusinessRules(ICarColorRepository carColorRepository)
        {
            this.carColorRepository = carColorRepository;
        }

        public async Task CarColorCannotBeDuplicatedWhenInserted(string colorName)
        {
            CarColor carColor = await carColorRepository.GetAsync(x => x.Color == colorName);
            if (carColor != null) throw new BusinessException("CarColor exist.");
        }
        public async Task CarColorCannotBeDuplicatedWhenUpdated(string colorName)
        {
            CarColor carColor = await carColorRepository.GetAsync(x => x.Color == colorName);
            if (carColor != null) throw new BusinessException("CarColor exist.");
        }

        public async Task<CarColor> IsCarColorExists(int id)
        {
            CarColor carColor = await carColorRepository.GetAsync(x => x.Id == id);
            if (carColor == null) throw new BusinessException("CarColor not exists.");

            return carColor;

        }

    }
}
